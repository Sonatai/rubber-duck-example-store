using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rubber.Duck.Store.Product.Catalog.DTOs;

namespace Rubber.Duck.Store.Product.Catalog.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ActionResult<ProductsResponseDto>>
    {
        private readonly ILogger<GetProductsQuery> _logger;
        private readonly AppConfig _appConfig;

        public GetProductsQueryHandler(ILogger<GetProductsQuery> logger, AppConfig appConfig)
        {
            _logger = logger;
            _appConfig = appConfig;
        }

        public async Task<ActionResult<ProductsResponseDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<ProductResponseDto> products = new();

                foreach (Guid productId in request.ProductIds)
                {
                    ProductResponseDto? product = JsonConvert.DeserializeObject<ProductResponseDto>(File.ReadAllText(Path.GetFullPath($"{_appConfig.ProductDataPath}{productId}.json")));

                    byte[] imageBytes = File.ReadAllBytes(Path.GetFullPath($"{_appConfig.ProductImagePath}{productId}.jpg"));
                    string image = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                    product.Image = image;

                    products.Add(product);
                }

                return new OkObjectResult(new ProductsResponseDto
                {
                    Products = products
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new BadRequestObjectResult(ex);
            }
        }
    }
}

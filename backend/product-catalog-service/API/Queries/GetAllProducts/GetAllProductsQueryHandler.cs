using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rubber.Duck.Store.Product.Catalog.DTOs;

namespace Rubber.Duck.Store.Product.Catalog.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ActionResult<ProductsResponseDto>>
{
    private readonly ILogger<GetAllProductsQuery> _logger;
    private readonly AppConfig _appConfig;

    public GetAllProductsQueryHandler(ILogger<GetAllProductsQuery> logger, AppConfig appConfig)
    {
        _logger = logger;
        _appConfig = appConfig;
    }

    public async Task<ActionResult<ProductsResponseDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            string path = Path.GetFullPath(_appConfig.ProductDataPath);
            string[] files = Directory.GetFiles(path);

            List<ProductResponseDto> products = new();

            foreach (string file in files)
            {
                Console.WriteLine($"FILE PATH: {file}");
                ProductResponseDto? product = JsonConvert.DeserializeObject<ProductResponseDto>(File.ReadAllText(file));

                byte[] imageBytes = File.ReadAllBytes(Path.GetFullPath($"{_appConfig.ProductImagePath}{product.DomainId}.jpg"));
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

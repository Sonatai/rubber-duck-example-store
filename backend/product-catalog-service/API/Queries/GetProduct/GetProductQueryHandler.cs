using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rubber.Duck.Store.Product.Catalog.DTOs;

namespace Rubber.Duck.Store.Product.Catalog.Queries.GetProduct;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ActionResult<ProductResponseDto>>
{
    private readonly ILogger<GetProductQuery> _logger;
    private readonly AppConfig _appConfig;

    public GetProductQueryHandler(ILogger<GetProductQuery> logger, AppConfig appConfig)
    {
        _logger = logger;
        _appConfig = appConfig;
    }

    public async Task<ActionResult<ProductResponseDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        try
        {
            ProductResponseDto? product = JsonConvert.DeserializeObject<ProductResponseDto>(File.ReadAllText(Path.GetFullPath($"{_appConfig.ProductDataPath}{request.ProductId}.json")));

            byte[] imageBytes = File.ReadAllBytes(Path.GetFullPath($"{_appConfig.ProductImagePath}{request.ProductId}.jpg"));
            string image = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
            product.Image = image;

            return new OkObjectResult(product);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new BadRequestObjectResult(ex);
        }
    }
}

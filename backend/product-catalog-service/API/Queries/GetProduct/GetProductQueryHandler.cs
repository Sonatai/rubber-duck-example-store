using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rubber.Duck.Store.Product.Catalog.DTOs;

namespace Rubber.Duck.Store.Product.Catalog.Queries.GetProduct;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ActionResult<ProductResponseDto>>
{
    private readonly ILogger<GetProductQuery> _logger;

    public GetProductQueryHandler(ILogger<GetProductQuery> logger)
    {
        _logger = logger;
    }

    public async Task<ActionResult<ProductResponseDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        try
        {

            ProductResponseDto? product = JsonConvert.DeserializeObject<ProductResponseDto>(File.ReadAllText(Path.GetFullPath($"Products/{request.ProductId}.json")));

            byte[] imageBytes = File.ReadAllBytes(Path.GetFullPath($"Products/img/{request.ProductId}.jpg"));
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

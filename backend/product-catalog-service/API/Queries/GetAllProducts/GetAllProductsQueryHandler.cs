using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rubber.Duck.Store.Product.Catalog.DTOs;

namespace Rubber.Duck.Store.Product.Catalog.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ActionResult<ProductsResponseDto>>
{
    private readonly ILogger<GetAllProductsQuery> _logger;

    public GetAllProductsQueryHandler(ILogger<GetAllProductsQuery> logger)
    {
        _logger = logger;
    }

    public async Task<ActionResult<ProductsResponseDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            return new NoContentResult();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new BadRequestObjectResult(ex);
        }
    }
}

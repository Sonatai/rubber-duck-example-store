using MediatR;
using Microsoft.AspNetCore.Mvc;
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
            return new NoContentResult();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return new BadRequestObjectResult(ex);
        }
    }
}

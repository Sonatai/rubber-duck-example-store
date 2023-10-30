using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rubber.Duck.Store.Product.Catalog.DTOs;

namespace Rubber.Duck.Store.Product.Catalog.Queries.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ActionResult<ProductsResponseDto>>
    {
        private readonly ILogger<GetProductsQuery> _logger;

        public GetProductsQueryHandler(ILogger<GetProductsQuery> logger)
        {
            _logger = logger;
        }

        public async Task<ActionResult<ProductsResponseDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
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
}

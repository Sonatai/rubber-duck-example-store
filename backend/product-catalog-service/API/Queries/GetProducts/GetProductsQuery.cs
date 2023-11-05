using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rubber.Duck.Store.Product.Catalog.DTOs;

namespace Rubber.Duck.Store.Product.Catalog.Queries.GetProducts
{
    public class GetProductsQuery : IRequest<ActionResult<ProductsResponseDto>>
    {
        public IEnumerable<Guid> ProductIds { get; set; }

        public GetProductsQuery(IEnumerable<Guid> productIds) { ProductIds = productIds; }
    }
}

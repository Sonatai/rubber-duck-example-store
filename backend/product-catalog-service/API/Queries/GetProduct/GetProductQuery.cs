using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rubber.Duck.Store.Product.Catalog.DTOs;

namespace Rubber.Duck.Store.Product.Catalog.Queries.GetProduct;

public class GetProductQuery : IRequest<ActionResult<ProductResponseDto>>
{
    public Guid ProductId { get; private set; }

    public GetProductQuery(Guid productId) { ProductId = productId; }
}

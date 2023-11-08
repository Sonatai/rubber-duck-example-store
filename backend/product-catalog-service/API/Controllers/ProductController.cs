using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rubber.Duck.Store.Product.Catalog.DTOs;
using Rubber.Duck.Store.Product.Catalog.Queries.GetAllProducts;
using Rubber.Duck.Store.Product.Catalog.Queries.GetProduct;
using Rubber.Duck.Store.Product.Catalog.Queries.GetProducts;

namespace Rubber.Duck.Store.Product.Catalog.Controllers;

[ApiController]
[Route("/")]
public class ProductController : ControllerBase
{

    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("/product/{productId:guid}")]
    public async Task<ActionResult<ProductResponseDto>> GetProduct([FromRoute] Guid productId)
    {
        ActionResult<ProductResponseDto> response = await _mediator.Send(new GetProductQuery(productId));

        return response;
    }

    [HttpGet("/products")]
    public async Task<ActionResult<ProductsResponseDto>> GetAllProducts()
    {
        ActionResult<ProductsResponseDto> response = await _mediator.Send(new GetAllProductsQuery());

        return response;
    }

    [HttpPost("/products")]
    public async Task<ActionResult<ProductsResponseDto>> GetProducts([FromBody] ProductsRequestDto request)
    {
        ActionResult<ProductsResponseDto> response = await _mediator.Send(new GetProductsQuery(request.ProductIds));

        return response;
    }
}
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rubber.Duck.Store.Product.Catalog.DTOs;

namespace Rubber.Duck.Store.Product.Catalog.Queries.GetAllProducts;

public class GetAllProductsQuery : IRequest<ActionResult<ProductsResponseDto>> { }

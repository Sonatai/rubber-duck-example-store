using API.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Queries.GetCart
{
    public class GetCartQuery : IRequest<ActionResult<CartResponseDto>>
    {
        public string CartId { get; set; }
    }
}

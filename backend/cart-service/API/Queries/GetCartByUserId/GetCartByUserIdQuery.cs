using API.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Queries.GetCartByUserId;

public class GetCartByUserIdQuery : IRequest<ActionResult<CartResponseDto>>
{
    public string UserId { get; set; }
}

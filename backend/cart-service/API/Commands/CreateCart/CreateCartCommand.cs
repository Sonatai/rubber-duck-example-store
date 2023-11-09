using API.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Commands.CreateCart
{
    public class CreateCartCommand : IRequest<ActionResult<CartResponseDto>>
    {
        public CartRequestDto Cart { get; set; }
    }
}

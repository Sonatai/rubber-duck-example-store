using API.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Commands.UpdateCart
{
    public class UpdateCartCommand : IRequest<ActionResult>
    {
        public CartRequestDto Cart { get; set; }
    }
}

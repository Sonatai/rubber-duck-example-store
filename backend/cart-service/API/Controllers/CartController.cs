using API.Commands.CreateCart;
using API.Commands.DeleteCart;
using API.Commands.UpdateCart;
using API.DTOs;
using API.Queries.GetCart;
using API.Queries.GetCartByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/")]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/cart")]
        public async Task<ActionResult<CartResponseDto>> CreateCart([FromBody] CartRequestDto requestDto)
        {
            ActionResult<CartResponseDto> response = await _mediator.Send(new CreateCartCommand() { Cart = requestDto });

            return response;
        }

        [HttpGet("/cart/{cartId}")]
        public async Task<ActionResult<CartResponseDto>> GetCart(string cartId)
        {
            ActionResult<CartResponseDto> response = await _mediator.Send(new GetCartQuery() { CartId = cartId });

            return response;
        }

        [HttpGet("/cart/user/{userId}")]
        public async Task<ActionResult<CartResponseDto>> GetCartByUserId(string userId)
        {
            ActionResult<CartResponseDto> response = await _mediator.Send(new GetCartByUserIdQuery() { UserId = userId });

            return response;
        }

        [HttpPost("/cart/update")]
        public async Task<ActionResult> UpdateCart([FromBody] CartRequestDto requestDto)
        {
            ActionResult response = await _mediator.Send(new UpdateCartCommand() { Cart = requestDto });

            return response;
        }

        [HttpDelete("/cart/{cartId}")]
        public async Task<ActionResult> DeleteCart(string cartId)
        {
            ActionResult response = await _mediator.Send(new DeleteCartCommand() { CartId = cartId });

            return response;
        }
    }
}
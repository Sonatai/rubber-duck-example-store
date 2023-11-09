using API.Commands.Login;
using API.Commands.Register;
using API.DataAccess;
using API.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/")]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly UserService _userService;

        public UserController(IMediator mediator, UserService userService)
        {
            _mediator = mediator;
            _userService = userService;
        }

        [HttpPost("/register")]
        public async Task<ActionResult<UserResponseDto>> RegisterUser([FromBody] UserRequestDto userDto)
        {
            ActionResult<UserResponseDto> response = await _mediator.Send(new RegisterCommand() { User = userDto });

            return response;
        }

        [HttpPost("/login")]
        public async Task<ActionResult<UserResponseDto>> LoginUser([FromBody] UserRequestDto userDto)
        {

            ActionResult<UserResponseDto> response = await _mediator.Send(new LoginCommand() { User = userDto });

            return response;
        }
    }
}
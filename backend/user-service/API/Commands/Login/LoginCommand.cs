using API.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Commands.Login
{
    public class LoginCommand : IRequest<ActionResult<UserResponseDto>>
    {
        public UserRequestDto User { get; set; }
    }
}

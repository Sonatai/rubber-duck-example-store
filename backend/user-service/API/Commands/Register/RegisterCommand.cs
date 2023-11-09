using API.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Commands.Register
{
    public class RegisterCommand : IRequest<ActionResult<UserResponseDto>>
    {
        public UserRequestDto User { get; set; }
    }
}

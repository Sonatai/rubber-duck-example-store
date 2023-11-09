using API.Commands.Register;
using API.DTOs;
using AutoMapper;
using BCrypt.Net;
using Core;
using DataAccess;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ActionResult<UserResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        private readonly ILogger<RegisterCommand> _logger;

        public LoginCommandHandler(IMapper mapper, UserService userService, ILogger<RegisterCommand> logger)
        {
            _mapper = mapper;
            _userService = userService;
            _logger = logger;
        }

        public async Task<ActionResult<UserResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User? user = await _userService.GetAsync(request.User.Name);

                if (user == null)
                {
                    return new UnprocessableEntityObjectResult("user doesn't exists");
                }
                if (BCrypt.Net.BCrypt.EnhancedVerify(request.User.Password, user.Password, hashType: HashType.SHA384))
                {
                    return new UnprocessableEntityObjectResult("login data are false");
                }

                return new OkObjectResult(_mapper.Map<UserResponseDto>(user));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new BadRequestObjectResult(ex);
            }
        }
    }
}

using API.DTOs;
using AutoMapper;
using Core;
using DataAccess;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ActionResult<UserResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        private readonly ILogger<RegisterCommand> _logger;

        public RegisterCommandHandler(IMapper mapper, UserService userService, ILogger<RegisterCommand> logger)
        {
            _mapper = mapper;
            _userService = userService;
            _logger = logger;
        }

        public async Task<ActionResult<UserResponseDto>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = new(null, request.User.Name, request.User.Password);
                bool userExists = await DoesUserExist(user.Name);
                if (userExists)
                {
                    return new UnprocessableEntityObjectResult("user exists");
                }

                User? newUser = await _userService.CreateAsync(user);

                return new OkObjectResult(_mapper.Map<UserResponseDto>(newUser));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new BadRequestObjectResult(ex);
            }
        }

        private async Task<bool> DoesUserExist(string userName)
        {
            User? user = await _userService.GetAsync(userName);

            return user != null;
        }
    }
}

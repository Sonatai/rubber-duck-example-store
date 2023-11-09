using API.CoreModels;
using API.DataAccess;
using API.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Commands.CreateCart
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommand, ActionResult<CartResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly CartsService _cartsService;
        private readonly ILogger<CreateCartCommand> _logger;

        public CreateCartCommandHandler(IMapper mapper, CartsService cartsService, ILogger<CreateCartCommand> logger)
        {
            _mapper = mapper;
            _cartsService = cartsService;
            _logger = logger;
        }

        public async Task<ActionResult<CartResponseDto>> Handle(CreateCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Cart newCart = _mapper.Map<Cart>(request.Cart);

                Cart cart = await _cartsService.CreateAsync(newCart);

                return new OkObjectResult(_mapper.Map<CartResponseDto>(cart));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new BadRequestObjectResult(ex);
            }
        }
    }
}

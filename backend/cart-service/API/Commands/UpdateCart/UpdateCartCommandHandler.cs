using API.Commands.CreateCart;
using AutoMapper;
using Core;
using DataAccess;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Commands.UpdateCart
{
    public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand, ActionResult>
    {
        private readonly IMapper _mapper;
        private readonly CartsService _cartsService;
        private readonly ILogger<CreateCartCommand> _logger;

        public UpdateCartCommandHandler(IMapper mapper, CartsService cartsService, ILogger<CreateCartCommand> logger)
        {
            _mapper = mapper;
            _cartsService = cartsService;
            _logger = logger;
        }

        public async Task<ActionResult> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Cart newCart = _mapper.Map<Cart>(request.Cart);

                await _cartsService.UpdateAsync(request.Cart.DomainId, newCart);

                return new NoContentResult();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new BadRequestObjectResult(ex);
            }
        }
    }
}

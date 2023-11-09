using API.Commands.CreateCart;
using API.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Commands.DeleteCart
{
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommand, ActionResult>
    {
        private readonly CartsService _cartsService;
        private readonly ILogger<CreateCartCommand> _logger;

        public DeleteCartCommandHandler(CartsService cartsService, ILogger<CreateCartCommand> logger)
        {
            _cartsService = cartsService;
            _logger = logger;
        }

        public async Task<ActionResult> Handle(DeleteCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _cartsService.RemoveAsync(request.CartId);

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

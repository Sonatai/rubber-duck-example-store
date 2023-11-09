using API.DTOs;
using AutoMapper;
using Core;
using DataAccess;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Queries.GetCart
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQuery, ActionResult<CartResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly CartsService _cartsService;
        private readonly ILogger<GetCartQuery> _logger;

        public GetCartQueryHandler(IMapper mapper, CartsService cartsService, ILogger<GetCartQuery> logger)
        {
            _mapper = mapper;
            _cartsService = cartsService;
            _logger = logger;
        }

        public async Task<ActionResult<CartResponseDto>> Handle(GetCartQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Cart? cart = await _cartsService.GetAsync(request.CartId);

                if (cart == null)
                {
                    return new NoContentResult();
                }

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

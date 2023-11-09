using API.DTOs;
using AutoMapper;
using Core;
using DataAccess;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Queries.GetCartByUserId
{
    public class GetCartByUserIdQueryHandler : IRequestHandler<GetCartByUserIdQuery, ActionResult<CartResponseDto>>
    {
        private readonly IMapper _mapper;
        private readonly CartsService _cartsService;
        private readonly ILogger<GetCartByUserIdQuery> _logger;

        public GetCartByUserIdQueryHandler(IMapper mapper, CartsService cartsService, ILogger<GetCartByUserIdQuery> logger)
        {
            _mapper = mapper;
            _cartsService = cartsService;
            _logger = logger;
        }

        public async Task<ActionResult<CartResponseDto>> Handle(GetCartByUserIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                Cart? cart = await _cartsService.GetByUserIdAsync(request.UserId);

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

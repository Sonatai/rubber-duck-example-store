using Core;
using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/")]
    public class CartController : ControllerBase
    {
        private readonly CartsService _cartsService;
        public CartController(CartsService cartsService)
        {
            _cartsService = cartsService;
        }

        [HttpPost("/cart")]
        public async Task<ActionResult> CreateCart()
        {
            Cart newCart = new(null, "1234", new List<SelectedProduct>());
            await _cartsService.CreateAsync(newCart);

            Cart? what = await _cartsService.GetByUserIdAsync(newCart.UserId);

            return NoContent();
        }
    }
}
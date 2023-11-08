using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/")]
    public class CartController : ControllerBase
    {

        [HttpPost("/cart")]
        public ActionResult CreateCart()
        {
            return NoContent();
        }
    }
}
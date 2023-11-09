using DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/")]
    public class UserController : ControllerBase
    {

        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/register")]
        public async Task<ActionResult> RegisterUser()
        {
            await _userService.CreateAsync(new Core.User("Test", "1234"));

            return NoContent();
        }

        [HttpPost("/login")]
        public async Task<ActionResult> LoginUser()
        {
            await _userService.CreateAsync(new Core.User("Test", "1234"));

            return NoContent();
        }
    }
}
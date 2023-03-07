using GolfClappServiceLibrary.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace GolfClappApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        

        [HttpGet]
        public ActionResult GetUserById(string userId)
        {
            var id = Guid.Parse(userId);
            return Ok(_userService.GetUserById(id));
        }
    }
}
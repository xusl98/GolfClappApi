using GolfClappServiceLibrary.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using ObjectsLibrary.DTOs;

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

        

        [HttpGet("GetUserById")]
        public ActionResult GetUserById(string userId)
        {
            var id = Guid.Parse(userId);
            return Ok(_userService.GetUserById(id));
        }

        [HttpPost("Register")]
        public ActionResult Register(string name, string surname, string password, string email, int phone, string country, string? license)
        {            
            var user = new UserDTO()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Surname = surname,
                Password = password,
                Email = email,
                Phone = phone,
                Country = country,
                License = license
            };
            return Ok(_userService.Save(user));
        }
    }
}
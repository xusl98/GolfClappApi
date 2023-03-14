using GolfClappServiceLibrary.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using ObjectsLibrary.DTOs;

namespace GolfClappApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase    
    {
        private readonly IAccountService _accountService;



        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [HttpPost("Register")]
        public ActionResult Register(string name, string userName, string surname, string password, string email, int phone, string country, string? license)
        {
            var user = new UserDTO()
            {
                Id = Guid.NewGuid(),
                UserName = userName,
                Name = name,
                Surname = surname,
                Password = password,
                Email = email,
                Phone = phone,
                Country = country,
                License = license
            };
            return Ok(_accountService.Register(user));
        }


    }
}

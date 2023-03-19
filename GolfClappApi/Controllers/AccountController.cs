using GolfClappServiceLibrary.ServiceInterfaces;
using GolfClappServiceLibrary.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ObjectsLibrary.Authentication;
using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;

namespace GolfClappApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase    
    {
        private readonly JwtService _jwtService;
        private readonly IAccountService _accountService;
        private readonly UserManager<UserEntity> _userManager;



        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService, JwtService jwtService, UserManager<UserEntity> userManager)
        {
            _logger = logger;
            _accountService = accountService;
            _jwtService = jwtService;
            _userManager = userManager;
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
                PhoneNumber = phone,
                Country = country,
                License = license
            };
            return Ok(_accountService.Register(user));
        }

        
        [HttpPost("Login")]
        public async Task<ActionResult<AuthenticationResponse>> Login(AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad credentials");
            }
            //TODO Ask if login will be required with username email or both
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var response = new AuthenticationResponse()
            {
                Token = user.UserApiKey
            };

            return Ok(response);
        }

        //Login with jwt token (has expiration)
        //[Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},ApiKey")]
        //[HttpPost("Login")]
        //public async Task<ActionResult<AuthenticationResponse>> Login(AuthenticationRequest request)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest("Bad credentials");
        //    }

        //    var user = await _userManager.FindByNameAsync(request.UserName);

        //    if (user == null)
        //    {
        //        return BadRequest("Bad credentials");
        //    }

        //    var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

        //    if (!isPasswordValid)
        //    {
        //        return BadRequest("Bad credentials");
        //    }
        //    var identityUser = new IdentityUser()
        //    {
        //        Id = user.Id.ToString(),
        //        AccessFailedCount = user.AccessFailedCount,
        //        ConcurrencyStamp = user.ConcurrencyStamp,
        //        Email = user.Email,
        //        PhoneNumber = user.PhoneNumber,
        //        EmailConfirmed = user.EmailConfirmed,
        //        LockoutEnabled = user.LockoutEnabled,
        //        LockoutEnd = user.LockoutEnd,
        //        NormalizedEmail = user.NormalizedEmail,
        //        NormalizedUserName = user.NormalizedUserName,
        //        PasswordHash = user.PasswordHash,
        //        PhoneNumberConfirmed = user.PhoneNumberConfirmed,
        //        SecurityStamp = user.SecurityStamp,
        //        TwoFactorEnabled = user.TwoFactorEnabled,
        //        UserName = user.UserName
        //    };

        //    var token = _jwtService.CreateToken(identityUser);

        //    return Ok(token);
        //}


    }
}

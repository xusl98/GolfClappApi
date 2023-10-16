using GolfClappServiceLibrary.ServiceInterfaces;
using GolfClappServiceLibrary.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ObjectsLibrary.Authentication;
using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;
using System.Dynamic;

namespace GolfClappApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly UserManager<UserEntity> _userManager;



        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService, JwtService jwtService, 
            UserManager<UserEntity> userManager, IUserService userService)
        {
            _logger = logger;
            _accountService = accountService;
            _userService = userService;
            _jwtService = jwtService;
            _userManager = userManager;
        }


        [HttpPost("Register")]
        public async Task<ObjectResponseDTO> RegisterAsync(string name, string userName, string surname, string password, string email, string phone, string country, bool googleSignIn, string? license)
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
                License = license,
                GoogleSignIn = googleSignIn
            };
            var response = new ObjectResponseDTO();
            response.StatusCode = 200;
            response.Body = await _accountService.Register(user);            
            return response;
        }


        [HttpPost("Login")]
        public async Task<ActionResult<CustomAuthenticationResponse>> Login(AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad credentials");
            }
            //TODO Ask if login will be required with username email or both
            var user = await _userManager.FindByEmailAsync(request.UserName);

            if (user == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var response = new CustomAuthenticationResponse()
            {
                IsSuccess = true,
                ApiKey = user.UserApiKey,
                User = user
            };

            return Ok(response);
        }

        [HttpPost("GetUserApiKeyByEmail")]
        public async Task<ActionResult<string>> GetUserApiKeyByEmail(string email)
        {
            var response = new CustomAuthenticationResponse();
            try
            {
                var apiKey = _accountService.GetUserAPiKeyByEmail(email);
                var user = await _userManager.FindByEmailAsync(email);
                
                response.IsSuccess = true;
                response.ApiKey = user.UserApiKey;
                response.User = user;
            } catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("UpdatePassword")]
        public async Task<ActionResult<CustomAuthenticationResponse>> UpdatePassword([FromBody] AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad credentials");
            }
            //TODO Ask if login will be required with username email or both
            var user = await _userManager.FindByEmailAsync(request.UserName);

            if (user == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var response = await _accountService.UpdatePassword(user.UserName, request.Password, request.NewPassword);

            

            return Ok(response);
        }


        [Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},ApiKey")]
        [HttpPost("UpdateName")]
        public async Task<ActionResult<CustomAuthenticationResponse>> UpdateName([FromBody] UserUpdateObject uNameObject)
        {            
            try
            {
                string apiKey = HttpContext.Request.Headers["Api-Key"];
                _userService.EditUserValues(uNameObject, apiKey);
                return Ok(uNameObject);
            }
            catch (Exception ex)
            {                
                return BadRequest();
            }


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

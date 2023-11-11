using GolfClappServiceLibrary.ServiceInterfaces;
using GolfClappServiceLibrary.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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


        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},ApiKey")]
        [HttpGet("GetUserById")]
        public ActionResult GetUserById(string userId)
        {
            var id = Guid.Parse(userId);
            return Ok(_userService.GetUserById(id));
        }




        [Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},ApiKey")]
        [HttpPost("GetUsersByNameFilter")]
        public ObjectResponseDTO GetUsersByNameFilter([FromBody] string nameFilter)
        {
            var responseObject = new ObjectResponseDTO();
            try
            {
                string apiKey = HttpContext.Request.Headers["Api-Key"];
                UserDTO user = _userService.GetUserByApiKey(apiKey);
                var respObject = new GetUsersResponseDTO();
                respObject.Users = _userService.GetUsersByNameFilter(user.Id, nameFilter);



                responseObject.StatusCode = 200;

                responseObject.Body = respObject;
                return responseObject;

            }
            catch (Exception ex)
            {
                responseObject.Message = ex.Message;
                return responseObject;
            }
        }


    }


    public class GetUsersResponseDTO
    {
        public List<UserDTO> Users { get; set; }
    }
}
using GolfClappServiceLibrary.ServiceInterfaces;
using GolfClappServiceLibrary.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;
using System.Globalization;

namespace GolfClappApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FriendshipController : ControllerBase
    {


        private readonly ILogService _logger;
        private readonly IFriendshipManagementService _friendshipManagementService;
        private readonly IUserService _userService;


        public FriendshipController(
            ILogService logger, IFriendshipManagementService friendshipManagementService, IUserService userService
            )
        {
            _logger = logger;
            _friendshipManagementService = friendshipManagementService;
            _userService = userService;
        }

        //[Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},ApiKey")]
        //[HttpGet("GetFriendRequests")]
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        string apiKey = HttpContext.Request.Headers["Api-Key"];
        //        UserDTO user = _userService.GetUserByApiKey(apiKey);
        //        return Ok(_courseService.Get());
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.SaveErrorLog(ex.Message);
        //        return BadRequest();
        //    }
        //}
        [Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},ApiKey")]
        [HttpGet("GetFriendRequests")]
        public async Task<ObjectResponseDTO> GetFriendRequests()
        {

            var responseObject = new ObjectResponseDTO();
            try
            {
                string apiKey = HttpContext.Request.Headers["Api-Key"];
                UserDTO user = _userService.GetUserByApiKey(apiKey);
                var response = _friendshipManagementService.GetFriendRequests(user.Id);

                responseObject.StatusCode = 200;

                responseObject.Body = response;
                return responseObject;

            }
            catch (Exception ex)
            {
                responseObject.Message = ex.Message;
                return responseObject;
            }

        }

        [Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},ApiKey")]
        [HttpPost("GetFriends")]
        public async Task<ObjectResponseDTO> GetFriends([FromBody] string nameFilter)
        {

            var responseObject = new ObjectResponseDTO();
            try
            {
                string apiKey = HttpContext.Request.Headers["Api-Key"];
                UserDTO user = _userService.GetUserByApiKey(apiKey);
                var respObject = new GetFriendsResponseDTO();
                respObject.Friends = _friendshipManagementService.GetFriends(user.Id, nameFilter);



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



        [Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},ApiKey")]
        [HttpPost("SendFriendRequest")]
        public IActionResult SendFriendRequest([FromBody] Guid userId)
        {
            try
            {
                string apiKey = HttpContext.Request.Headers["Api-Key"];
                UserDTO user = _userService.GetUserByApiKey(apiKey);

                _friendshipManagementService.SendRequest(user.Id, userId);

                return Ok("Request sent successfully.");



            }
            catch (Exception ex)
            {
                _logger.SaveErrorLog(ex.Message);
                return BadRequest(ex.Message);
            }
        }

    }

    public class GetFriendsResponseDTO
    {
        public List<UserDTO> Friends { get; set; }
    }





}

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
        [HttpPost("GetReceivedRequests")]
        public async Task<ObjectResponseDTO> GetReceivedRequests()
        {

            var responseObject = new ObjectResponseDTO();
            try
            {
                string apiKey = HttpContext.Request.Headers["Api-Key"];
                UserDTO user = _userService.GetUserByApiKey(apiKey);
                var respObject = new GetFriendRequestsResponseDTO();
                respObject.FriendRequests = _friendshipManagementService.GetReceivedRequests(user.Id);



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
        [HttpPost("GetSentRequests")]
        public async Task<ObjectResponseDTO> GetSentRequests()
        {

            var responseObject = new ObjectResponseDTO();
            try
            {
                string apiKey = HttpContext.Request.Headers["Api-Key"];
                UserDTO user = _userService.GetUserByApiKey(apiKey);
                var respObject = new GetFriendRequestsResponseDTO();
                respObject.FriendRequests = _friendshipManagementService.GetSentRequests(user.Id);



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

        [Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},ApiKey")]
        [HttpPost("AcceptFriendRequest")]
        public IActionResult AcceptFriendRequest([FromBody] Guid friendRequestId)
        {
            try
            {
                

                _friendshipManagementService.AcceptFriendRequest(friendRequestId);

                return Ok("Request sent successfully.");



            }
            catch (Exception ex)
            {
                _logger.SaveErrorLog(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},ApiKey")]
        [HttpPost("DeclineFriendRequest")]
        public IActionResult DeclineFriendRequest([FromBody] Guid friendRequestId)
        {
            try
            {
                

                _friendshipManagementService.DeclineFriendRequest(friendRequestId);

                return Ok("Request sent successfully.");



            }
            catch (Exception ex)
            {
                _logger.SaveErrorLog(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},ApiKey")]
        [HttpPost("RemoveFriend")]
        public IActionResult RemoveFriend([FromBody] Guid friendUserId)
        {
            try
            {

                string apiKey = HttpContext.Request.Headers["Api-Key"];
                UserDTO user = _userService.GetUserByApiKey(apiKey);

                _friendshipManagementService.RemoveFriend(user.Id, friendUserId);

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
    public class GetFriendRequestsResponseDTO
    {
        public List<FriendshipRequestDTO> FriendRequests { get; set; }
    }





}

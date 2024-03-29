﻿using GolfClappServiceLibrary.ServiceInterfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Newtonsoft.Json;
using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;
using System.Dynamic;
using System.Globalization;
using System.Transactions;

namespace GolfClappApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {

        private readonly IGameService _gameService;
        private readonly IGameUserService _gameUserService;
        private readonly IUserService _userService;
        private readonly ILogService _logger;

        public GameController(ILogService logger, IGameService gameService, IGameUserService gameUserService, IUserService userService)
        {
            _logger = logger;
            _gameService = gameService;
            _gameUserService = gameUserService;
            _userService = userService;
        }

        [Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},ApiKey")]
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_gameService.Get());
            }
            catch (Exception ex)
            {
                _logger.SaveErrorLog(ex.Message);
                return BadRequest();
            }
        }

        [Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},ApiKey")]
        [HttpGet("GetById/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                return Ok(_gameService.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.SaveErrorLog(ex.Message);
                return BadRequest();
            }
        }

        [Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},ApiKey")]
        [HttpPost("Save")]
        public IActionResult Save([FromBody] GameDTO game)
        {
            try
            {
                return Ok(_gameService.Save(game));
            }
            catch (Exception ex)
            {
                _logger.SaveErrorLog(ex.Message);
                return BadRequest();
            }
        }

        [Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},ApiKey")]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                return Ok(_gameService.Remove(id));
            }
            catch (Exception ex)
            {
                _logger.SaveErrorLog(ex.Message);
                return BadRequest();
            }
        }

        [Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},ApiKey")]
        [HttpPost("SaveAndAddUser")]
        public IActionResult SaveAndAddUser([FromBody] SaveAndAddUserRequestDTO saveAndAddUserRequestDTO)
        {
            try
            {
                string apiKey = HttpContext.Request.Headers["Api-Key"];
                UserDTO user =  _userService.GetUserByApiKey(apiKey);
                //using (var scope = new TransactionScope())
                //{

                var settings = new JsonSerializerSettings
                {
                    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
                };

                DateTime.TryParseExact(saveAndAddUserRequestDTO.Date, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result);
                        var game = _gameService.Save(new GameDTO()
                        {
                            Id = Guid.NewGuid(),                            
                            CourseName = saveAndAddUserRequestDTO.CourseName,
                            Date = result,
                            Location = saveAndAddUserRequestDTO.Location,
                            Price = saveAndAddUserRequestDTO.Price,
                            ProviderCourseId = saveAndAddUserRequestDTO.ProviderCourseId,
                            PackageCombination = Newtonsoft.Json.JsonConvert.SerializeObject(saveAndAddUserRequestDTO.PackageCombination, settings),
                            CreatorUserClientSecret = saveAndAddUserRequestDTO.CreatorUserClientSecret,
                            NumberOfPlayers = saveAndAddUserRequestDTO.NumberOfPlayers,
                            Creator = user.Id,
                            
                            //TODO fill up fullyPaid param
                        });

                        _gameUserService.Save(saveAndAddUserRequestDTO.UsersIds, game.Id, user.Id, saveAndAddUserRequestDTO.PayedUsersIds, saveAndAddUserRequestDTO.NonUserPlayers, saveAndAddUserRequestDTO.PricePerPart);


                        //scope.Complete();
                        return Ok("Data saved successfully.");
                   
                //}
                
            }
            catch (Exception ex)
            {
                _logger.SaveErrorLog(ex.Message);
                return BadRequest();
            }
        }

        [Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},ApiKey")]
        [HttpPost("GetByDate")]
        public async Task<ObjectResponseDTO> GetByDate([FromBody] GetByDateRequestDTO request)
        {
            var responseObject = new ObjectResponseDTO();
            try
            {
                var isGuid = Guid.TryParse(request.UserId, out var idGuid);
                Guid userId;
                if (request.UserId != null && isGuid)
                {
                    userId = idGuid;
                }
                else
                {
                    string apiKey = HttpContext.Request.Headers["Api-Key"];
                    UserDTO user = _userService.GetUserByApiKey(apiKey);
                    userId = user.Id;
                }
                

                var resp = new GetByDateResponseDTO();
                resp.Bookings = _gameService.GetByDate(request.Date, request.OlderBookings, userId, request.OnlyWhenInvitedAndNotPayed);
                responseObject.StatusCode = 200;
                responseObject.Body = resp;
                return responseObject;
            }
            catch (Exception ex)
            {
                _logger.SaveErrorLog(ex.Message);
                return null;
            }
        }


        //[Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},ApiKey")]
        [HttpGet("GetUsersByGameId/{gameId}")]
        public IActionResult GetUsersByGameId(Guid gameId)
        {
            try
            {
                var gameUsers = _gameUserService.GetGameUsersByGameId(gameId);
                List<UserDTO> users = new List<UserDTO>();
                foreach ( var gameUser in gameUsers )
                {
                    users.Add(_userService.GetUserById(gameUser.UserId));
                }
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.SaveErrorLog(ex.Message);
                return BadRequest();
            }
        }




    }

    public class GetByDateRequestDTO
    {
        public DateTime Date { get; set; }
        public bool OlderBookings { get; set; }
        public String UserId { get; set; }
        public bool OnlyWhenInvitedAndNotPayed { get; set; }
    }
    public class GetByDateResponseDTO
    {
        public List<GameDTO> Bookings { get; set; }
    }
}
﻿using GolfClappServiceLibrary.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;

namespace GolfClappApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {

        private readonly IGameService _gameService;
        private readonly ILogService _logger;

        public GameController(ILogService logger, IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

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
        [HttpGet("GetById/{id}")]
        public IActionResult Get(Guid id)
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




    }
}
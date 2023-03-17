using GolfClappServiceLibrary.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;

namespace GolfClappApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameUserController : ControllerBase
    {

        private readonly IGameUserService _gameUserService;
        private readonly ILogService _logger;

        public GameUserController(ILogService logger, IGameUserService gameUserService)
        {
            _logger = logger;
            _gameUserService = gameUserService;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_gameUserService.Get());
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
                return Ok(_gameUserService.Get());
            }
            catch (Exception ex)
            {
                _logger.SaveErrorLog(ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("Save")]
        public IActionResult Save([FromBody] GameUserDTO gameUser)
        {
            try
            {
                return Ok(_gameUserService.Save(gameUser));
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
                return Ok(_gameUserService.Remove(id));
            }
            catch (Exception ex)
            {
                _logger.SaveErrorLog(ex.Message);
                return BadRequest();
            }
        }




    }
}
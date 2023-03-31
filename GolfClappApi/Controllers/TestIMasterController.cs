using GolfClappServiceLibrary.ServiceInterfaces;
using GolfClappServiceLibrary.Services;
using iMasterLibrary.ServiceInterfaces;
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
    public class TestIMasterController : ControllerBase    
    {
        private readonly IIMasterAccessService _iMasterAccessService;



        private readonly ILogger<AccountController> _logger;

        public TestIMasterController(ILogger<AccountController> logger, IIMasterAccessService iMasterAccessService)
        {
            _logger = logger;
            _iMasterAccessService = iMasterAccessService;
        }

       
        [HttpPost("GetSessionData")]
        public ActionResult GetSessionData()
        {
            try
            {
                var a = _iMasterAccessService.GetSessionData();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        
        


    }
}

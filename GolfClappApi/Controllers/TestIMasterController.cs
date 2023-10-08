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
        private readonly IIMasterProviderService _iMasterProviderService;



        private readonly ILogger<AccountController> _logger;

        public TestIMasterController(ILogger<AccountController> logger, IIMasterAccessService iMasterAccessService, IIMasterProviderService iMasterProviderService)
        {
            _logger = logger;
            _iMasterAccessService = iMasterAccessService;
            _iMasterProviderService = iMasterProviderService;
        }

       
        [HttpPost("GetSessionData")]
        public ActionResult GetSessionData()
        {
            try
            {
                //TODO look into storing sessionData (Check if it expires, if it does make handler to retrieve it everytime it does)
                var response = _iMasterAccessService.GetSessionData("golfclapp@outlook.com", "654321", 99999, "ES-es");
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        //[HttpPost("GetProviderCourses")]
        //public ActionResult GetProviderCourses()
        //{
        //    try
        //    {
        //        var response = _iMasterAccessService.GetSessionData("golfclapp@outlook.com", "654321", 99999, "ES-es");
        //        var a = _iMasterProviderService.GetProvidersWithCourses(response.Result.data.VendorID, response.Result.data.SessionID, response.Result.data.AccessToken, "ES-es");
        //        return Ok(a);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
           
        //}

        
        


    }
}

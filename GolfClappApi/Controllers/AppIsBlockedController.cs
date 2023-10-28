using GolfClappServiceLibrary.ServiceInterfaces;
using GolfClappServiceLibrary.Services;
using iMasterLibrary.ServiceInterfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;

namespace GolfClappApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppIsBlockedController : ControllerBase
    {

        private readonly IAppIsBlockedService _appIsBlockedService;
        private readonly ILogService _logger;


        public AppIsBlockedController(
            ILogService logger, IAppIsBlockedService appIsBlockedService)
        {
            _logger = logger;
            _appIsBlockedService = appIsBlockedService;
        }

        
        [HttpGet("Get")]
        public ObjectResponseDTO Get()
        {
            var responseObject = new ObjectResponseDTO();
            try
            {
                responseObject.StatusCode = 200;
                responseObject.Body = _appIsBlockedService.Get();
                return responseObject;
            }
            catch (Exception ex)
            {
                _logger.SaveErrorLog(ex.Message);
                responseObject.Message = ex.Message;
                return responseObject;
            }
        }



    }
    
}
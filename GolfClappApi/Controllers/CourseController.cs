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
    public class CourseController : ControllerBase
    {

        private readonly ICourseService _courseService;
        private readonly ILogService _logger;

        private readonly IIMasterAccessService _iMasterAccessService;
        private readonly IIMasterProviderService _iMasterProviderService;
        private readonly IIMasterDayAvailabilityService _iMasterDayAvailabilityService;

        public CourseController(
            ILogService logger, ICourseService courseService, IIMasterAccessService iMasterAccessService, IIMasterProviderService iMasterProviderService,
            IIMasterDayAvailabilityService iMasterDayAvailabilityService
            )
        {
            _logger = logger;
            _courseService = courseService;

            _iMasterAccessService = iMasterAccessService;
            _iMasterProviderService = iMasterProviderService;
            _iMasterDayAvailabilityService = iMasterDayAvailabilityService;
        }

        [Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},ApiKey")]
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_courseService.Get());
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
                return Ok(_courseService.Get());
            }
            catch (Exception ex)
            {
                _logger.SaveErrorLog(ex.Message);
                return BadRequest();
            }
        }

        [Authorize(AuthenticationSchemes = $"{JwtBearerDefaults.AuthenticationScheme},ApiKey")]
        [HttpPost("Save")]
        public IActionResult Save([FromBody] CourseDTO course)
        {
            try
            {
                return Ok(_courseService.Save(course));
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
                return Ok(_courseService.Remove(id));
            }
            catch (Exception ex)
            {
                _logger.SaveErrorLog(ex.Message);
                return BadRequest();
            }
        }


        [HttpPost("GetProviderCourses")]
        public async Task<ObjectResponseDTO> GetProviderCoursesAsync([FromBody] ProviderCoursesCallData providerCoursesCallData)
        {

            var responseObject = new ObjectResponseDTO();
            try
            {
                var response = _iMasterAccessService.GetSessionData("golfclapp@outlook.com", "654321", 99999, "ES-es");


                responseObject.StatusCode = 200;
                var providers = await _iMasterProviderService.GetProvidersWithCourses(response.Result.data.VendorID, response.Result.data.SessionID, response.Result.data.AccessToken, "ES-es", providerCoursesCallData.PlayDate, providerCoursesCallData.FromTime,
                    providerCoursesCallData.ToTime, providerCoursesCallData.Players, providerCoursesCallData.FromPrice, providerCoursesCallData.ToPrice, providerCoursesCallData.PageSize, providerCoursesCallData.PageNum);
                foreach (var p in providers.ProvidersList)
                {
                    foreach (var c in p.Courses)
                    {
                        var course = _courseService.GetByImasterId(int.Parse(c.CourseID));
                        if (course != null)
                        {
                            c.ImageUrl = (course.ImageUrl != null && course.ImageUrl != "") ? course.ImageUrl : "";
                            c.LocationString = (course.LocationString != null && course.LocationString != "") ? course.LocationString : "";
                               
                        }
                        else
                        {
                            c.ImageUrl = "";
                            c.LocationString = "";
                        }
                    }
                }
                responseObject.Body = providers;
                return responseObject;
                
            }
            catch (Exception ex)
            {
                responseObject.Message = ex.Message;
                return responseObject;
            }

        }

        
        
        [HttpPost("GetDayAvailability")]
        public async Task<ObjectResponseDTO> GetDayAvailability([FromBody] DayAvailabilityCallData dayAvailabilityCallData)
        {

            var responseObject = new ObjectResponseDTO();
            try
            {
                var response = _iMasterAccessService.GetSessionData("golfclapp@outlook.com", "654321", 99999, "ES-es");
                

                responseObject.StatusCode = 200;
                responseObject.Body = await _iMasterDayAvailabilityService.GetDayAvailability(
                    response.Result.data.VendorID, dayAvailabilityCallData.ProviderID, dayAvailabilityCallData.TourOperatorID, response.Result.data.SessionID,
                    response.Result.data.AccessToken, "ES-es", dayAvailabilityCallData.CourseID, dayAvailabilityCallData.PlayDate, dayAvailabilityCallData.FromTime,
                    dayAvailabilityCallData.ToTime, dayAvailabilityCallData.Players, dayAvailabilityCallData.FromPrice, dayAvailabilityCallData.ToPrice,
                    dayAvailabilityCallData.PageSize, dayAvailabilityCallData.PageNum, dayAvailabilityCallData.PromoCode
                    
                    );
                //responseObject.Body = await _iMasterProviderService.GetProvidersWithCourses(response.Result.data.VendorID, response.Result.data.SessionID, response.Result.data.AccessToken, "ES-es");
                return responseObject;
                
            }
            catch (Exception ex)
            {
                responseObject.Message = ex.Message;
                return responseObject;
            }

        }




    }
    public class DayAvailabilityCallData
    {
        public int TourOperatorID { get; set; }
        public int ProviderID { get; set; }
        public int CourseID { get; set; }
        public string PlayDate { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public int Players { get; set; }
        public int FromPrice { get; set; }
        public int ToPrice { get; set; }
        public int PageSize { get; set; }
        public int PageNum { get; set; }
        public string PromoCode { get; set; }
    }
    public class ProviderCoursesCallData
    {
        public string PlayDate { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public int Players { get; set; }
        public int FromPrice { get; set; }
        public int ToPrice { get; set; }
        public int PageSize { get; set; }
        public int PageNum { get; set; }
    }
}
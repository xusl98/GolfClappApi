using GolfClappServiceLibrary.ServiceInterfaces;
using GolfClappServiceLibrary.Services;
using iMasterLibrary.Objects;
using iMasterLibrary.ServiceInterfaces;
using iMasterLibrary.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;

namespace GolfClappApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {

        private readonly IIMasterAccessService _iMasterAccessService;
        private readonly IIMasterBookService _iMasterBookService;
        private readonly ILogService _logger;


        public BookController(
            ILogService logger, IIMasterAccessService iMasterAccessService, IIMasterBookService iMasterBookService)
        {
            _logger = logger;
            _iMasterAccessService = iMasterAccessService;
            _iMasterBookService = iMasterBookService;
        }


        [HttpPost("BookGame")]
        public async Task<ObjectResponseDTO> BookGame([FromBody] IMasterPreBookingRequestDTO pbr)
        {

            var responseObject = new ObjectResponseDTO();
            try
            {
                var response = await _iMasterAccessService.GetSessionData("golfclapp@outlook.com", "654321", 99999, "ES-es");

                pbr.VendorID = response.data.VendorID;
                pbr.SessionID = response.data.SessionID;
                pbr.AccessToken = response.data.AccessToken;

                var result = await _iMasterBookService.PreBook(pbr);


                var bcr = new IMasterBookingConfirmationRequestDTO
                {
                    AccessToken = pbr.AccessToken,
                    Culture = pbr.Culture,
                    SessionID = pbr.SessionID,
                    VendorID = pbr.VendorID,
                    OrderRef = result.OrderReference
                };


                var confirmResult = await _iMasterBookService.ConfirmBook(bcr);


                return null;
            }
            catch (Exception ex)
            {
                responseObject.Message = ex.Message;
                return responseObject;
            }

        }



    }

    

}
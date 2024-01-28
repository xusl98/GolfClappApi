
using iMasterLibrary.Objects;
using iMasterLibrary.ServiceInterfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMasterLibrary.Services
{
    public class IMasterBookService : IIMasterBookService
    {
        public readonly HttpClient _httpClient;
        public IMasterBookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IMasterPreBookingResponseData> PreBook(
            IMasterPreBookingRequestDTO br
            )
        {            
            

            // Serialize the data to JSON
            string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(br);

            // Create a StringContent with JSON content and specify the content type
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var result = _httpClient.PostAsync(IMasterSessionData.ConnectionString + "/PreBooking/PreBookingRequest", content).Result;
            if (result.IsSuccessStatusCode)
            {
                var responseContent = await result.Content.ReadAsStringAsync();
                //var responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<IMasterProviderCoursesResponseData>(responseContent);
                IMasterPreBookingResponseDTO responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<IMasterPreBookingResponseDTO>(responseContent);
                IMasterPreBookingResponseData r = responseData.Data;
                return r;
            }
            else
            {
                throw new Exception("Error getting iMaster connection authorization");
            }
        }

        public async Task<int> ConfirmBook(
            IMasterBookingConfirmationRequestDTO bcr
            )
        {


            // Serialize the data to JSON
            string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(bcr);

            // Create a StringContent with JSON content and specify the content type
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var result = _httpClient.PostAsync(IMasterSessionData.ConnectionString + "/Booking/BookingConfirmationRequest", content).Result;
            if (result.IsSuccessStatusCode)
            {
                var responseContent = await result.Content.ReadAsStringAsync();
                //var responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<IMasterProviderCoursesResponseData>(responseContent);
                IMasterBookingConfirmationResponseDTO responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<IMasterBookingConfirmationResponseDTO>(responseContent);
                
                return responseData.Code;
            }
            else
            {
                throw new Exception("Error getting iMaster connection authorization");
            }
        }
    }
}


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
    public class IMasterDayAvailabilityService : IIMasterDayAvailabilityService
    {
        public readonly HttpClient _httpClient;
        public IMasterDayAvailabilityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IMasterDayAvailabilityResponseData> GetDayAvailability(
            int vendorId, int providerId, int tourOperatorId, int sessionId,
            string accessToken, string culture, int courseId, string playDate,
            string fromTime, string toTime, int players, int fromPrice,
            int toPrice, int pageSize, int pageNum, string promoCode
            )
        {            
            var requestData = new
            {
                vendorId = vendorId,
                providerId = providerId,
                tourOperatorId = tourOperatorId,
                sessionId = sessionId,
                accessToken = accessToken,
                culture = culture,
                courseId = courseId,
                playDate = playDate,
                fromTime = fromTime,
                toTime = toTime,
                players = players,
                fromPrice = fromPrice,
                toPrice = toPrice,
                pageSize = pageSize,
                pageNum = pageNum,
                promoCode = promoCode
            };

            // Serialize the data to JSON
            string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);

            // Create a StringContent with JSON content and specify the content type
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var result = _httpClient.PostAsync(IMasterSessionData.ConnectionString + "/Availability/DayAvailability", content).Result;
            if (result.IsSuccessStatusCode)
            {
                var responseContent = await result.Content.ReadAsStringAsync();
                //var responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<IMasterProviderCoursesResponseData>(responseContent);
                IMasterDayAvailabilityResponseDTO responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<IMasterDayAvailabilityResponseDTO>(responseContent);
                IMasterDayAvailabilityResponseData r = responseData.Data;
                return r;
            }
            else
            {
                throw new Exception("Error getting iMaster connection authorization");
            }
        }
    }
}

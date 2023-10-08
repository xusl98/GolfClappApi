
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
    public class IMasterProviderCourseService : IIMasterProviderCourseService
    {
        public readonly HttpClient _httpClient;
        public IMasterProviderCourseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IMasterProviderCourseResponseData> GetProviderCourses(int vendorId, int providerId, int tourOperatorId, int sessionId, string accessToken, string culture)
        {            
            var requestData = new
            {
                vendorId = vendorId,
                providerId = providerId,
                tourOperatorId = tourOperatorId,
                sessionId = sessionId,
                accessToken = accessToken,
                culture = culture
            };

            // Serialize the data to JSON
            string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);

            // Create a StringContent with JSON content and specify the content type
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var result = _httpClient.PostAsync(IMasterSessionData.ConnectionString + "/Vendors/ProviderCourses", content).Result;
            if (result.IsSuccessStatusCode)
            {
                var responseContent = await result.Content.ReadAsStringAsync();
                //var responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<IMasterProviderCoursesResponseData>(responseContent);
                IMasterProviderCourseResponseDTO responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<IMasterProviderCourseResponseDTO>(responseContent);
                IMasterProviderCourseResponseData r = responseData.Data;
                return r;
            }
            else
            {
                throw new Exception("Error getting iMaster connection authorization");
            }
        }
    }
}

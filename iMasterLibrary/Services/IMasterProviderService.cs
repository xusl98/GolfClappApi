
using AutoMapper;
using iMasterLibrary.Objects;
using iMasterLibrary.ServiceInterfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMasterLibrary.Services
{
    public class IMasterProviderService : IIMasterProviderService
    {
        public readonly HttpClient _httpClient;
        public readonly IIMasterProviderCourseService _providerCourseService;
        public readonly IIMasterDayAvailabilityService _dayAvailabilityService;
        private readonly IMapper _mapper;
        public IMasterProviderService(HttpClient httpClient, IIMasterProviderCourseService providerCourseService, IIMasterDayAvailabilityService dayAvailabilityService, IMapper mapper)
        {
            _httpClient = httpClient;
            _providerCourseService = providerCourseService;
            _dayAvailabilityService = dayAvailabilityService;
            _mapper = mapper;
        }

        public async Task<IMasterProviderResponseData> GetProviders(int vendorId, int sessionId, string accessToken, string culture)
        {
            var requestData = new
            {
                vendorId = vendorId,
                culture = culture,
                sessionId = sessionId,
                accessToken = accessToken
            };

            // Serialize the data to JSON
            string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);

            // Create a StringContent with JSON content and specify the content type
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var result = _httpClient.PostAsync(IMasterSessionData.ConnectionString + "/Vendors/Providers", content).Result;
            if (result.IsSuccessStatusCode)
            {
                var responseContent = await result.Content.ReadAsStringAsync();
                var responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<IMasterProviderResponseData>(responseContent);
                return responseData;
            }
            else
            {
                throw new Exception("Error getting iMaster connection authorization");
            }
        }

        public async Task<IMasterProviderAvailabilityResponseData> GetProvidersWithCourses(int vendorId, int sessionId, string accessToken, string culture, string playDate, string fromTime,
            string toTime, int players, int fromPrice, int toPrice, int pageSize, int pageNum)
        {
            var requestData = new
            {
                vendorId = vendorId,
                culture = culture,
                sessionId = sessionId,
                accessToken = accessToken
            };

            // Serialize the data to JSON
            string jsonContent = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);

            // Create a StringContent with JSON content and specify the content type
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var result = _httpClient.PostAsync(IMasterSessionData.ConnectionString + "/Vendors/Providers", content).Result;
            if (result.IsSuccessStatusCode)
            {
                var responseContent = await result.Content.ReadAsStringAsync();
                IMasterProviderAvailabilityResponseDTO responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<IMasterProviderAvailabilityResponseDTO>(responseContent);
                IMasterProviderAvailabilityResponseData r = responseData.Data;

                foreach (var provider in r.ProvidersList)
                {
                    var resp = await _providerCourseService.GetProviderCourses(vendorId, provider.ProviderID, provider.TourOperatorID, sessionId, accessToken, culture);
                    
                    provider.Courses = _mapper.Map<List<IMasterProviderCourse>, List<IMasterProviderCourseAvailability>>(resp.CoursesList);
                    foreach (var course in provider.Courses)
                    {
                        var avResp = await _dayAvailabilityService.GetDayAvailability(vendorId, provider.ProviderID, provider.TourOperatorID, sessionId, accessToken, culture,
                        Int32.Parse(course.CourseID), playDate, fromTime, toTime, players, fromPrice, toPrice, pageSize, pageNum, "");
                        if (avResp != null)
                        {
                            course.Price = (avResp.TeeTimesAvailable.Count > 0 && avResp.TeeTimesAvailable.First().Rates.Count > 0) ? avResp.TeeTimesAvailable.First().Rates.First().SellPrice : 0;
                            course.TimesAvailable = avResp.TeeTimesAvailable.Select(t => t.Time.ToString("HH:mm")).ToList();
                        }                        
                    }
                    
                }

                return r;
            }
            else
            {
                throw new Exception("Error getting iMaster connection authorization");
            }
        }
    }
}

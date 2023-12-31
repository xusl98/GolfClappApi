﻿
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
    public class IMasterAccessService : IIMasterAccessService
    {
        public readonly HttpClient _httpClient;
        public IMasterAccessService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<IMasterAccessTokenResponseData> GetSessionData(string username, string password, int lifeSpanSeconds, string culture)
        {            
            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "username", "golfclapp@outlook.com" },
                { "password", "654321" },
                { "lifeSpanSeconds", "3600" },
                { "culture", "es-ES" }
            });
            
            var result = _httpClient.PostAsync(IMasterSessionData.ConnectionString + "/Access/Token", content).Result;
            if (result.IsSuccessStatusCode)
            {
                var responseContent = await result.Content.ReadAsStringAsync();
                //JObject json = JObject.Parse(responseContent);

                //IMasterSessionData.SessionId = Int32.Parse(json["data"]["sessionID"].ToString());
                //IMasterSessionData.VendorId = Int32.Parse(json["data"]["vendorID"].ToString());
                //IMasterSessionData.AccessToken = json["data"]["accessToken"].ToString();
                //IMasterSessionData.Expiration = DateTime.Parse(json["data"]["expiration"].ToString());
                var responseData = Newtonsoft.Json.JsonConvert.DeserializeObject<IMasterAccessTokenResponseData>(responseContent);
                return responseData;
            }
            else
            {
                throw new Exception("Error getting iMaster connection authorization");
            }
        }
    }
}

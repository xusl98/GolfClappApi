using GolfClappServiceLibrary.Services;
using ObjectsLibrary.Authentication;
using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClappServiceLibrary.ServiceInterfaces
{
    public interface IAccountService
    {
        Task<CustomAuthenticationResponse> Register(UserDTO user);
        Task<CustomAuthenticationResponse> UpdatePassword(string userId, string currentPassword, string newPassword);
        bool IsUserApiKeyValid(string userApiKey);
        public string GetUserAPiKeyByEmail(string email);
        UserEntity GetByUserAPiKey(string userApiKey);
    }
}

using AutoMapper;
using GolfClapp.DB.Infrastructure.RepositoryInterfaces;

using GolfClappServiceLibrary.ServiceInterfaces;
using Microsoft.AspNetCore.Identity;
using ObjectsLibrary.Authentication;
using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClappServiceLibrary.Services
{
    public class AccountService : IAccountService
    {

        private readonly IUserRepository _userRepository;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;
        private readonly UserManager<UserEntity> _userManager;

        public AccountService(IMapper mapper, IUserRepository userRepository, ILogService logService, UserManager<UserEntity> userManager)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _logService = logService;
            _userManager = userManager;
        }


        public async Task<CustomAuthenticationResponse> Register(UserDTO user)
        {
            var response = new CustomAuthenticationResponse();
            try
            {
                //var a = _userManager.Users;
                //var userExists = _userManager.Users.FirstOrDefault(u => u.UserName == user.UserName);
                //if (userExists != null)
                //    throw new Exception("A user with that UserName already exists");

                UserEntity identityUser = _mapper.Map<UserDTO, UserEntity>(user);
                identityUser.UserApiKey = GenerateApiKeyValue();
                var result = _userManager.CreateAsync(identityUser, user.Password).GetAwaiter().GetResult();
                if (!result.Succeeded)
                    throw new Exception("User creation failed, please try again");

               



                response.IsSuccess = true;
                response.ApiKey = identityUser.UserApiKey;
                response.User = identityUser;
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logService.SaveErrorLog(ex.Message);
                return response;
            }
        }

        public async Task<CustomAuthenticationResponse> UpdatePassword(string userName, string currentPassword, string newPassword)
        {
            var response = new CustomAuthenticationResponse();
            try
            {
                var user = await _userManager.FindByEmailAsync(userName);
                if (user == null)
                    throw new Exception("User not found");

                var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
                if (!result.Succeeded)
                    throw new Exception("Failed to change password");

                response.IsSuccess = true;
                response.Message = "Password updated successfully";
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                _logService.SaveErrorLog(ex.Message);
                return response;
            }
        }



        public bool IsUserApiKeyValid(string userApiKey)
        {
            return _userRepository.IsUserApiKeyValid(userApiKey);
        }
        public UserEntity GetByUserAPiKey(string userApiKey)
        {
            return _userRepository.GetByUserAPiKey(userApiKey);
        }

        public string GetUserAPiKeyByEmail(string email)
        {
            return _userRepository.GetUserAPiKeyByEmail(email);
        }

        private string GenerateApiKeyValue() =>
            $"{Guid.NewGuid().ToString()}-{Guid.NewGuid().ToString()}";
    }

    
}

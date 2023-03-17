using AutoMapper;
using GolfClapp.DB.Infrastructure.RepositoryInterfaces;
using GolfClappServiceLibrary.ServiceInterfaces;
using Microsoft.AspNetCore.Identity;
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


        public async Task<BaseResponseDTO> Register(UserDTO user)
        {
            var response = new BaseResponseDTO();
            try
            {
                //var a = _userManager.Users;
                //var userExists = _userManager.Users.FirstOrDefault(u => u.UserName == user.UserName);
                //if (userExists != null)
                //    throw new Exception("A user with that UserName already exists");

                UserEntity identityUser = _mapper.Map<UserEntity>(user);
                var result = _userManager.CreateAsync(identityUser, user.Password).GetAwaiter().GetResult();
                if (!result.Succeeded)
                    throw new Exception("User creation failed, please try again");





                response.IsSuccess = true;
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
    }   
}

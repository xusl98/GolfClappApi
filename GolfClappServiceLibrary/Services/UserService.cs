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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogService _logService;
        private readonly IMapper _mapper;
        public UserService(IMapper mapper, IUserRepository userRepository, ILogService logService) 
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _logService = logService;
        }

        public UserDTO GetUserById(Guid id)
        {
            try
            {
                var user = _mapper.Map<UserEntity, UserDTO>(_userRepository.GetById(id));
                user.Password = "";
                return user;
            } catch (Exception ex)
            {
                _logService.SaveErrorLog(ex.Message);
                return null;
            }
        }

        public UserDTO GetUserByApiKey(string id)
        {
            try
            {
                var user = _mapper.Map<UserEntity, UserDTO>(_userRepository.GetByUserAPiKey(id));
                return user;
            }
            catch (Exception ex)
            {
                _logService.SaveErrorLog(ex.Message);
                return null;
            }
        }

        UserEntity _GetUserEntityByApiKey(string id)
        {
            try
            {
                var user = _userRepository.GetByUserAPiKey(id);
                return user;
            }
            catch (Exception ex)
            {
                _logService.SaveErrorLog(ex.Message);
                return null;
            }
        }

        public List<UserDTO> GetUsersByNameFilter(Guid userId, string nameFilter)
        {
            return _mapper.Map<List<UserEntity>, List<UserDTO>>(_userRepository.GetByNameFilter(userId, nameFilter));
        }

        public void EditUserValues(UserUpdateObject userUpdateObject, string apiKey)
        {
            var user = _GetUserEntityByApiKey(apiKey);
            if (userUpdateObject.Name != null)
            {
                user.Name = userUpdateObject.Name;
            }
            if (userUpdateObject.Email != null) 
            { 
                user.Email = userUpdateObject.Email;
            }
            if (userUpdateObject.Username != null)
            {
                user.UserName = userUpdateObject.Username;
            }
            if (userUpdateObject.Surname != null) 
            {
                user.Surname = userUpdateObject.Surname;
            }
            if (userUpdateObject.Phone != null)
            {
                user.PhoneNumber = userUpdateObject.Phone;
            }
            if (userUpdateObject.License != null)
            {
                user.License = userUpdateObject.License;
            }if (userUpdateObject.PaymentMethod != null)
            {
                user.PaymentMethod = userUpdateObject.PaymentMethod;
            }

            _userRepository.Save(user);
        }

        public BaseResponseDTO Save(UserDTO user)
        {
            var response = new BaseResponseDTO();
            try
            {
                _userRepository.Save(_mapper.Map<UserDTO, UserEntity>((user)));
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

using AutoMapper;
using GolfClapp.DB.Infrastructure.RepositoryServices;
using GolfClappServiceLibrary.ServiceInterfaces;
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
        private readonly IMapper _mapper;
        public UserService(IMapper mapper, IUserRepository userRepository) 
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public UserDTO GetUserById(Guid id)
        {
            try
            {
                return _mapper.Map<UserEntity, UserDTO>(_userRepository.GetById(id));
            } catch (Exception ex)
            {
                return null;
                //Control exception
            }
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
                return response;
            }            
        }
    }
}

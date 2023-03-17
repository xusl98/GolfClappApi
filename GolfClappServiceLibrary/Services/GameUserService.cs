using AutoMapper;
using GolfClapp.DB.Infrastructure.Repositories;
using GolfClapp.DB.Infrastructure.RepositoryInterfaces;
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
    public class GameUserService : IGameUserService
    {
        private readonly IGameUserRepository _gameUserRepository;
        private readonly IMapper _mapper;
        
        public GameUserService(IMapper mapper, IGameUserRepository gameUserRepository)
        {
            _mapper = mapper;
            _gameUserRepository = gameUserRepository;
        }


        public BaseResponseDTO Save(GameUserDTO gameUser)
        {
            var response = new BaseResponseDTO();
            try
            {
                _gameUserRepository.Save(_mapper.Map<GameUserDTO, GameUserEntity>(gameUser));
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

        public GameUserDTO GetById(Guid id)
        {

            return _mapper.Map<GameUserEntity, GameUserDTO>(_gameUserRepository.Get(id));           
        }

        public List<GameUserDTO> Get()
        {
            return _mapper.Map<List<GameUserEntity>, List<GameUserDTO>>(_gameUserRepository.Get());
        }

        public BaseResponseDTO Remove(Guid id)
        {
            var response = new BaseResponseDTO();
            try
            {
                _gameUserRepository.Remove(id);
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

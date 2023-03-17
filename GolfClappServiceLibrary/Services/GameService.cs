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
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        
        public GameService(IMapper mapper, IGameRepository gameRepository)
        {
            _mapper = mapper;
            _gameRepository = gameRepository;
        }


        public BaseResponseDTO Save(GameDTO game)
        {
            var response = new BaseResponseDTO();
            try
            {
                _gameRepository.Save(_mapper.Map<GameDTO, GameEntity>(game));
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

        public GameDTO GetById(Guid id)
        {

            return _mapper.Map<GameEntity, GameDTO>(_gameRepository.Get(id));           
        }

        public List<GameDTO> Get()
        {
            return _mapper.Map<List<GameEntity>, List<GameDTO>>(_gameRepository.Get());
        }

        public BaseResponseDTO Remove(Guid id)
        {
            var response = new BaseResponseDTO();
            try
            {
                _gameRepository.Remove(id);
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

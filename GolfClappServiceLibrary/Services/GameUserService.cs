using AutoMapper;
using GolfClapp.DB.Infrastructure.Repositories;
using GolfClapp.DB.Infrastructure.RepositoryInterfaces;
using GolfClappServiceLibrary.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUserService _userService;
        
        public GameUserService(IMapper mapper, IGameUserRepository gameUserRepository, IUserService userService)
        {
            _mapper = mapper;
            _gameUserRepository = gameUserRepository;
            _userService = userService;
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

        public BaseResponseDTO Save(List<Guid> usersIds, Guid gameId, Guid creatorUserId, List<Guid> payedUsersIds, int nonUserPlayers, double pricePerPart)
        {
            var response = new BaseResponseDTO();
            try
            {
                List<GameUserDTO> gU = new List<GameUserDTO>();
                foreach (var userId in usersIds)
                {
                    var user = _userService.GetUserById(userId);

                    var price = (user.Id == creatorUserId) ? (pricePerPart * (nonUserPlayers + 1)) : pricePerPart;
                    var hasPayed = (payedUsersIds.Contains(user.Id) || user.Id == creatorUserId);
                    gU.Add(new GameUserDTO()
                    {
                        Id = Guid.NewGuid(),
                        GameId = gameId,
                        UserId = userId,
                        Name = user.Name,
                        Score = 0,
                        ExternalUser = false,
                        HasPayed = hasPayed,
                        Price = price
                    });
                }
                _gameUserRepository.Save(_mapper.Map<List<GameUserDTO>, List<GameUserEntity>>(gU));
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

        public List<GameUserDTO> GetGameUsersByGameId(Guid gameId)
        {
            return _mapper.Map<List<GameUserEntity>, List<GameUserDTO>>(_gameUserRepository.GetGameUsersByGameId(gameId));
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

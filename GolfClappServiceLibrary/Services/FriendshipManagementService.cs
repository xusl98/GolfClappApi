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
    public class FriendshipManagementService : IFriendshipManagementService
    {
        private readonly IFriendshipRepository _friendshipRepository;
        private readonly IFriendshipRequestRepository _friendshipRequestRepository;
        private readonly IMapper _mapper;
        
        public FriendshipManagementService(IMapper mapper, IFriendshipRepository friendshipRepository, IFriendshipRequestRepository friendshipRequestRepository)
        {
            _mapper = mapper;
            _friendshipRepository = friendshipRepository;
            _friendshipRequestRepository = friendshipRequestRepository;
        }


        public FriendshipRequestDTO SendRequest(Guid senderId, Guid receiverId)
        {
            var request = new FriendshipRequestDTO()
            {
                Id = Guid.NewGuid(),
                SenderId = senderId,
                ReceiverId = receiverId
            };
            return _mapper.Map<FriendshipRequestEntity, FriendshipRequestDTO>(_friendshipRequestRepository.Save(_mapper.Map<FriendshipRequestDTO, FriendshipRequestEntity>(request)));
        }

        public List<FriendshipRequestDTO> GetFriendRequests(Guid userId)
        {
           return _mapper.Map<List<FriendshipRequestEntity>, List<FriendshipRequestDTO>>(_friendshipRequestRepository.GetByUserId(userId));
        }

        public List<UserDTO> GetFriends(Guid userId, string nameFilter)
        {
            var friendships = _friendshipRepository.GetByUserId(userId, nameFilter);

            return _mapper.Map<List<UserEntity>, List<UserDTO>>(friendships.Select(f => f.User1Id != userId ? f.User1 : f.User2).ToList());
        }
        
    }
}

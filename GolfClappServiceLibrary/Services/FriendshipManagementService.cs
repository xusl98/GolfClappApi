using AutoMapper;
using GolfClapp.DB.Infrastructure.Repositories;
using GolfClapp.DB.Infrastructure.RepositoryInterfaces;
using GolfClappServiceLibrary.ServiceInterfaces;
using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            //If you received a request from the receiver automatically add him as friend
            var receivedRequest = _mapper.Map<FriendshipRequestEntity, FriendshipRequestDTO>(_friendshipRequestRepository.GetBySenderAndReceiverIds(receiverId, senderId));

            if (receivedRequest == null)
                return _mapper.Map<FriendshipRequestEntity, FriendshipRequestDTO>(_friendshipRequestRepository.Save(_mapper.Map<FriendshipRequestDTO, FriendshipRequestEntity>(request)));
            else
            {
                AcceptFriendRequest(receivedRequest.Id);
                return request;
            }
                

        }

        public List<FriendshipRequestDTO> GetReceivedRequests(Guid userId)
        {
           return _mapper.Map<List<FriendshipRequestEntity>, List<FriendshipRequestDTO>>(_friendshipRequestRepository.GetReceivedRequests(userId));
        }

        public List<FriendshipRequestDTO> GetSentRequests(Guid userId)
        {
            return _mapper.Map<List<FriendshipRequestEntity>, List<FriendshipRequestDTO>>(_friendshipRequestRepository.GetSentRequests(userId));
        }

        public List<UserDTO> GetFriends(Guid userId, string nameFilter)
        {
            var friendships = _friendshipRepository.GetByUserId(userId, nameFilter);

            return _mapper.Map<List<UserEntity>, List<UserDTO>>(friendships.Select(f => f.User1Id != userId ? f.User1 : f.User2).ToList());
        }

        public void AcceptFriendRequest(Guid friendRequestId)
        {
            var fRequest = _friendshipRequestRepository.Get(friendRequestId);

            var fr = new FriendshipDTO()
            {
                Id = Guid.NewGuid(),
                User1Id = fRequest.SenderId,
                User2Id = fRequest.ReceiverId,                

            };
            _friendshipRepository.Save(_mapper.Map<FriendshipDTO, FriendshipEntity>(fr));
            _friendshipRequestRepository.Remove(friendRequestId);
        }
        public void DeclineFriendRequest(Guid friendRequestId)
        {            
            _friendshipRequestRepository.Remove(friendRequestId);
        }

        public int GetNumberOfFriends(Guid userId)
        {
            return _friendshipRepository.GetNumberOfFriends(userId);
        }

        public void RemoveFriend(Guid userId, Guid friendUserId)
        {
            _friendshipRepository.Remove(userId, friendUserId);
        }

    }
}

using GolfClapp.DB.Infrastructure.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClapp.DB.Infrastructure.Repositories
{
    public class FriendshipRequestRepository : IFriendshipRequestRepository
    {

        private readonly GolfClappContext _context;
        public FriendshipRequestRepository(GolfClappContext context) 
        {
            _context = context;
        }

        public List<FriendshipRequestEntity> Get()
        {
            return _context.FriendshipRequests.ToList();
        }

        public FriendshipRequestEntity Get(Guid id)
        {
            return _context.FriendshipRequests.FirstOrDefault(g => g.Id == id);
        }

        public FriendshipRequestEntity GetBySenderAndReceiverIds(Guid senderId, Guid receiverId)
        {
            return _context.FriendshipRequests.FirstOrDefault(f => f.SenderId == senderId && f.ReceiverId == receiverId);
        }


        public List<FriendshipRequestEntity> GetReceivedRequests(Guid userId)
        {
            return _context.FriendshipRequests.Include(f => f.Sender).Where(f => f.ReceiverId == userId).ToList();
        }
        public List<FriendshipRequestEntity> GetSentRequests(Guid userId)
        {
            return _context.FriendshipRequests.Include(f => f.Receiver).Where(f => f.SenderId == userId).ToList();
        }

        public FriendshipRequestEntity Remove(Guid id)
        {
            var g = _context.FriendshipRequests.FirstOrDefault(g => g.Id == id);
            _context.FriendshipRequests.Remove(g);
            _context.SaveChanges();
            return g;            
        }

        public FriendshipRequestEntity Save(FriendshipRequestEntity friendshipRequest)
        {
            var g = _context.FriendshipRequests.FirstOrDefault(g => g.Id == friendshipRequest.Id);
            if (g == null)
            {
                _context.FriendshipRequests.Add(friendshipRequest);
            }
            
            _context.SaveChanges();
            return friendshipRequest;
        }
    }
}

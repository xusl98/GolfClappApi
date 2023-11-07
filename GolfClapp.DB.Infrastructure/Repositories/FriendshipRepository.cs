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
    public class FriendshipRepository : IFriendshipRepository
    {

        private readonly GolfClappContext _context;
        public FriendshipRepository(GolfClappContext context) 
        {
            _context = context;
        }

        public List<FriendshipEntity> Get()
        {
            return _context.Friendships.ToList();
        }

        public FriendshipEntity Get(Guid id)
        {
            return _context.Friendships.FirstOrDefault(g => g.Id == id);
        }
        public List<FriendshipEntity> GetByUserId(Guid userId)
        {
            return _context.Friendships.Where(f => f.User1Id == userId || f.User2Id == userId).ToList();
        }

        public FriendshipEntity Remove(Guid id)
        {
            var g = _context.Friendships.FirstOrDefault(g => g.Id == id);
            _context.Friendships.Remove(g);
            _context.SaveChanges();
            return g;            
        }

        public FriendshipEntity Save(FriendshipEntity friendship)
        {
            var g = _context.Friendships.FirstOrDefault(g => g.Id == friendship.Id);
            if (g == null)
            {
                _context.Friendships.Add(friendship);
            }
            else
            {
                _context.Entry(g).CurrentValues.SetValues(friendship);
            }
            _context.SaveChanges();
            return friendship;
        }
    }
}

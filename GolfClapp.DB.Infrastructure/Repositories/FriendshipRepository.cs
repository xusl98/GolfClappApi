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
        public List<FriendshipEntity> GetByUserId(Guid userId, string nameFilter)
        {
            var filter = nameFilter.ToLower();
            var friendships = _context.Friendships.Include(f => f.User1).Include(f => f.User2).Where(f => f.User1Id == userId || f.User2Id == userId).ToList();
            if (nameFilter != null && nameFilter.Length > 0)
            {
                return friendships.Where(f => 
                (f.User2Id != userId && (f.User2.UserName.ToLower().Contains(filter) || f.User2.Name.ToLower().Contains(filter) || f.User2.Surname.ToLower().Contains(filter))) 
                || 
                (f.User1Id != userId && (f.User1.UserName.ToLower().Contains(filter) || f.User1.Name.ToLower().Contains(filter) || f.User1.Surname.ToLower().Contains(filter)))).ToList();
            }
            else
            {
                return friendships.ToList();
            }
        }

        public FriendshipEntity Remove(Guid id)
        {
            var g = _context.Friendships.FirstOrDefault(g => g.Id == id);
            _context.Friendships.Remove(g);
            _context.SaveChanges();
            return g;            
        }

        public FriendshipEntity Remove(Guid userId, Guid friendUserId)
        {
            var g = _context.Friendships.FirstOrDefault(g => (g.User1Id == userId && g.User2Id == friendUserId) || (g.User2Id == userId && g.User1Id == friendUserId));
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

        public int GetNumberOfFriends(Guid userId)
        {
            return _context.Friendships.Where(f => (f.User1Id == userId) || (f.User2Id == userId)).Count();
        }
    }
}

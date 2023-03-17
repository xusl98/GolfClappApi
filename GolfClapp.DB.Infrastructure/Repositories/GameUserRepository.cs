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
    public class GameUserRepository : IGameUserRepository
    {

        private readonly GolfClappContext _context;
        public GameUserRepository(GolfClappContext context) 
        {
            _context = context;
        }

        public List<GameUserEntity> Get()
        {
            return _context.GameUsers.ToList();
        }

        public GameUserEntity Get(Guid id)
        {
            return _context.GameUsers.FirstOrDefault(g => g.Id == id);
        }

        public GameUserEntity Remove(Guid id)
        {
            var g = _context.GameUsers.FirstOrDefault(g => g.Id == id);
            _context.GameUsers.Remove(g);
            _context.SaveChanges();
            return g;            
        }

        public GameUserEntity Save(GameUserEntity gameUser)
        {
            var g = _context.GameUsers.FirstOrDefault(g => g.Id == gameUser.Id);
            if (g == null)
            {
                _context.GameUsers.Add(gameUser);
                _context.SaveChanges();
            }
            else
            {
                _context.Entry(g).CurrentValues.SetValues(gameUser);
            }

            return gameUser;
        }
    }
}

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
    public class GameRepository : IGameRepository
    {

        private readonly GolfClappContext _context;
        public GameRepository(GolfClappContext context) 
        {
            _context = context;
        }

        public List<GameEntity> Get()
        {
            return _context.Games.ToList();
        }

        public GameEntity Get(Guid id)
        {
            return _context.Games.FirstOrDefault(g => g.Id == id);
        }

        public GameEntity Remove(Guid id)
        {
            var g = _context.Games.FirstOrDefault(g => g.Id == id);
            _context.Games.Remove(g);
            _context.SaveChanges();
            return g;            
        }

        public GameEntity Save(GameEntity game)
        {
            var g = _context.Games.FirstOrDefault(g => g.Id == game.Id);
            if (g == null)
            {
                _context.Games.Add(game);
                _context.SaveChanges();
            }
            else
            {
                _context.Games.Entry(g).CurrentValues.SetValues(game);
            }
            
            return game;
        }
    }
}

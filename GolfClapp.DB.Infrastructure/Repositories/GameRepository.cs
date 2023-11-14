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
        public GameEntity GetByCourseIdAndDate(int providerCourseId, DateTime date)
        {
            return _context.Games.FirstOrDefault(g => g.ProviderCourseId == providerCourseId && g.Date == date);
        }

        public List<GameEntity> GetByDate(DateTime date, bool olderBookings, Guid userId)
        {
            var gamesForUser = _context.Games
            .Join(
                _context.GameUsers,
                game => game.Id,
                gameUser => gameUser.GameId,
                (game, gameUser) => new { Game = game, GameUser = gameUser }
            )
            .Where(joinResult => joinResult.GameUser.UserId == userId)
            .Select(joinResult => joinResult.Game)
            .ToList();
            if (!olderBookings)
                return gamesForUser.Where(g => g.Date >= date).OrderBy(g => g.Date).ToList();
            else
            {
                var list = new List<GameEntity>();
                list.AddRange(gamesForUser.Where(g => g.Date >= date).OrderBy(g => g.Date).ToList());
                list.AddRange(gamesForUser.Where(g => g.Date < date).OrderBy(g => g.Date).ToList());
                return list;

            }
                
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
            }
            else
            {
                _context.Entry(g).CurrentValues.SetValues(game);
            }
            _context.SaveChanges();
            return game;
        }
    }
}

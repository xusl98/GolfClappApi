using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClapp.DB.Infrastructure.RepositoryInterfaces
{
    public interface IGameRepository
    {
        GameEntity Save(GameEntity gameEntity);
        List<GameEntity> Get();
        GameEntity GetByCourseIdAndDate(int providerCourseId, DateTime date);
        GameEntity Get(Guid id);
        GameEntity Remove(Guid id);
        List<GameEntity> GetByDate(DateTime date, bool olderBookings, Guid userId);
        List<GameEntity> GetByDatePendingPayment(DateTime date, Guid userId);
        List<GameEntity> GetUnpayedGames();
    }
}

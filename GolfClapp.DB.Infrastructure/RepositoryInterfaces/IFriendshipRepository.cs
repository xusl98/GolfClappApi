using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClapp.DB.Infrastructure.RepositoryInterfaces
{
    public interface IFriendshipRepository
    {
        FriendshipEntity Save(FriendshipEntity friendshipEntity);
        List<FriendshipEntity> GetByUserId(Guid userId, string nameFilter);
        List<FriendshipEntity> Get();
        FriendshipEntity Get(Guid id);
        FriendshipEntity Remove(Guid id);
        int GetNumberOfFriends(Guid userId);
    }
}

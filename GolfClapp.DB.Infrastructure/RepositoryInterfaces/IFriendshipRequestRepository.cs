using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClapp.DB.Infrastructure.RepositoryInterfaces
{
    public interface IFriendshipRequestRepository
    {
        FriendshipRequestEntity Save(FriendshipRequestEntity friendshipEntity);
        List<FriendshipRequestEntity> Get();
        FriendshipRequestEntity Get(Guid id);
        List<FriendshipRequestEntity> GetByUserId(Guid userId);
        FriendshipRequestEntity Remove(Guid id);

    }
}

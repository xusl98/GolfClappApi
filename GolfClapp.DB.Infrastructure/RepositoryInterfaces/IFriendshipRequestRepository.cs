﻿using ObjectsLibrary.Entities;
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
        FriendshipRequestEntity GetBySenderAndReceiverIds(Guid senderId, Guid receiverId);
        List<FriendshipRequestEntity> GetReceivedRequests(Guid userId);
        List<FriendshipRequestEntity> GetSentRequests(Guid userId);
        FriendshipRequestEntity Remove(Guid id);

    }
}

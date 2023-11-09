using ObjectsLibrary.Authentication;
using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClappServiceLibrary.ServiceInterfaces
{
    public interface IFriendshipManagementService
    {
        FriendshipRequestDTO SendRequest(Guid senderId, Guid receiverId);
        List<FriendshipRequestDTO> GetFriendRequests(Guid userId);
        List<UserDTO> GetFriends(Guid userId, string nameFilter);
    }
}

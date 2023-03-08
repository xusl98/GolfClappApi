using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClappServiceLibrary.ServiceInterfaces
{
    public interface IUserService
    {
        UserDTO GetUserById(Guid id);
        BaseResponseDTO Save(UserDTO user);
    }
}

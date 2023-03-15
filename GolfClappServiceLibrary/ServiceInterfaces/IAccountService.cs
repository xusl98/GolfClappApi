using ObjectsLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClappServiceLibrary.ServiceInterfaces
{
    public interface IAccountService
    {
        Task<BaseResponseDTO> Register(UserDTO user);
    }
}

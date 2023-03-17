using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClappServiceLibrary.ServiceInterfaces
{
    public interface IGameUserService
    {        
        BaseResponseDTO Save(GameUserDTO game);
        GameUserDTO GetById(Guid id);
        List<GameUserDTO> Get();
        BaseResponseDTO Remove(Guid id);


    }
}

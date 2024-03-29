﻿using ObjectsLibrary.DTOs;
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
        List<GameUserDTO> GetGameUsersByGameId(Guid gameId);
        BaseResponseDTO Remove(Guid id);
        BaseResponseDTO Save(List<Guid> usersIds, Guid gameId, Guid creatorUserId, List<Guid> payedUsersIds, int nonUserPlayers, double pricePerPart);


    }
}

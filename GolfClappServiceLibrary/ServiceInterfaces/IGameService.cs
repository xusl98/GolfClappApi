﻿using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClappServiceLibrary.ServiceInterfaces
{
    public interface IGameService
    {
        GameDTO Save(GameDTO game);
        GameDTO GetById(Guid id);
        List<GameDTO> Get();
        BaseResponseDTO Remove(Guid id);
        List<GameDTO> GetByDate(DateTime date, bool olderBookings, Guid userId, bool onlyWhenInvitedAndNotPayed);
        List<GameDTO> GetUnpayedGames();

    }
}

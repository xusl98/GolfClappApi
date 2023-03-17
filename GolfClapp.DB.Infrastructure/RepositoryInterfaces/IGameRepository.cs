﻿using ObjectsLibrary.Entities;
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
        GameEntity Get(Guid id);
        GameEntity Remove(Guid id);
    }
}

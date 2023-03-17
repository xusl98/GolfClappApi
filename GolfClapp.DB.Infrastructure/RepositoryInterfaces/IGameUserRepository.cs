﻿using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClapp.DB.Infrastructure.RepositoryInterfaces
{
    public interface IGameUserRepository
    {
        GameUserEntity Save(GameUserEntity gameUserEntity);
        List<GameUserEntity> Get();
        GameUserEntity Get(Guid id);
        GameUserEntity Remove(Guid id);
    }
}

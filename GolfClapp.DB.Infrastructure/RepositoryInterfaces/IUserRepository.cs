using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClapp.DB.Infrastructure.RepositoryInterfaces
{
    public interface IUserRepository
    {
        UserEntity GetById(Guid id);
        UserEntity Save(UserEntity entity);
        bool IsUserApiKeyValid(string userApiKey);
        public string GetUserAPiKeyByEmail(string email);
        UserEntity GetByUserAPiKey(string userApiKey);
        List<UserEntity> GetByNameFilter(Guid userId, string nameFilter);
    }
}

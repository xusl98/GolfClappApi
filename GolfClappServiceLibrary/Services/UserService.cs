using GolfClapp.DB.Infrastructure.RepositoryServices;
using GolfClappServiceLibrary.ServiceInterfaces;
using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClappServiceLibrary.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public UserEntity GetUserById(Guid id)
        {
            try
            {
                return _userRepository.GetById(id);
            } catch (Exception ex)
            {
                return null;
                //Control exception
            }
        }
    }
}

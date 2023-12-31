﻿using GolfClapp.DB.Infrastructure.RepositoryInterfaces;
using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClapp.DB.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthenticationContext _context;

        public UserRepository(AuthenticationContext context) 
        { 
            _context = context; 
        }

        public UserEntity GetById(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public List<UserEntity> GetByNameFilter(Guid userId, string nameFilter)
        {
            return _context.Users.Where(u => u.UserName.ToLower().Contains(nameFilter.ToLower())).ToList();
        }

        public UserEntity Save(UserEntity entity) 
        {
            var g = _context.Users.FirstOrDefault(g => g.Id == entity.Id);
            if (g == null)
            {
                _context.Users.Add(entity);
            }
            else
            {
                _context.Entry(g).CurrentValues.SetValues(entity);
            }

            _context.SaveChanges();
            return entity;
        }

        public bool IsUserApiKeyValid(string userApiKey)
        {
            return _context.Users.Any(u => u.UserApiKey == userApiKey);
        }
        public UserEntity GetByUserAPiKey(string userApiKey)
        {
            return _context.Users.FirstOrDefault(u => u.UserApiKey == userApiKey);
        }
        public string GetUserAPiKeyByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email).UserApiKey;
        }
    }
}


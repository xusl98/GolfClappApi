﻿using GolfClapp.DB.Infrastructure.RepositoryServices;
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

        public UserEntity Save(UserEntity entity) 
        { 
            _context.Users.Add(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}

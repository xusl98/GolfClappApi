using GolfClapp.DB.Infrastructure.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClapp.DB.Infrastructure.Repositories
{
    public class AppIsBlockedRepository : IAppIsBlockedRepository
    {

        private readonly GolfClappContext _context;
        public AppIsBlockedRepository(GolfClappContext context) 
        {
            _context = context;
        }

        public AppIsBlockedEntity Get()
        {
            return _context.AppIsBlocked.FirstOrDefault();
        }

    }
}

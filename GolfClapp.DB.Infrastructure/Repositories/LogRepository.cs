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
    public class LogRepository : ILogRepository
    {

        private readonly GolfClappContext _context;
        public LogRepository(GolfClappContext context) 
        {
            _context = context;
        }

        public LogEntity Save(LogEntity entity)
        {
            _context.Logs.Add(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}

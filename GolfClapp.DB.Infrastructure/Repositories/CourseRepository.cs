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
    public class CourseRepository : ICourseRepository
    {

        private readonly GolfClappContext _context;
        public CourseRepository(GolfClappContext context) 
        {
            _context = context;
        }

        public List<ServiceProviderEntity> Get()
        {
            return _context.ServiceProviders.ToList();
        }

        public CourseEntity Get(Guid id)
        {
            return _context.Courses.FirstOrDefault(c => c.Id == id);
        }

        public CourseEntity Remove(Guid id)
        {
            var c = _context.Courses.FirstOrDefault(c => c.Id == id);
            _context.Courses.Remove(c);
            _context.SaveChanges();
            return c;            
        }

        public CourseEntity Save(CourseEntity course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return course;
        }
    }
}

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

        public List<CourseEntity> Get()
        {
            return _context.Courses.ToList();
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
            var c = _context.Courses.FirstOrDefault(c => c.Id == course.Id);
            if (c == null)
            {
                _context.Courses.Add(course);
            }
            else
            {
                _context.Entry(c).CurrentValues.SetValues(course);
            }
            _context.SaveChanges();
            return course;
        }
    }
}

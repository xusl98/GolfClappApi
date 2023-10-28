using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClapp.DB.Infrastructure.RepositoryInterfaces
{
    public interface ICourseRepository
    {
        CourseEntity Save(CourseEntity courseEntity);
        List<CourseEntity> Get();
        CourseEntity Get(Guid id);
        CourseEntity GetByImasterId(int id);
        CourseEntity Remove(Guid id);
    }
}

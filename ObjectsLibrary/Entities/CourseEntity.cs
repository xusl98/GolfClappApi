using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsLibrary.Entities
{
    public class CourseEntity
    {
        public Guid Id { get; set; }
        public string? LocationString { get; set; }
        public string? ImageUrl { get; set; }
        public int IMasterCourseId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsLibrary.Entities
{
    public class SaveAndAddUserRequestDTO
    {
        public string Date { get; set; }
        public string? CourseId { get; set; }
        public string CourseName { get; set; }
        public string Location { get; set; }
        public double Price { get; set; }
        public int ProviderCourseId { get; set; }
       


    }
}

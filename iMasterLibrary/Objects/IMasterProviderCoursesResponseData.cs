using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMasterLibrary.Objects
{

    public class IMasterProviderCoursesResponseData : IMasterResponseData
    {
        public List<IMasterProviderCourse> CoursesList { get; set; }
        public int CoursesCount { get; set; }
    }
    public class IMasterProviderCourse
    {
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public int Holes { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    
}

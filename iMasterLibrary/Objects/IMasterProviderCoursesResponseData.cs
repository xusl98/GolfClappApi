using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMasterLibrary.Objects
{

    public class IMasterProviderCourseResponseDTO
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public IMasterProviderCourseResponseData Data { get; set; }

    }
    public class IMasterProviderCourseResponseData
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
    public class IMasterProviderCourseAvailability
    {
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public int Holes { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public List<string> TimesAvailable { get; set; } //list of the hours
        public int Price { get; set; }
    }

    
}

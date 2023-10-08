using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMasterLibrary.Objects
{

    public class IMasterProviderResponseDTO
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public IMasterProviderResponseData Data { get; set; }
        
    }public class IMasterProviderAvailabilityResponseDTO
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public IMasterProviderAvailabilityResponseData Data { get; set; }
        
    }

    public class IMasterProviderResponseData
    {
        public List<IMasterProvider> ProvidersList { get; set; }
        public int ProvidersCount { get; set; }
    }
    public class IMasterProvider
    {
        public int ProviderID { get; set; }
        public string ProviderName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool IsClub { get; set; }
        public int TourOperatorID { get; set; }
        public string TourOperatorName { get; set; }
        public List<IMasterProviderCourse>? Courses{ get; set;}
    }public class IMasterProviderAvailabilityResponseData
    {
        public List<IMasterProviderAvailability> ProvidersList { get; set; }
        public int ProvidersCount { get; set; }
    }
    public class IMasterProviderAvailability
    {
        public int ProviderID { get; set; }
        public string ProviderName { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool IsClub { get; set; }
        public int TourOperatorID { get; set; }
        public string TourOperatorName { get; set; }
        public List<IMasterProviderCourseAvailability>? Courses{ get; set;}
    }

    
}

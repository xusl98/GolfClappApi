using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMasterLibrary.Objects
{

    public class IMasterProviderResponseData : IMasterResponseData
    {
        public List<IMasterProvider> ProvidersList { get; set; }
        public int ProvidersCount { get; set; }
    }
    public class IMasterProvider
    {
        public int ProviderID { get; set; }
        public string ProviderName { get; set; }
        public bool IsClub { get; set; }
        public int TourOperatorID { get; set; }
        public string TourOperatorName { get; set; }
    }

    
}

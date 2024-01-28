using iMasterLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMasterLibrary.Objects
{
    public class IMasterPreBookingRequestDTO
    {
        public int VendorID { get; set; }
        public int SessionID { get; set; }
        public string AccessToken { get; set; }
        public string Culture { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public List<IMasterTeeTimeBookingRequestDTO> TeeTimesList { get; set; }

    }

    public class IMasterTeeTimeBookingRequestDTO
    {

        public int TourOperatorID { get; set; }
        public int ProviderID { get; set; }
        public string PlayDateTime { get; set; }
        public int CourseID { get; set; }
        public List<PreBookingRequestRate> RatesList { get; set; }
    }

    public class PreBookingRequestRate
    {
        public int RateID { get; set; }
        public int RateTimeID { get; set; }
        public int RateTypeID { get; set; }
        public int? PromoCodeID { get; set; }
        public int Players { get; set; }
        public int Price { get; set; }
        public string RateName { get; set; }       
        public int YieldDiscountId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMasterLibrary.Objects
{
    public class IMasterBookingDetailsResponseData : IMasterResponseData
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

    }

    public class BookingDetails
    {
        public int ProviderID { get; set; }
        public int TourOperatorID { get; set; }
        public string ProviderName { get; set; }
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public DateTime PlayDateTime { get; set; }
        public string RateName { get; set; }
        public DateTime CancelDateTime { get; set; }
        public int Players { get; set; }
        public int BookingDetailsID { get; set; }
    }
}

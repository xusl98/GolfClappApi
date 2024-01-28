using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMasterLibrary.Objects
{

    public class IMasterPreBookingResponseDTO
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public IMasterPreBookingResponseData Data { get; set; }

    }
    public class IMasterPreBookingResponseData : IMasterResponseData
    {
        public string OrderReference { get; set; }

    }

    

    


}

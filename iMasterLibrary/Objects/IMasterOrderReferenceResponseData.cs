using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMasterLibrary.Objects
{
    public class IMasterOrderReferenceResponseData : IMasterResponseData
    {
        public string OrderReference { get; set; }
    }
    public class IMasterPreBookingResponseData : IMasterOrderReferenceResponseData { }
    public class IMasterPreCancellationResponseData : IMasterOrderReferenceResponseData { }
}

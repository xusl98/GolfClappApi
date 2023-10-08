using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMasterLibrary.Objects
{

    public class IMasterAccessTokenResponseData : IMasterResponseData
    {
        public IMasterAccessToken data { get; set; }
        public int ProvidersCount { get; set; }
    }
    public class IMasterAccessToken
    {
        public int SessionID { get; set; }
        public int VendorID { get; set; }
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }

    
}

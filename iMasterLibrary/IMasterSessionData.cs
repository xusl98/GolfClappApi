using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMasterLibrary
{
    public static class IMasterSessionData
    {
        public static string ConnectionString { get; set; }
        public static int SessionId { get; set; }
        public static int VendorId { get; set; }
        public static string AccessToken { get; set; }
        public static DateTime Expiration { get; set; }
    }
}

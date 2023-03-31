using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMasterLibrary.Objects
{
    public class IMasterResponseDTO
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public IMasterResponseData Data { get; set; }
    }

    public class IMasterResponseData
    {

    }
}

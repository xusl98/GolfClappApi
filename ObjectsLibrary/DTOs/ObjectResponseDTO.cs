using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsLibrary.DTOs
{
    public class ObjectResponseDTO
    {
        public int StatusCode { get; set; }
        public Object Body { get; set; }
        public string Message { get; set; }
    }
}

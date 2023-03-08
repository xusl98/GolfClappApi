using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsLibrary.Entities
{
    public class LogEntity
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public bool ErrorLog { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsLibrary.DTOs
{
    public class LogDTO
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public bool ErrorLog { get; set; }
    }
}

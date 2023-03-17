﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsLibrary.Entities
{
    public class CourseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool NineHoles { get; set; }
        public bool EighteenHoles { get; set; }
        public Guid ServiceProviderId { get; set; }

        public ServiceProviderEntity ServiceProvider { get; set; }
    }
}
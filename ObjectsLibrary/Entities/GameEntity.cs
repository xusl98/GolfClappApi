﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsLibrary.Entities
{
    public class GameEntity
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid CourseId { get; set; }

        public CourseEntity Course { get; set; }
    }
}
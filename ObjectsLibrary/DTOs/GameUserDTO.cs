﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsLibrary.Entities
{
    public class GameUserDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
        public string Name { get; set; }
        public bool ExternalUser { get; set; }
        public int Score { get; set; }
        public double Price { get; set; }
        public bool HasPayed { get; set; }
    }
}

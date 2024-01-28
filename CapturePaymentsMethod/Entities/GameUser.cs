using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapturePaymentsMethod.Entities
{

    public class GameUser
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid GameId { get; set; }
        public string Name { get; set; }
        public bool ExternalUser { get; set; }
        public int Score { get; set; }
        public double Price { get; set; }
        public bool HasPayed { get; set; }

        
        public Game Game { get; set; }
    }
}

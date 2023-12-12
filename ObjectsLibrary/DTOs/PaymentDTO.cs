using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsLibrary.Entities
{
    public class PaymentDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid GameUserId { get; set; }
        public Guid GameId { get; set; }
        public string ClientSecret { get; set; }
        public double Amount { get; set; }


    }
}

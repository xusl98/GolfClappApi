using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsLibrary.Entities
{
    public class FriendshipRequestEntity
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId{ get; set; }
        
        public UserEntity Sender { get; set; }
        public UserEntity Receiver { get; set; }
    }
}

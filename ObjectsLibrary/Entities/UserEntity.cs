
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsLibrary.Entities
{
    public class UserEntity : IdentityUser<Guid>
    {   
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Country { get; set; }
        public string? License { get; set; }
        public string UserApiKey { get; set; }

    }
}

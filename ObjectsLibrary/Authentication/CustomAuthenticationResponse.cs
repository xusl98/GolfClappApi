using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsLibrary.Authentication
{
    public class CustomAuthenticationResponse : BaseResponseDTO
    {
        public string ApiKey { get; set; }
        public UserEntity User { get; set; }

    }
}

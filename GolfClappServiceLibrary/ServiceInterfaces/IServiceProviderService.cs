using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClappServiceLibrary.ServiceInterfaces
{
    public interface IServiceProviderService
    {        
        BaseResponseDTO Save(ServiceProviderDTO serviceProvider);
        ServiceProviderDTO GetById(Guid id);
        List<ServiceProviderDTO> Get();
        BaseResponseDTO Remove(Guid id);


    }
}

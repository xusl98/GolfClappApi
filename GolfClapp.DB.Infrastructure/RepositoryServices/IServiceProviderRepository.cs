using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClapp.DB.Infrastructure.RepositoryServices
{
    public interface IServiceProviderRepository
    {
        ServiceProviderEntity Save(ServiceProviderEntity serviceProvider);
        List<ServiceProviderEntity> Get();
        ServiceProviderEntity Get(Guid id);
        ServiceProviderEntity Remove(Guid id);
    }
}

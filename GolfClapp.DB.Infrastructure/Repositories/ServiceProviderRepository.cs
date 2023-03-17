using GolfClapp.DB.Infrastructure.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClapp.DB.Infrastructure.Repositories
{
    public class ServiceProviderRepository : IServiceProviderRepository
    {

        private readonly GolfClappContext _context;
        public ServiceProviderRepository(GolfClappContext context) 
        {
            _context = context;
        }

        public List<ServiceProviderEntity> Get()
        {
            return _context.ServiceProviders.ToList();
        }

        public ServiceProviderEntity Get(Guid id)
        {
            return _context.ServiceProviders.FirstOrDefault(s => s.Id == id);
        }

        public ServiceProviderEntity Remove(Guid id)
        {
            var sp = _context.ServiceProviders.FirstOrDefault(s => s.Id == id);
            _context.ServiceProviders.Remove(sp);
            _context.SaveChanges();
            return sp;            
        }

        public ServiceProviderEntity Save(ServiceProviderEntity serviceProvider)
        {
            var s = _context.ServiceProviders.FirstOrDefault(s => s.Id == serviceProvider.Id);
            if (s == null)
            {
                _context.ServiceProviders.Add(serviceProvider);
                _context.SaveChanges();
            }
            else
            {
                _context.Entry(s).CurrentValues.SetValues(serviceProvider);
            }

            return serviceProvider;
        }
    }
}

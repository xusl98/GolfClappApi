using AutoMapper;
using GolfClapp.DB.Infrastructure.Repositories;
using GolfClapp.DB.Infrastructure.RepositoryInterfaces;
using GolfClappServiceLibrary.ServiceInterfaces;
using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClappServiceLibrary.Services
{
    public class AppIsBlockedService : IAppIsBlockedService
    {
        private readonly IAppIsBlockedRepository _appIsBlockedRepository;
        private readonly IMapper _mapper;
        
        public AppIsBlockedService(IMapper mapper, IAppIsBlockedRepository appIsBlockedRepository)
        {
            _mapper = mapper;
            _appIsBlockedRepository = appIsBlockedRepository;
        }


        
        public AppIsBlockedDTO Get()
        {
            return _mapper.Map<AppIsBlockedEntity, AppIsBlockedDTO>(_appIsBlockedRepository.Get());
        }

        
    }
}

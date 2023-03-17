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
    public class ServiceProviderService : IServiceProviderService
    {
        private readonly IServiceProviderRepository _serviceProviderRepository;
        private readonly IMapper _mapper;
        
        public ServiceProviderService(IMapper mapper, IServiceProviderRepository serviceProviderRepository)
        {
            _mapper = mapper;
            _serviceProviderRepository = serviceProviderRepository;
        }


        public BaseResponseDTO Save(ServiceProviderDTO serviceProvider)
        {
            var response = new BaseResponseDTO();
            try
            {
                _serviceProviderRepository.Save(_mapper.Map<ServiceProviderDTO, ServiceProviderEntity>(serviceProvider));
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return response;
            }            
        }

        public ServiceProviderDTO GetById(Guid id)
        {

            return _mapper.Map<ServiceProviderEntity, ServiceProviderDTO>(_serviceProviderRepository.Get(id));           
        }

        public List<ServiceProviderDTO> Get()
        {
            return _mapper.Map<List<ServiceProviderEntity>, List<ServiceProviderDTO>>(_serviceProviderRepository.Get());
        }

        public BaseResponseDTO Remove(Guid id)
        {
            var response = new BaseResponseDTO();
            try
            {
                _serviceProviderRepository.Remove(id);
                response.IsSuccess = true;
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}

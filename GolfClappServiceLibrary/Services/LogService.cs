using AutoMapper;
using GolfClapp.DB.Infrastructure.RepositoryServices;
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
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        private readonly IMapper _mapper;
        public LogService(IMapper mapper, ILogRepository logRepository) 
        {
            _mapper = mapper;
            _logRepository = logRepository;
        }

        

        public LogDTO SaveInfoLog(string message)
        {
            var log = new LogDTO()
            {
                Id = Guid.NewGuid(),
                Message = message,
                ErrorLog = false
            };
            _logRepository.Save(_mapper.Map<LogDTO, LogEntity>(log));
            return log;
        }
        public LogDTO SaveErrorLog(string message)
        {
            var log = new LogDTO()
            {
                Id = Guid.NewGuid(),
                Message = message,
                ErrorLog = true
            };
            _logRepository.Save(_mapper.Map<LogDTO, LogEntity>(log));
            return log;
        }
    }
}

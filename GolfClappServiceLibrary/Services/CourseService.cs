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
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        
        public CourseService(IMapper mapper, ICourseRepository courseRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
        }


        public BaseResponseDTO Save(CourseDTO course)
        {
            var response = new BaseResponseDTO();
            try
            {
                _courseRepository.Save(_mapper.Map<CourseDTO, CourseEntity>(course));
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

        public CourseDTO GetById(Guid id)
        {

            return _mapper.Map<CourseEntity, CourseDTO>(_courseRepository.Get(id));           
        }

        public CourseDTO GetByImasterId(int id)
        {

            return _mapper.Map<CourseEntity, CourseDTO>(_courseRepository.GetByImasterId(id));
        }

        public List<CourseDTO> Get()
        {
            return _mapper.Map<List<CourseEntity>, List<CourseDTO>>(_courseRepository.Get());
        }

        public BaseResponseDTO Remove(Guid id)
        {
            var response = new BaseResponseDTO();
            try
            {
                _courseRepository.Remove(id);
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

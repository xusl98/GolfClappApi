using AutoMapper;
using iMasterLibrary.Objects;
using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClapp.DB.Infrastructure.Mappings
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {
            CreateMap<UserEntity, UserDTO>().ReverseMap();
            CreateMap<LogEntity, LogDTO>().ReverseMap();
            CreateMap<ServiceProviderEntity, ServiceProviderDTO>().ReverseMap();
            CreateMap<CourseEntity, CourseDTO>().ReverseMap();
            CreateMap<GameEntity, GameDTO>().ReverseMap();
            CreateMap<GameUserEntity, GameUserDTO>().ReverseMap();
            CreateMap<IMasterProviderCourse, IMasterProviderCourseAvailability>().ReverseMap();
            CreateMap<AppIsBlockedEntity, AppIsBlockedDTO>().ReverseMap();
        }
    }
}

﻿using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClappServiceLibrary.ServiceInterfaces
{
    public interface ICourseService
    {        
        CourseDTO Save(CourseDTO course);
        CourseDTO GetById(Guid id);
        List<CourseDTO> Get();
        CourseDTO Remove(Guid id);


    }
}

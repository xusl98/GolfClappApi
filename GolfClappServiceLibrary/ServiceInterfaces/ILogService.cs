using ObjectsLibrary.DTOs;
using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClappServiceLibrary.ServiceInterfaces
{
    public interface ILogService
    {        
        LogDTO SaveInfoLog(string message);
        LogDTO SaveErrorLog(string message);
    }
}

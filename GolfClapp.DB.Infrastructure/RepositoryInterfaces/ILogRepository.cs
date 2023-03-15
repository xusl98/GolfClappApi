using ObjectsLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GolfClapp.DB.Infrastructure.RepositoryServices
{
    public interface ILogRepository
    {
        LogEntity Save(LogEntity log);
    }
}

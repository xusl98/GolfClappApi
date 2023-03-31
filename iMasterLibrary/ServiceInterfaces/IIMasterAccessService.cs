using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMasterLibrary.ServiceInterfaces
{
    public interface IIMasterAccessService
    {
        Task<string> GetSessionData();
    }
}

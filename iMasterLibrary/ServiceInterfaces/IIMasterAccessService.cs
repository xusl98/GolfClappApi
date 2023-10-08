using iMasterLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMasterLibrary.ServiceInterfaces
{
    public interface IIMasterAccessService
    {
        Task<IMasterAccessTokenResponseData> GetSessionData(string username, string password, int lifeSpanSeconds, string culture);
    }
}

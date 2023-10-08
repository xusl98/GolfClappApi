using iMasterLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMasterLibrary.ServiceInterfaces
{
    public interface IIMasterProviderCourseService
    {
        Task<IMasterProviderCourseResponseData> GetProviderCourses(int vendorId, int providerId, int tourOperatorId, int sessionId, string accessToken, string culture);
    }
}

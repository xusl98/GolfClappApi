using iMasterLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMasterLibrary.ServiceInterfaces
{
    public interface IIMasterProviderService
    {
        Task<IMasterProviderResponseData> GetProviders(int vendorId, int sessionId, string accessToken, string culture);
        Task<IMasterProviderAvailabilityResponseData> GetProvidersWithCourses(int vendorId, int sessionId, string accessToken, string culture, string playDate, string fromTime,
            string toTime, int players, int fromPrice, int toPrice, int pageSize, int pageNum);
    }
}

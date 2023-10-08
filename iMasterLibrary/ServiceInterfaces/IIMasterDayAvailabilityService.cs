using iMasterLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMasterLibrary.ServiceInterfaces
{
    public interface IIMasterDayAvailabilityService
    {
        Task<IMasterDayAvailabilityResponseData> GetDayAvailability(
            int vendorId, int providerId, int tourOperatorId, int sessionId,
            string accessToken, string culture, int courseId, string playDate,
            string fromTime, string toTime, int players, int fromPrice,
            int toPrice, int pageSize, int pageNum, string promoCode);
    }
}

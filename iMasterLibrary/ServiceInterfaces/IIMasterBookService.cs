using iMasterLibrary.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMasterLibrary.ServiceInterfaces
{
    public interface IIMasterBookService
    {
        Task<IMasterPreBookingResponseData> PreBook(IMasterPreBookingRequestDTO br);
        Task<int> ConfirmBook(IMasterBookingConfirmationRequestDTO bcr);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iMasterLibrary.Objects
{
    public class IMasterDayAvailabilityResponseData : IMasterResponseData
    {
        public string PromoCodeMsg { get; set; }
        public bool PromoCodeValid { get; set; }
        public int Fee { get; set; }
        public bool TotalCharge { get; set; }
        public List<TeeTimeAvailable> TeeTimesAvailable { get; set; }

    }

    public class TeeTimeAvailable
    {
        public DateTime Time { get; set; }
        public int CourseID { get; set; }
        public int PlayersAvailable { get; set; }
        public List<Rate> RatesList { get; set; }
        public int RatesCount { get; set; }

    }
    public class Rate
    {
        public int RateID { get; set; }
        public int RateTimeID { get; set; }
        public int RateTypeID { get; set; }
        public int PackagePriceMenuMultiplier { get; set; }
        public int PromoCodeID { get; set; }
        public string RateName { get; set; }
        public string RateComments { get; set; }
        public int SellPrice { get; set; }
        public int RackPrice { get; set; }
        public int DiscountPercentage { get; set; }
        public List<int> BookablePlayers { get; set; }
        public int BookablePlayersCount { get; set; }
        public List<string> ServicesIncluded { get; set; }
        public int ServicesIncludedCount { get; set; }
        public int YieldDiscountId { get; set; }
    }

    


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Zhuna
{
    public class ZhunaHotelRoomPlanAddValue
    {
        public int AddValueID { set; get; }
        public string BusinessCode { set; get; }
        public int IsInclude { set; get; }
        public int IncludedCount { set; get; }
        public string CurrencyCode { set; get; }
        public int PriceDefaultOption { set; get; }
        public int PriceNumber { set; get; }
        public int IsAdd { set; get; }
        public int SinglePriceOption { set; get; }
        public int SinglePrice { set; get; }
        public string Description { set; get; }
    }
}

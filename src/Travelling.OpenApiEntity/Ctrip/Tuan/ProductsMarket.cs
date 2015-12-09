using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Ctrip.Tuan
{
    public class ProductsMarket
    {
        public int ProductId { set; get; }
        public string StartDate { set; get; }
        public string EndDate { set; get; }
        public int DetailTipStyle { set; get; }
        public int ListTipStyle { set; get; }
        public int ListTipStyleLeft { set; get; }
        public string MarketType { set; get; }
        public string MarketType2 { set; get; }
        public int Price { set; get; }
    }
}

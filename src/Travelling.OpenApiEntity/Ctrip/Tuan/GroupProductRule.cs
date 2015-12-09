using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Ctrip.Tuan
{
    public class GroupProductRule
    {
        public string RuleDescription { set; get; }
        public string InvoiceText { set; get; }
        public int DayLimit { set; get; }
        public int MinSale { get; set; }
        public int MaxSale { set; get; }
        public int MinSaleUnit { set; get; }
        public int MaxSaleUnit { set; get; }

        public int SaledItemCount { set; get; }

        public int PaymentItemCount { set; get; }
        public int CompletedItemCount { set; get; }
    }
}

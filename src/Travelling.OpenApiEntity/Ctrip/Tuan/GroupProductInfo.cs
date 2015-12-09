using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Ctrip.Tuan
{
    public class GroupProductInfo
    {
        public int ProductID { set; get; }
        public int Quantity { set; get; }
        public string IsRobItem { set; get; }
        public int SortIndex { set; get; }
        public int ProductStatus { set; get; }
        public string SoldOut { set; get; }
        public int AllowInvoice { set; get; }
        public int ProductItemType { set; get; }
        public string ProductURL { set; get; }
        public string HotelName { set; get; }
        public int CtripID { set; get; }

        public int SalePrice { set; get; }
        public int ShowPrice { set; get; }
        public int ListingPrice { set; get; }
        public int NowPrice { set; get; }

        public string StartDate { set; get; }
        public string EndDate { set; get; }
        public string DisplayEndDate { set; get; }

        public TicketEffectiveRange TicketEffectiveRange { set; get; }

        public List<GroupProductDescription> ProductDescriptions { set; get; }

        public List<GroupProductPicture> ProductPictures { set; get; }

        public int SaledItemCount { set; get; }
        public int PaymentItemCount { set; get; }
        public int CompletedItemCount { set; get; }

        public ProductScores ProductScores { set; get; }

        public List<GuaranteeInfo> GuaranteeInfos { set; get; }

        public List<VendorInfo> VendorInfos { set; get; }
    }
}

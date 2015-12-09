using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Ctrip.Tuan
{
    public class ProductDetailInfo
    {
        public string IsSupportAppoint { set; get; }
        public string IsShowCalendar { set; get; }
        public string ProductURL { set; get; }
        public string NoteUrl { set; get; }
        public string NotApplicableDate { set; get; }
        public string IsDirect { set; get; }
        public string ProductName { set; get; }
        public string Creator { set; get; }
        public int ProductItemType { set; get; }
        public int Quantity { set; get; }
        public string IsRobItem{set;get;}

        public int ProductID { set; get; }

        public string Name { set; get; }
        public string SoldOut { set; get; }
        public int AllowInvoice { set;get;}

        public int SortIndex { set; get; }
        public int ProductStatus { set; get; }

        public int SalePrice { set; get; }
        public int ShowPrice { set; get; }
        public int ListingPrice { set; get; }
        public int NowPrice { set; get; }

        public string StartDate { set; get; }
        public string EndDate { set; get; }
        public string DisplayEndDate { set; get; }
        public string BookingPhone { set; get; }
        public string BookingPhoneDescription { set; get; }

        public List<GroupProductDescription> ProductDescriptions { set; get; }

        public GroupProductRule ProductRule { set; get; }

        public int SaledItemCount { set; get; }
        public int PaymentItemCount { set; get; }
        public int CompletedItemCount { set; get; }

        public TicketEffectiveRange TicketEffectiveRange { set; get; }

        public List<GroupHotelInfo> hotelinfos { set; get; }

        public List<GuaranteeInfo> GuaranteeInfos { set; get; }

        public CategoryInfo CategoryInfo { set; get; }

        public List<VendorInfo> VendorInfos { set; get; }

        public List<GroupProductPicture> ProductPictures { set; get; }
    }
}

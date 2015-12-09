using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Ctrip.Tuan
{
    public class GroupProductListEntity
    {
        public int Status { set; get; }
        public int OrderDayLimit { set; get; }
        public int Guarantee { set; get; }
        public string Rule { set; get; }
        public string Desc { set; get; }
        public int HotelCount { set; get; }
        public string OUrl { set; get; }
        public int LocationId { set; get; }
        public string ProductItemType { set; get; }
        public string SoldOut { set; get; }
        public string LabelValue { set; get; }
        public int HotelID { set; get; }
        public int ItemType { set; get; }
        public decimal Rate { set; get; }
        public string StartDate { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string EndDate { set; get; }
        public string ExpirationStartTime { set; get; }
        public int ProductId { set; get; }
        public int NowPrice { set; get; }
        public int Price { set; get; }
        public int ProductPrice { set; get; }
        public string Pictures { set; get; }
        public int SaledItemCount { set; get; }
        public string Url { set; get; }
        public string IsGroup { set; get; }
        public string BookingPhone { set; get; }
        public int IsRefund { set; get; }
        public int IsFree { set; get; }
        public int IsComment { set; get; }
        public string DicDescription { set; get; }
        public int VendorID { set; get; }

        public ProductsMarket ProductsMarket { set; get; }

        public List<GroupProductHotelEntity> productHotels { set; get; }
    }
}

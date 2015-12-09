using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.ViewModel.Dto.Hotel;

namespace Travelling.ViewModel.Travel
{
    public class HotelRoomRateViewModel : HotelRoomInfo
    {
        public int RoomTypeCode { get; set; }
        public string RoomTypeName { set; get; }
        public string BedTypeCode { set; get; }
        public string BedTypeName { set; get; }
        public int NumberOfBreakfast { set; get; }
        public string Internet { set; get; }
        public string Policy { set; get; }
        public int AmountBeforeTax { set; get; }
        public DateTime Date { set; get; }
        public int HoteId { set; get; }

        public int CancelAmount { set; get; }

        public string SmallImage { set; get; }
        public string BigImg { set; get; }

        public int RateCategoryCode { set; get; }
    }
}

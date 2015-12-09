using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Travel
{
    public class HotelRoomPriceInfo
    {
        public int HotelId { set; get; }
        public string RoomTypeName { set; get; }

        public int RoomTypeCode { set; get; }

        public int AmountBeforeTax { set; get; }

        public int ListPrice { set; get; }

        public int NumberOfBreakfast { set; get; }

        public DateTime? StartTime { set; get; }

        public string BedTypeCode { set; get; }
    }
}

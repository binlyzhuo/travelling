using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.TravelInterface.Data.HotelSyncRecord;

namespace Travelling.DataProvider.HotelSyncRecord
{
    public class HotelLuceneIndexBusinessLogic
    {
        private readonly IXC_HotelDescriptionDataProvider hotelDescSyncData;
        public HotelLuceneIndexBusinessLogic()
        {
            hotelDescSyncData = new XC_HotelDescriptionDataProvider();
        }

        public void CreateHotelDexcriptionIndex()
        {
            var records = hotelDescSyncData.GetHotelInfoByIndexState();

        }
    }
}

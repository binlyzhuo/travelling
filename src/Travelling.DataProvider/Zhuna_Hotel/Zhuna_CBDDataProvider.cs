using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Zhuna_Hotel;
using Travelling.TravelInterface.Data.Zhuna;
using Travelling.ViewModel.Travel;

namespace Travelling.DataProvider.Zhuna_Hotel
{
    public class Zhuna_CBDDataProvider : BaseRecord<Zhuna_CBD>, IZhuna_CBDDataProvider
    {
        public Zhuna_CBDDataProvider()
        {
            this.defaultDatabase = OTA_TCHotelDatabase;
        }

        public List<TradeAreaInfo> HotCityTradeAreaGet()
        {
            string executeSQL = "execute P_HotelTradeAreaGet";
            var items = defaultDatabase.Fetch<TradeAreaInfo>(executeSQL);
            return items;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Zhuna_Hotel;
using Travelling.TravelInterface.Data.Zhuna;
using Travelling.ViewModel.Travel;

namespace Travelling.DataProvider.Zhuna_Hotel
{
    public class Zhuna_SchoolInfoDataProvider : BaseRecord<Zhuna_SchoolInfo>, IZhuna_SchoolInfoDataProvider
    {
        public Zhuna_SchoolInfoDataProvider()
        {
            this.defaultDatabase = OTA_TCHotelDatabase;
        }

        public Tuple<List<SchoolSummaryInfo>, List<SchoolCityInfo>> SchoolSummaryInfos()
        {
            string executeSQL = "execute P_GetCitySchools";
            var items = defaultDatabase.FetchMultiple<SchoolSummaryInfo, SchoolCityInfo>(executeSQL);
            return items;
        }
    }
}

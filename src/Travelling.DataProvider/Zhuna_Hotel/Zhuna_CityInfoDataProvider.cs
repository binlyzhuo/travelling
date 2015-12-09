using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Zhuna_Hotel;
using Travelling.TravelInterface.Data.Zhuna;
using Travelling.DataLayer;


namespace Travelling.DataProvider.Zhuna_Hotel
{
    public class Zhuna_CityInfoDataProvider : BaseRecord<Zhuna_CityInfo>, IZhuna_CityInfoDataProvider
    {
        public Zhuna_CityInfoDataProvider()
        {
            this.defaultDatabase = OTA_TCHotelDatabase;
        }

        public Zhuna_CityInfo GetToSyncHotelInfo()
        {
            Sql where = Sql.Builder.Where("SyncState=0");
            return Top(1, where).SingleOrDefault();
        }

        public int GetSyncStateCount(int syncState)
        {
            Sql where = Sql.Builder.Where("SyncState=@0",syncState);
            return Count(where);
        }

        public bool InitSyncState()
        {
            string sql = "update Zhuna_CityInfo set syncstate=0";
            return defaultDatabase.Execute(sql)>0;
        }
       
    }
}

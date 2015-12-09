using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Zhuna_Hotel;
using Travelling.TravelInterface.Data.Zhuna;
using Travelling.DataLayer;
using Travelling.FrameWork;

namespace Travelling.DataProvider.Zhuna_Hotel
{
    public class Zhuna_CityLableDataProvider : BaseRecord<Zhuna_CityLable>, IZhuna_CityLableDataProvider
    {
        public Zhuna_CityLableDataProvider()
        {
            this.defaultDatabase = OTA_TCHotelDatabase;
        }

        public List<Zhuna_CityLable> GetLablesToIndex()
        {
            Sql where = Sql.Builder.Where("indexstate=0");
            return Top(100,where).ToList();
        }

        public void UpdateIndexState(List<int> idList)
        {
            string update = string.Format("update Zhuna_CityLable set indexstate =1 where id in ({0})",idList.Join(","));
            defaultDatabase.Execute(update);
        }

        public void InitIndexState()
        {
            string update = "update Zhuna_CityLable set indexstate =0";
            defaultDatabase.Execute(update);
        }

        public int GetIndexStateCount(int indexstate)
        {
            Sql where = Sql.Builder.Where("indexstate=@0",indexstate);
            return Count(where);
        }
    }
}

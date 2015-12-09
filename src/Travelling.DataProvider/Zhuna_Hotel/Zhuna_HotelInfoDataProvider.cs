using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;
using Travelling.Domain.Zhuna_Hotel;
using Travelling.TravelInterface.Data.Zhuna;
using Travelling.ViewModel.Lucene;
using Travelling.FrameWork;

namespace Travelling.DataProvider.Zhuna_Hotel
{
    /// <summary>
    /// 住哪酒店数据源
    /// </summary>
    public class Zhuna_HotelInfoDataProvider : BaseRecord<Zhuna_HotelInfo>, IZhuna_HotelInfoDataProvider
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Zhuna_HotelInfoDataProvider()
        {
            this.defaultDatabase = OTA_TCHotelDatabase;
        }

        /// <summary>
        /// 获取待索引酒店信息
        /// </summary>
        /// <returns></returns>
        public List<HotelLuceneIndexInfo> HotelInfoToLucene()
        {
            string executeSql = string.Format("exec {0}", ZhunaDataProc.ZhunaHotelLuceneIndex);
            var hotelinfos = defaultDatabase.Fetch<HotelLuceneIndexInfo>(executeSql);
            return hotelinfos;
        }

        /// <summary>
        /// 更新lucene索引状态
        /// </summary>
        /// <param name="hotelList"></param>
        /// <returns></returns>
        public bool UpdateHotelLuceneIndexState(List<int> hotelList)
        {
            string hotelstring = hotelList.Join(",");
            string exeuteSQL = string.Format("update Zhuna_HotelInfo set isindex=1 where id in({0})",hotelstring);
            return defaultDatabase.Execute(exeuteSQL)>0;
        }

        /// <summary>
        /// 初始化索引状态
        /// </summary>
        /// <returns></returns>
        public bool UpdateHotelLuceneIndexStateInit()
        {
            string executeSQL = "update Zhuna_HotelInfo set isindex=0;";
            return defaultDatabase.Execute(executeSQL) > 0;
        }

        /// <summary>
        /// 获取索引酒店个数
        /// </summary>
        /// <param name="indexState"></param>
        /// <returns></returns>
        public int GetHotelLuceneStateCount(int indexState)
        {
            Sql where = Sql.Builder.Where("isindex=@0",indexState);
            return Count(where);
        }
    }
}

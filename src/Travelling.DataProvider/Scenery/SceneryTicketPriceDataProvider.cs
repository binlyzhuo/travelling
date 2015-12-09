using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.TravelInterface.Data;
using Travelling.DataLayer;
using Travelling.FrameWork;

namespace Travelling.DataProvider
{
    /// <summary>
    /// 景区门票价格信息
    /// </summary>
    public class SceneryTicketPriceDataProvider : BaseRecord<T_SceneryTicketPrice>, ISceneryTicketPriceDataProvider
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SceneryTicketPriceDataProvider()
        {
            this.defaultDatabase = sceneryDb;
        }

        /// <summary>
        /// 根据景区获取相关价格信息
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <returns></returns>
        public List<T_SceneryTicketPrice> GetTicketPriceBySceneryId(int sceneryId)
        {
            Sql whereSql = Sql.Builder.Where("SceneryID=@0 and BeginDate<=GETDATE() and EndDate>=GETDATE()", sceneryId);
            return defaultDatabase.Query<T_SceneryTicketPrice>(whereSql).ToList();
        }

        /// <summary>
        /// 根据景区获取相关价格信息
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <returns></returns>
        public List<T_SceneryTicketPrice> GetTicketPriceBySceneryId(List<int> sceneryList)
        {
            Sql whereSql = Sql.Builder.Where(string.Format("SceneryID in({0}) and BeginDate<=GETDATE() and EndDate>=GETDATE()", sceneryList.Join(",")));
            return defaultDatabase.Query<T_SceneryTicketPrice>(whereSql).ToList();
        }

        /// <summary>
        /// 获取景区门票信息
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <param name="ticketId"></param>
        /// <param name="bookDate"></param>
        /// <returns></returns>
        public T_SceneryTicketPrice GetTicketPriceByTicket(int sceneryId, int policyID, DateTime bookDate)
        {
            Sql whereSql = Sql.Builder.Where(string.Format("SceneryID={0} and PolicyID={1} and BeginDate<='{2}' and EndDate>='{2}'", sceneryId, policyID, bookDate.ToString("yyyy-MM-dd")));
            return defaultDatabase.SingleOrDefault<T_SceneryTicketPrice>(whereSql);

        }
    }
}

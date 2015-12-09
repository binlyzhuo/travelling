using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Scenery;
using Travelling.TravelInterface.Data.SceneryTicket;
using Travelling.DataLayer;
using Travelling.ViewModel.Dto.Ticket;
using Travelling.ViewModel.Admin;

namespace Travelling.DataProvider.Scenery
{
    /// <summary>
    /// 景区门票信息数据接口
    /// </summary>
    public class SceneryTicketOrderDataProvider : BaseRecord<T_SceneryTicketOrder>, ISceneryTicketOrderDataProvider
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public SceneryTicketOrderDataProvider()
        {
            this.defaultDatabase = sceneryDb;
        }

        /// <summary>
        /// 根据订单号获取订单信息
        /// </summary>
        /// <param name="orderserial"></param>
        /// <returns></returns>
        public T_SceneryTicketOrder GetSceneryOrderBySerial(string orderserial)
        {
            Sql whereSql = Sql.Builder.Where("SerialNo = @0", orderserial);
            var orderinfo = defaultDatabase.SingleOrDefault<T_SceneryTicketOrder>(whereSql);
            return orderinfo;
        }

        public Page<T_SceneryTicketOrder> SceneryTicketOrderGetPageResult(SceneryTicketOrderSearchModel search)
        {
            Sql whereSQL = Sql.Builder.Where("1=1").OrderBy("AddDate desc");
            var pageResult = defaultDatabase.Page<T_SceneryTicketOrder>(search.PageIndex, search.PageSize, whereSQL);
            return pageResult;
        }
    }
}

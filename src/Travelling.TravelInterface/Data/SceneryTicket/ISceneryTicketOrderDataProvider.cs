using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;
using Travelling.Domain.Scenery;
using Travelling.ViewModel.Admin;
using Travelling.ViewModel.Dto.Ticket;

namespace Travelling.TravelInterface.Data.SceneryTicket
{
    /// <summary>
    /// 景区门票预定信息数据接口
    /// </summary>
    public interface ISceneryTicketOrderDataProvider : IDataProvider<T_SceneryTicketOrder>
    {
        /// <summary>
        /// 根据订单号获取订单信息
        /// </summary>
        /// <param name="orderserial"></param>
        /// <returns></returns>
        T_SceneryTicketOrder GetSceneryOrderBySerial(string orderserial);

        Page<T_SceneryTicketOrder> SceneryTicketOrderGetPageResult(SceneryTicketOrderSearchModel search);
    }
}

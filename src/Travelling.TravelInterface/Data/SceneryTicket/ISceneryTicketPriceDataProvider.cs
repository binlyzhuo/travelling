using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;

namespace Travelling.TravelInterface.Data
{
    /// <summary>
    /// 景区门票价格数据
    /// </summary>
    public interface ISceneryTicketPriceDataProvider : IDataProvider<T_SceneryTicketPrice>
    {
        /// <summary>
        /// 获取景区价格信息
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <returns></returns>
        List<T_SceneryTicketPrice> GetTicketPriceBySceneryId(int sceneryId);

        /// <summary>
        ///  获取景区价格信息
        /// </summary>
        /// <param name="sceneryList"></param>
        /// <returns></returns>
        List<T_SceneryTicketPrice> GetTicketPriceBySceneryId(List<int> sceneryList);

        /// <summary>
        /// 获取景区门票价格信息
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <param name="ticketId"></param>
        /// <param name="bookDate"></param>
        /// <returns></returns>
        T_SceneryTicketPrice GetTicketPriceByTicket(int sceneryId, int policyID, DateTime bookDate);
    }
}

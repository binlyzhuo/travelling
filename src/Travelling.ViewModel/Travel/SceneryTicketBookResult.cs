using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.ViewModel.Dto.Ticket;

namespace Travelling.ViewModel.Travel
{
    /// <summary>
    /// 景区门票预定结果
    /// </summary>
    public class SceneryTicketBookResult
    {
        /// <summary>
        /// 是否预定成功
        /// </summary>
        public bool Success { set; get; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { set; get; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMsg { set; get; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string ErrorCode { set; get; }

        /// <summary>
        /// 订单信息
        /// </summary>
        public SceneryTicketOrder OrderInfo { set; get; }

        /// <summary>
        /// 景区信息
        /// </summary>
        public SceneryInfoDetail SceneryInfo { set; get; }
    }
}

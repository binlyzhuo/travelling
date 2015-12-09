using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.ViewModel.Dto.Hotel;
using Travelling.ViewModel.Travel;

namespace Travelling.ViewModel.Hotel
{
    /// <summary>
    /// 酒店下单结果
    /// </summary>
    public class HotelOrderResult:JsonViewResult
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderNo { set; get; }

        /// <summary>
        /// 酒店订单信息
        /// </summary>
        public HotelBookingOrder OrderInfo { set; get; }

        /// <summary>
        /// 下单地址
        /// </summary>
        public string OrderUrl { set; get; }

        public List<HotelBookError> Errors { set; get; }
    }
}

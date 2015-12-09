using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;
using Travelling.Domain;
using Travelling.ViewModel.Admin;

namespace Travelling.TravelInterface.Data
{
    /// <summary>
    /// 酒店订单数据接口
    /// </summary>
    public interface IHotelBookingOrderDataProvider : IDataProvider<T_HotelBookingOrder>
    {
        /// <summary>
        /// 根据订单号查询订单信息
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        T_HotelBookingOrder GetBookOrderByOrderSerial(string orderNo);

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="orderno"></param>
        /// <param name="tel"></param>
        /// <returns></returns>
        T_HotelBookingOrder GetBookOrderByOrderNoAndTel(string orderno, string tel);

        Page<T_HotelBookingOrder> HotelBookingOrderGetPageResult(HotelOrderInfoSearchModel search);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.TravelInterface.Data;
using Travelling.DataLayer;
using Travelling.ViewModel.Admin;

namespace Travelling.DataProvider
{
    /// <summary>
    /// 酒店预定信息
    /// </summary>
    public class HotelBookingOrderDataProvider : BaseRecord<T_HotelBookingOrder>, IHotelBookingOrderDataProvider
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public HotelBookingOrderDataProvider()
        {
            this.defaultDatabase = TravelDatabase;
        }

        /// <summary>
        /// 根据订单号获取订单信息
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public T_HotelBookingOrder GetBookOrderByOrderSerial(string orderNo)
        {
            Sql whereSql = Sql.Builder.Where("SerialNo=@0",orderNo);
            var order = defaultDatabase.SingleOrDefault<T_HotelBookingOrder>(whereSql);
            return order;
        }

        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="orderno"></param>
        /// <param name="tel"></param>
        /// <returns></returns>
        public T_HotelBookingOrder GetBookOrderByOrderNoAndTel(string orderno,string tel)
        {
            Sql whereSql = Sql.Builder.Where("SerialNo=@0 and ContactPhone=@1",orderno,tel);
            var order = defaultDatabase.SingleOrDefault<T_HotelBookingOrder>(whereSql);
            return order;
        }

        public Page<T_HotelBookingOrder> HotelBookingOrderGetPageResult(HotelOrderInfoSearchModel search)
        {
            Sql where = Sql.Builder.Where("1=1").OrderBy("AddDate desc");

            var pageViewResult = defaultDatabase.Page<T_HotelBookingOrder>(search.PageIndex, search.PageSize, where);
            return pageViewResult;
        }
    }
}


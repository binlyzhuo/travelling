using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.OpenApiEntity.Scenery;
using Travelling.OpenApiEntity.TC.Hotel.Module;

namespace Travelling.OpenApiEntity.TC.Hotel
{
    /// <summary>
    /// 酒店房型请求返回实体
    /// </summary>
    public class GetHotelRoomsReturnEntity:TongChengBaseReturnEntity
    {
        /// <summary>
        /// 酒店ID
        /// </summary>
        public int hotelId { set; get; }

        /// <summary>
        /// 酒店名称
        /// </summary>
        public string hotelName { set; get; }

        /// <summary>
        /// 酒店类型
        /// 例如:Normal
        /// </summary>
        public string hotelType { set; get; }

        /// <summary>
        /// 对接编号
        /// </summary>
        public string hotelCode { set; get; }

        /// <summary>
        /// 连锁酒店编号
        /// </summary>
        public string hotelChainId { set; get; }

        /// <summary>
        /// 酒店房型列表
        /// </summary>
        public List<TCHotelRoomInfo> Rooms { set; get; }

        /// <summary>
        /// 图片位置
        /// 图片位置url前缀，默认为：http://ustatic.17u.cn/hotel
        /// </summary>
        public string imageBaseUrl { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.TC.Hotel
{
    /// <summary>
    /// 酒店房型信息查询实体
    /// </summary>
    public class GetHotelRoomsCallEntity:TongChengBaseCallEntity
    {
        /// <summary>
        /// 酒店ID
        /// </summary>
        public int hotelId { set; get; }

        /// <summary>
        /// 入住日期
        /// </summary>
        public DateTime comeDate { set; get; }

        /// <summary>
        /// 离店日期
        /// </summary>
        public DateTime leaveDate { set; get; }

        /// <summary>
        /// 页码
        /// </summary>
        public int page { set; get; }

        /// <summary>
        /// 每页条数
        /// </summary>
        public int pageSize { set; get; }

        /// <summary>
        /// 房型Id
        /// </summary>
        public int roomTypeId { set; get; }

        /// <summary>
        /// 房型策络ID
        /// </summary>
        public int pricePolicyId { set; get; }

        /// <summary>
        /// 是否只取默认政策
        /// 0全部政策
        /// 1默认政策
        /// 不传默认为0
        /// </summary>
        public int defaultPolicyFlag { set; get; }

        /// <summary>
        /// 记录条数
        /// </summary>
        public int recordCount { set; get; }

        /// <summary>
        /// 排序
        /// 政策和房型是否排序，true/false不传此参数则默认为需要排序
        /// </summary>
        public int isSort { set; get; }
    }
}

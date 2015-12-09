using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Zhuna
{
    /// <summary>
    /// 酒店房型以及价格查询结果
    /// </summary>
    public class ZhunaHotelPriceReturnEntity:ZhunaBaseReturnEntity
    {
        /// <summary>
        /// 酒店ID
        /// </summary>
        public int zid { set; get; }

        /// <summary>
        /// Elong酒店id 
        /// </summary>
        public string eid { set; get; }

        /// <summary>
        /// 到店日期
        /// </summary>
        public string tm1 { set; get; }

        /// <summary>
        /// 	离店日期 
        /// </summary>
        public string tm2 { set; get; }

        /// <summary>
        /// 酒店状态 (计划状态 非0不可订) 
        /// </summary>
        public string status { set; get; }

        /// <summary>
        /// 酒店ID
        /// </summary>
        public int hotelid { set; get; }

        /// <summary>
        /// 担保情况
        /// </summary>
        public string Promotion { set; get; }

        public List<ZhunaHotelRoomInfo> rooms { set; get; }
        public string debug { set; get; }
    }
}

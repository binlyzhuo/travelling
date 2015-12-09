using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.OpenApiEntity.Scenery;

namespace Travelling.OpenApiEntity.TC.Hotel
{
    /// <summary>
    /// 酒店查询返回实体
    /// </summary>
    public class GetHotelListReturnEntity : TongChengBaseReturnEntity
    {
        /// <summary>
        /// 酒店信息列表
        /// </summary>
        public List<TCHotelInfo> Hotels { set; get; }

        /// <summary>
        /// 图片地址前缀
        /// </summary>
        public string imageBaseUrl { set; get; }
    }
}

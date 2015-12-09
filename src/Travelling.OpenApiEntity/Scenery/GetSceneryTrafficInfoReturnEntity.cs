using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.OpenApiEntity.TC;

namespace Travelling.OpenApiEntity.Scenery
{
    /// <summary>
    /// 景区交通信息接口返回实体
    /// </summary>
    public class GetSceneryTrafficInfoReturnEntity : TongChengBaseReturnEntity
    {
        /// <summary>
        /// 景区ID
        /// </summary>
        public int sceneryId { set; get; }

        /// <summary>
        /// 经度
        /// </summary>
        public string longitude { set; get; }

        /// <summary>
        /// 纬度
        /// </summary>
        public string latitude { set; get; }

        /// <summary>
        /// 交通描述信息
        /// </summary>
        public string traffic { set; get; }
    }
}

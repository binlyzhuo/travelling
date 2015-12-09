using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Travel
{
    /// <summary>
    /// 景区交通信息
    /// </summary>
    public class SceneryTrafficInfo
    {
        /// <summary>
        /// 景区id
        /// </summary>
        public int SceneryId { set; get; }

        /// <summary>
        /// 景区名称
        /// </summary>
        public string SceneryName { set; get; }

        /// <summary>
        /// 交通描述信息
        /// </summary>
        public string Traffic { set; get; }

        /// <summary>
        /// 纬度
        /// </summary>
        public string Latitude { set; get; }

        /// <summary>
        /// 经度
        /// </summary>
        public string Longitude { set; get; }

        public string Address { set; get; }

        public string Img { set; get; }

    }
}

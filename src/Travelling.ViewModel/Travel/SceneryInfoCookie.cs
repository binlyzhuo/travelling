using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Travel
{
    /// <summary>
    /// 景区浏览信息
    /// </summary>
    public class SceneryInfoCookie
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
        /// 景区价格
        /// </summary>
        public int Amount { set; get; }

        /// <summary>
        /// 门市价格
        /// </summary>
        public int ListAmount { set; get; }

        /// <summary>
        /// 景区图片
        /// </summary>
        public string Img { set; get; }
    }
}

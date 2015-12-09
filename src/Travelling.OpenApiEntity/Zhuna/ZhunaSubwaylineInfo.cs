using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Zhuna
{
    public class ZhunaSubwaylineInfo
    {
        /// <summary>
        /// 线路id 
        /// </summary>
        public int zhuantiid { set; get; }
        public string title { set; get; }
        public string cityid { set; get; }
        public string cityname { set; get; }
        public int paixu { set; get; }
    }
}

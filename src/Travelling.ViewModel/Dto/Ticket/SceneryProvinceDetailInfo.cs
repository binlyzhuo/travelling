using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.Ticket
{
    public class SceneryProvinceDetailInfo
    {
        /// <summary>
        /// 省份ID或者城市ID
        /// </summary>
        public int ID
        {
            set;
            get;
        }
        /// <summary>
        /// 省份城市名称
        /// </summary>
        public string Name
        {
            set;
            get;
        }
        /// <summary>
        /// 省份城市拼音
        /// </summary>
        public string PinYin
        {
            set;
            get;
        }
        /// <summary>
        /// 省份城市索引
        /// </summary>
        public string PinYinIndex
        {
            set;
            get;
        }
        /// <summary>
        /// 省份ID
        /// </summary>
        public int ParentID
        {
            set;
            get;
        }
        /// <summary>
        /// 暂时顺序
        /// </summary>
        public int OrderNum
        {
            set;
            get;
        }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public int IsRecommend
        {
            set;
            get;
        }
        /// <summary>
        /// 景区个数
        /// </summary>
        public int SceneryCount
        {
            set;
            get;
        }
    }
}

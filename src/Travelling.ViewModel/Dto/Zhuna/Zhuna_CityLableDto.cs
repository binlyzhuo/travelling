using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.Zhuna
{
    public class Zhuna_CityLableDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int id
        {
            get;
            set;
        }
        /// <summary>
        /// 城市ID
        /// </summary>
        public string ecityid
        {
            get;
            set;
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string name
        {
            get;
            set;
        }
        /// <summary>
        /// 地标分类id
        /// </summary>
        public int classid
        {
            get;
            set;
        }
        /// <summary>
        /// 地标分类名称 
        /// </summary>
        public string classname
        {
            get;
            set;
        }
        /// <summary>
        /// string 附近酒店id
        /// </summary>
        public string roundhotel
        {
            get;
            set;
        }
        /// <summary>
        /// 经度
        /// </summary>
        public string x
        {
            get;
            set;
        }
        /// <summary>
        /// 纬度
        /// </summary>
        public string y
        {
            get;
            set;
        }
        /// <summary>
        /// 拼音
        /// </summary>
        public string pinyin
        {
            get;
            set;
        }
        /// <summary>
        ///  添加时间
        /// </summary>
        public DateTime adddate
        {
            get;
            set;
        }
    }
}

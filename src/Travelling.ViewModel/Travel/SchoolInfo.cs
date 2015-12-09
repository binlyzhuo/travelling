using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Travel
{
    /// <summary>
    /// 学校信息
    /// </summary>
    public class SchoolInfo
    {
        /// <summary>
        /// 学校名称
        /// </summary>
        public string SchoolName { set; get; }

        /// <summary>
        /// 学校名称
        /// </summary>
        public string CityName { set; get; }

        /// <summary>
        /// 城市名称
        /// </summary>
        public int CityId { set; get; }

        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName { set; get; }
        
        /// <summary>
        /// 省份id
        /// </summary>
        public int ProvinceId { set; get; }
    }
}

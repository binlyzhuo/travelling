using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Travel
{
    /// <summary>
    /// 景区查询信息
    /// </summary>
    public class SceneryQueryInfo : BasePageQuery
    {
        public SceneryQueryInfo()
        { }

        private string searchKey = "search";
        /// <summary>
        /// 省份ID
        /// </summary>
        public int ProvinceId { set; get; }

        public int CityID { set; get; }

        /// <summary>
        /// 主题ID
        /// </summary>
        public int ThemeId { set; get; }

        /// <summary>
        /// 星级
        /// </summary>
        public int Star { set; get; }

        /// <summary>
        /// 查询关键字
        /// </summary>
        public string KeyWord
        {
            get
            {
                return this.searchKey;
            }
            set
            {
                this.searchKey = value;
            }
        }

        /// <summary>
        /// 排序,0-默认，1-价格
        /// </summary>
        public int OrderBy { set; get; }
    }
}

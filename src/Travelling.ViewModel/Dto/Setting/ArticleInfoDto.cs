using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.Setting
{
    /// <summary>
    /// 新闻咨询
    /// </summary>
    public class ArticleInfoDto
    {
        
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            get;
            set;

        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get;
            set;
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            get;
            set;
        }
        /// <summary>
        /// 有效状态
        /// </summary>
        public int State
        {
            get;
            set;
        }
        /// <summary>
        /// 作者
        /// </summary>
        public string Author
        {
            get;
            set;
        }
        /// <summary>
        /// 标签
        /// </summary>
        public string Tag
        {
            get;
            set;
        }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName
        {
            get;
            set;
        }
        /// <summary>
        /// 创建者id
        /// </summary>
        public int UserID
        {
            get;
            set;
        }
        /// <summary>
        /// 类型
        /// </summary>
        public int Type
        {
            get;
            set;
        }
    }
}

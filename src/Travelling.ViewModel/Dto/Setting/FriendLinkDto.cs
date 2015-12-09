using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.Setting
{
    public class FriendLinkDto
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set;
            get;
        }
        /// <summary>
        /// 网站名称
        /// </summary>
        public string Name
        {
            set;
            get;
        }
        /// <summary>
        /// 链接
        /// </summary>
        public string LinkUrl
        {
            set;
            get;
        }
        /// <summary>
        /// 有效状态
        /// </summary>
        public int State
        {
            set;
            get;
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            set;
            get;
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan
        {
            set;
            get;
        }
        /// <summary>
        /// 添加人
        /// </summary>
        public string Creator
        {
            set;
            get;
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int OrderIndex
        {
            set;
            get;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.User
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class AccountInfo
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
        /// 用户名
        /// </summary>
        public string Name
        {
            set;
            get;
        }
        /// <summary>
        /// 用户Email
        /// </summary>
        public string Email
        {
            set;
            get;
        }
        
        /// <summary>
        /// 用户状态,0-无效,1-有效,2-锁定
        /// </summary>
        public int State
        {
            set;
            get;
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            set;
            get;
        }
        /// <summary>
        /// 上次修改时间
        /// </summary>
        public DateTime UpdateTime
        {
            set;
            get;
        }

        public string Password { set; get; }
    }
}

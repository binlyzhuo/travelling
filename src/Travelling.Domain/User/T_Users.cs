using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain
{
    /// <summary>
    /// Users:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_Users
    {
        public T_Users()
        { }

        #region Model
        private int _id;
        private string _uname = "";
        private DateTime _adddate = DateTime.Now;

        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UName
        {
            set { _uname = value; }
            get { return _uname; }
        }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        #endregion Model

    }
}

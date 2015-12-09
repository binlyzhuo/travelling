using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain
{
    /// <summary>
    /// 管理员日志
    /// </summary>
    [Serializable]
    public partial class T_AccountLog
    {
        public T_AccountLog()
        { }
        private decimal _id;
        private int _accountid = 0;
        private string _content = "";
        private DateTime _createtime = DateTime.Now;
        private string _creator;
        private int _type;
        /// <summary>
        /// 主键
        /// </summary>
        public decimal ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 操作人ID
        /// </summary>
        public int AccountId
        {
            set { _accountid = value; }
            get { return _accountid; }
        }
        /// <summary>
        /// 日志内容
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public string Creator
        {
            set { _creator = value; }
            get { return _creator; }
        }
        /// <summary>
        /// 日志类型
        /// </summary>
        public int Type
        {
            set { _type = value; }
            get { return _type; }
        }

    }
}

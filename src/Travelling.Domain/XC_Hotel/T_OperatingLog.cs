using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain.HotelSyncRecord
{
    /// <summary>
    /// 系统操作日志
    /// </summary>
    [Serializable]
    public partial class T_OperatingLog
    {
        public T_OperatingLog()
        { }
        #region Model
        private int _id;
        private DateTime _adddate = DateTime.Now;
        private string _content = "";
        private int _creatorid = 0;
        private string _creator;
        private string _ip = "";
        private int _projecttype = 0;
        private DateTime _startdate = DateTime.Now;
        private DateTime _enddate = Convert.ToDateTime("1900-1-1");
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 操作内容
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 创建人ID
        /// </summary>
        public int CreatorId
        {
            set { _creatorid = value; }
            get { return _creatorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Creator
        {
            set { _creator = value; }
            get { return _creator; }
        }
        /// <summary>
        /// 操作人IP
        /// </summary>
        public string IP
        {
            set { _ip = value; }
            get { return _ip; }
        }
        /// <summary>
        /// 所属项目
        /// </summary>
        public int ProjectType
        {
            set { _projecttype = value; }
            get { return _projecttype; }
        }
        /// <summary>
        /// 任务开始时间
        /// </summary>
        public DateTime StartDate
        {
            set { _startdate = value; }
            get { return _startdate; }
        }
        /// <summary>
        /// 任务结束时间
        /// </summary>
        public DateTime EndDate
        {
            set { _enddate = value; }
            get { return _enddate; }
        }
        #endregion Model

    }
}

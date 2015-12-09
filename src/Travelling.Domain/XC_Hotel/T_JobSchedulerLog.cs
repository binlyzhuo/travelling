using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain.HotelSyncRecord
{
    /// <summary>
    /// job日志
    /// </summary>
    [Serializable]
    public partial class T_JobSchedulerLog
    {
        public T_JobSchedulerLog()
        { }
        #region Model
        private int _id;
        private int _jobid = 0;
        private DateTime _adddate = DateTime.Now;
        private DateTime _startdate = Convert.ToDateTime("1900-1-1");
        private DateTime _enddate = Convert.ToDateTime("1900-1-1");
        private string _jobname = "";
        private string _remark = "";
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 任务ID
        /// </summary>
        public int JobId
        {
            set { _jobid = value; }
            get { return _jobid; }
        }
        /// <summary>
        /// 添加运行时间
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 开始运行时间
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
        /// <summary>
        /// 任务名称
        /// </summary>
        public string JobName
        {
            set { _jobname = value; }
            get { return _jobname; }
        }
        /// <summary>
        /// 任务备注信息
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

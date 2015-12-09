using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain.HotelSyncRecord
{
    /// <summary>
    ///  计划任务
    /// </summary>
    [Serializable]
    public partial class T_JobScheduler
    {
        public T_JobScheduler()
        { }
        #region Model
        private int _id;
        private string _jobname = "";
        private string _jobmethodname = "";
        private string _cronexpr = "";
        private DateTime _adddate = DateTime.Now;
        private string _groupname = "";
        private int _state = 1;
        private int _projectid = 0;
        private string _remark;
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
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
        /// 方法名称
        /// </summary>
        public string JobMethodName
        {
            set { _jobmethodname = value; }
            get { return _jobmethodname; }
        }
        /// <summary>
        /// Cron表达式
        /// </summary>
        public string CronExpr
        {
            set { _cronexpr = value; }
            get { return _cronexpr; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// GroupName
        /// </summary>
        public string GroupName
        {
            set { _groupname = value; }
            get { return _groupname; }
        }
        /// <summary>
        /// 任务状态
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 项目id，0-酒店,1-景区
        /// </summary>
        public int ProjectId
        {
            set { _projectid = value; }
            get { return _projectid; }
        }
        /// <summary>
        /// 任务描述 信息
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.HotelSyncRecord
{
    /// <summary>
    /// 定时任务
    /// </summary>
    public class JobScheduler
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
        /// 方法
        /// </summary>
        public string JobName
        {
            set;
            get;
        }

        /// <summary>
        /// 方法
        /// </summary>
        public string JobMethodName
        {
            set;
            get;
        }

        /// <summary>
        /// Cron表达式
        /// </summary>
        public string CronExpr
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
        /// 状态
        /// </summary>
        public int State
        {
            set;
            get;
        }

        public string GroupName
        {
            get;
            set;
        }

        public int ProjectId { set; get; }

        public string Remark { set; get; }
    }
}

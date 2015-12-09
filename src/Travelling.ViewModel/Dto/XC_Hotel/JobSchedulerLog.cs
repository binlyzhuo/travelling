using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.HotelSyncRecord
{
    public class JobSchedulerLog
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
        /// 任务ID
        /// </summary>
        public int JobId
        {
            set;
            get;
        }
        /// <summary>
        /// 添加运行时间
        /// </summary>
        public DateTime AddDate
        {
            set;
            get;
        }
        /// <summary>
        /// 开始运行时间
        /// </summary>
        public DateTime StartDate
        {
            set;
            get;
        }
        /// <summary>
        /// 任务结束时间
        /// </summary>
        public DateTime EndDate
        {
            set;
            get;
        }
        /// <summary>
        /// 任务名称
        /// </summary>
        public string JobName
        {
            set;
            get;
        }
        /// <summary>
        /// 任务备注信息
        /// </summary>
        public string Remark
        {
            set;
            get;
        }
    }
}

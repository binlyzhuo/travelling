using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.HotelSyncRecord
{
    public class OperatingLog
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
        /// 创建时间
        /// </summary>
        public DateTime AddDate
        {
            set;
            get;
        }
        /// <summary>
        /// 操作内容
        /// </summary>
        public string Content
        {
            set;
            get;
        }
        /// <summary>
        /// 创建人ID
        /// </summary>
        public int CreatorId
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Creator
        {
            set;
            get;
        }
        /// <summary>
        /// 操作人IP
        /// </summary>
        public string IP
        {
            set;
            get;
        }
        /// <summary>
        /// 所属项目
        /// </summary>
        public int ProjectType
        {
            set;
            get;
        }
        /// <summary>
        /// 任务开始时间
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
    }
}

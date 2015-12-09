using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.HotelSyncRecord
{
    public class HotelRoomRateJobScheduler
    {
        /// <summary>
        ///  主键
        /// </summary>
        public int ID
        {
            set;
            get;
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDate
        {
            set;
            get;
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate
        {
            set;
            get;
        }
        /// <summary>
        /// 同步状态
        /// </summary>
        public int SyncState
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

        public int State { set; get; }
    }
}

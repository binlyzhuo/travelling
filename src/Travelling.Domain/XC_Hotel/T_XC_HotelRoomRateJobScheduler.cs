using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain.HotelSyncRecord
{
    /// <summary>
    /// 酒店信息同步记录
    /// </summary>
    [Serializable]
    public partial class T_XC_HotelRoomRateJobScheduler
    {
        public T_XC_HotelRoomRateJobScheduler()
        { }
        #region Model
        private int _id;
        private DateTime _startdate = DateTime.Now;
        private DateTime _enddate = Convert.ToDateTime("1900-1-1");
        private int _syncstate = 0;
        private DateTime _adddate = DateTime.Now;
        private int _state = 1;
        /// <summary>
        ///  主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartDate
        {
            set { _startdate = value; }
            get { return _startdate; }
        }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndDate
        {
            set { _enddate = value; }
            get { return _enddate; }
        }
        /// <summary>
        /// 同步状态
        /// </summary>
        public int SyncState
        {
            set { _syncstate = value; }
            get { return _syncstate; }
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
        /// 任务状态
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        #endregion Model

    }
}

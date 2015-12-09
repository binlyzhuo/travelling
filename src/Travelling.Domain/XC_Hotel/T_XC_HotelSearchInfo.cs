using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;

namespace Travelling.Domain.HotelSyncRecord
{
    /// <summary>
    /// 酒店查询信息
    /// </summary>
    [Serializable]
    [PrimaryKey("HotelID",AutoIncrement=false)]
    public partial class T_XC_HotelSearchInfo
    {
        public T_XC_HotelSearchInfo()
        { }
        #region Model
        private int _hotelid;
        private string _hotelname;
        private DateTime _syncdate = Convert.ToDateTime("1900-1-1");
        private DateTime _adddate = DateTime.Now;
        private int _syncsate = 0;
        private int _pricesyncstate = 0;
        private int _cityid = 0;
        private int _unionid = 0;
        /// <summary>
        /// 
        /// </summary>
        public int HotelID
        {
            set { _hotelid = value; }
            get { return _hotelid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HotelName
        {
            set { _hotelname = value; }
            get { return _hotelname; }
        }
        /// <summary>
        /// 同步时间
        /// </summary>
        public DateTime SyncDate
        {
            set { _syncdate = value; }
            get { return _syncdate; }
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
        /// 同步状态
        /// </summary>
        public int SyncSate
        {
            set { _syncsate = value; }
            get { return _syncsate; }
        }
        /// <summary>
        /// 价格同步状态
        /// </summary>
        public int PriceSyncState
        {
            set { _pricesyncstate = value; }
            get { return _pricesyncstate; }
        }
        /// <summary>
        /// 城市ID
        /// </summary>
        public int CityID
        {
            set { _cityid = value; }
            get { return _cityid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int UnionID
        {
            set { _unionid = value; }
            get { return _unionid; }
        }
        #endregion Model

    }
}

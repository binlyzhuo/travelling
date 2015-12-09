using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain.HotelSyncRecord
{
    /// <summary>
    /// 热点信息
    /// </summary>
    [Serializable]
    public partial class T_XC_HotelAreaInfo
    {
        public T_XC_HotelAreaInfo()
        { }
        #region Model
        private int _id;
        private decimal _distance = 0M;
        private int _unitofmeasurecode = 2;
        private string _name = "";
        private DateTime _adddate = DateTime.Now;
        private int _typecode = 0;
        private int _hotelid = 0;
        private int _cityid = 0;
        private int _syncstate = 0;
        private int _areaid = 0;
        /// <summary>
        ///  主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 距离
        /// </summary>
        public decimal Distance
        {
            set { _distance = value; }
            get { return _distance; }
        }
        /// <summary>
        /// 距离单位,km
        /// </summary>
        public int UnitOfMeasureCode
        {
            set { _unitofmeasurecode = value; }
            get { return _unitofmeasurecode; }
        }
        /// <summary>
        /// 名字
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
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
        /// 类型
        /// </summary>
        public int TypeCode
        {
            set { _typecode = value; }
            get { return _typecode; }
        }
        /// <summary>
        /// 酒店ID
        /// </summary>
        public int HotelID
        {
            set { _hotelid = value; }
            get { return _hotelid; }
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
        /// 同步状态
        /// </summary>
        public int SyncState
        {
            set { _syncstate = value; }
            get { return _syncstate; }
        }

        /// <summary>
        /// 区域ID
        /// </summary>
        public int AreaID
        {
            set { _areaid = value; }
            get { return _areaid; }
        }
        #endregion Model

    }
}

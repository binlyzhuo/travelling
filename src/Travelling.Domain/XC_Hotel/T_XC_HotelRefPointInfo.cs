using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain.HotelSyncRecord
{
    /// <summary>
    /// 附近热点信息
    /// </summary>
    [Serializable]
    public partial class T_XC_HotelRefPointInfo
    {
        public T_XC_HotelRefPointInfo()
        { }
        #region Model
        private int _id;
        private int _hotelid = 0;
        private string _name = "";
        private string _refpointname = "";
        private string _descriptivetext = "";
        private decimal _distance = 0M;
        private int _unitofmeasurecode = 2;
        private int _refpointcategorycode = 0;
        private string _latitude = "";
        private string _longitude = "";
        private DateTime _adddate = DateTime.Now;
        private int _syncstate = 0;
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
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
        /// 热点名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 热点类型名称
        /// </summary>
        public string RefPointName
        {
            set { _refpointname = value; }
            get { return _refpointname; }
        }
        /// <summary>
        /// 描述信息
        /// </summary>
        public string DescriptiveText
        {
            set { _descriptivetext = value; }
            get { return _descriptivetext; }
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
        /// 距离单位
        /// </summary>
        public int UnitOfMeasureCode
        {
            set { _unitofmeasurecode = value; }
            get { return _unitofmeasurecode; }
        }
        /// <summary>
        /// 热点类型
        /// </summary>
        public int RefPointCategoryCode
        {
            set { _refpointcategorycode = value; }
            get { return _refpointcategorycode; }
        }
        /// <summary>
        /// 维度
        /// </summary>
        public string Latitude
        {
            set { _latitude = value; }
            get { return _latitude; }
        }
        /// <summary>
        /// 经度
        /// </summary>
        public string Longitude
        {
            set { _longitude = value; }
            get { return _longitude; }
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
        public int SyncState
        {
            set { _syncstate = value; }
            get { return _syncstate; }
        }
        #endregion Model

    }
}

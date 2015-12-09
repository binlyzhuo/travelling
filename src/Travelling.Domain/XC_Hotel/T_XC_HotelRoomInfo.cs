using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain.HotelSyncRecord
{
    /// <summary>
    /// 酒店房间信息
    /// </summary>
    [Serializable]
    public partial class T_XC_HotelRoomInfo
    {
        public T_XC_HotelRoomInfo()
        { }
        #region Model
        private int _id;
        private int _hotelid = 0;
        private string _roomtypename = "";
        private int _standardoccupancy;
        private string _size = "";
        private int _roomtypecode = 0;
        private string _floor = "";
        private string _bedtypecode = "";
        private int _quantity = 0;
        private string _descriptivetext = "";
        private int _enablebooking = 0;
        private DateTime _adddate = DateTime.Now;
        private string _facility = "";
        private int _invblockcode = 0;
        private int _roomsize = 0;
        private int _nonsmoking = 0;
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
        public int HotelId
        {
            set { _hotelid = value; }
            get { return _hotelid; }
        }
        /// <summary>
        /// 房间类型名称
        /// </summary>
        public string RoomTypeName
        {
            set { _roomtypename = value; }
            get { return _roomtypename; }
        }
        /// <summary>
        /// 标准入住人数
        /// </summary>
        public int StandardOccupancy
        {
            set { _standardoccupancy = value; }
            get { return _standardoccupancy; }
        }
        /// <summary>
        /// 床的尺寸
        /// </summary>
        public string Size
        {
            set { _size = value; }
            get { return _size; }
        }
        /// <summary>
        /// 房型代码，对应Ctrip基础房型
        /// </summary>
        public int RoomTypeCode
        {
            set { _roomtypecode = value; }
            get { return _roomtypecode; }
        }
        /// <summary>
        /// 楼层
        /// </summary>
        public string Floor
        {
            set { _floor = value; }
            get { return _floor; }
        }
        /// <summary>
        /// 床型代码，参考CodeList(BED)
        /// </summary>
        public string BedTypeCode
        {
            set { _bedtypecode = value; }
            get { return _bedtypecode; }
        }
        /// <summary>
        /// 房间数量
        /// </summary>
        public int Quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 房型描述信息
        /// </summary>
        public string DescriptiveText
        {
            set { _descriptivetext = value; }
            get { return _descriptivetext; }
        }
        /// <summary>
        /// 是否可预定
        /// </summary>
        public int EnableBooking
        {
            set { _enablebooking = value; }
            get { return _enablebooking; }
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
        /// 房间设施
        /// </summary>
        public string Facility
        {
            set { _facility = value; }
            get { return _facility; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int InvBlockCode
        {
            set { _invblockcode = value; }
            get { return _invblockcode; }
        }
        /// <summary>
        /// 房间大小
        /// </summary>
        public int RoomSize
        {
            set { _roomsize = value; }
            get { return _roomsize; }
        }
        /// <summary>
        /// 禁止吸烟
        /// </summary>
        public int NonSmoking
        {
            set { _nonsmoking = value; }
            get { return _nonsmoking; }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;

namespace Travelling.Domain.TC_Hotel
{
    /// <summary>
    /// 酒店信息列表
    /// </summary>
    [Serializable]
    [PrimaryKey("HotelID", AutoIncrement = false)]
    public partial class TC_HotelList
    {
        public TC_HotelList()
        { }
        #region Model
        private int _hotelid;
        private string _hotelname = "";
        private int _flag = 1;
        private DateTime _adddate = Convert.ToDateTime("1900-1-1");
        private DateTime _modifydate = Convert.ToDateTime("1900-1-1");

        /// <summary>
        /// 酒店ID
        /// </summary>
        public int HotelID
        {
            set { _hotelid = value; }
            get { return _hotelid; }
        }
        /// <summary>
        /// 酒店名称
        /// </summary>
        public string HotelName
        {
            set { _hotelname = value; }
            get { return _hotelname; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int Flag
        {
            set { _flag = value; }
            get { return _flag; }
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
        /// 修改时间
        /// </summary>
        public DateTime ModifyDate
        {
            set { _modifydate = value; }
            get { return _modifydate; }
        }
        #endregion Model

    }
}

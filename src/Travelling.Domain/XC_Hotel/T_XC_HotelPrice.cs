using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;

namespace Travelling.Domain.HotelSyncRecord
{
    /// <summary>
    /// 酒店最低价格信息
    /// </summary>
    [Serializable]
    [PrimaryKey("HotelID",AutoIncrement=false)]
    public partial class T_XC_HotelPrice
    {
        public T_XC_HotelPrice()
        { }
        #region Model
        private int _hotelid;
        private decimal _listamount = 0M;
        private decimal _amountbeforetax = 0M;
        private int _roomtypecode;
        private DateTime _adddate = DateTime.Now;
        /// <summary>
        /// 酒店ID
        /// </summary>
        public int HotelID
        {
            set { _hotelid = value; }
            get { return _hotelid; }
        }
        /// <summary>
        /// 门市价格
        /// </summary>
        public decimal ListAmount
        {
            set { _listamount = value; }
            get { return _listamount; }
        }
        /// <summary>
        /// 实际价格
        /// </summary>
        public decimal AmountBeforeTax
        {
            set { _amountbeforetax = value; }
            get { return _amountbeforetax; }
        }
        /// <summary>
        /// 房间编码
        /// </summary>
        public int RoomTypeCode
        {
            set { _roomtypecode = value; }
            get { return _roomtypecode; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        #endregion Model

    }
}

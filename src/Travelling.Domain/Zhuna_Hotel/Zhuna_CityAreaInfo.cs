using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;

namespace Travelling.Domain.Zhuna_Hotel
{
    /// <summary>
    /// 城市行政区域
    /// </summary>
    [Serializable]
    [PrimaryKey("id",AutoIncrement=true)]
    public partial class Zhuna_CityAreaInfo
    {
        public Zhuna_CityAreaInfo()
        { }
        #region Model
        private string _areaid;
        private string _cityid = "";
        private string _areaname = "";
        private int _hotelnum = 0;
        private int _ctripareaid = 0;
        private DateTime _adddate = DateTime.Now;
        private int _id;
        /// <summary>
        /// 
        /// </summary>
        public string areaid
        {
            set { _areaid = value; }
            get { return _areaid; }
        }
        /// <summary>
        /// 城市id
        /// </summary>
        public string cityid
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// 行政区域名称
        /// </summary>
        public string areaname
        {
            set { _areaname = value; }
            get { return _areaname; }
        }
        /// <summary>
        /// 酒店个数
        /// </summary>
        public int hotelNum
        {
            set { _hotelnum = value; }
            get { return _hotelnum; }
        }
        /// <summary>
        /// 携程对应的行政区域id
        /// </summary>
        public int ctripareaid
        {
            set { _ctripareaid = value; }
            get { return _ctripareaid; }
        }
        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime adddate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        #endregion Model

    }
}

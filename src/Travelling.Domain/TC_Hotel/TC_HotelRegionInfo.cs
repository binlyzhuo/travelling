using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;

namespace Travelling.Domain.TC_Hotel
{
    /// <summary>
    /// 行政区域信息
    /// </summary>
    [Serializable]

    public partial class TC_HotelRegionInfo
    {
        public TC_HotelRegionInfo()
        { }
        #region Model
        private int _id;
        private string _name = "";
        private string _pinyin = "";
        private int _cityid = 0;
        private int _provinceid = 0;
        private int _regionid;
        /// <summary>
        /// 行政区域id
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 拼音
        /// </summary>
        public string Pinyin
        {
            set { _pinyin = value; }
            get { return _pinyin; }
        }
        /// <summary>
        /// 城市Id
        /// </summary>
        public int CityId
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// 省份id
        /// </summary>
        public int ProvinceId
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RegionID
        {
            set { _regionid = value; }
            get { return _regionid; }
        }
        #endregion Model

    }
}

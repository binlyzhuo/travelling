using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain.Hotel
{
    /// <summary>
    /// 行政区域信息
    /// </summary>
    [Serializable]
    public partial class T_LocationInfo
    {
        public T_LocationInfo()
        { }
        #region Model
        private int _id;
        private int _locationid = 0;
        private string _locationname = "";
        private string _zhunalocationid = "";
        private string _locationename = "";
        private int _cityid = 0;
        private string _cityname = "";
        private int _hotelcount;
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 携程行政区域id
        /// </summary>
        public int LocationID
        {
            set { _locationid = value; }
            get { return _locationid; }
        }
        /// <summary>
        /// 行政区域名称
        /// </summary>
        public string LocationName
        {
            set { _locationname = value; }
            get { return _locationname; }
        }
        /// <summary>
        /// 住哪行政区域编码
        /// </summary>
        public string ZhunaLocationID
        {
            set { _zhunalocationid = value; }
            get { return _zhunalocationid; }
        }
        /// <summary>
        /// 英文名称
        /// </summary>
        public string LocationEName
        {
            set { _locationename = value; }
            get { return _locationename; }
        }
        /// <summary>
        /// 城市id
        /// </summary>
        public int CityID
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName
        {
            set { _cityname = value; }
            get { return _cityname; }
        }
        /// <summary>
        /// 酒店个数
        /// </summary>
        public int HotelCount
        {
            set { _hotelcount = value; }
            get { return _hotelcount; }
        }
        #endregion Model

    }
}

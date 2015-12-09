using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain
{
    /// <summary>
    /// 中国行政区域
    /// </summary>
    [Serializable]
    public partial class T_XC_HotelLocation
    {
        public T_XC_HotelLocation()
        { }

        private int _locationid;
        private string _locationname = "";
        private string _locationename = "";
        private int _locationcityid = 0;
        private int _state = 0;
        /// <summary>
        /// 主键
        /// </summary>
        public int LocationID
        {
            set { _locationid = value; }
            get { return _locationid; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string LocationName
        {
            set { _locationname = value; }
            get { return _locationname; }
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
        /// 城市ID
        /// </summary>
        public int LocationCityID
        {
            set { _locationcityid = value; }
            get { return _locationcityid; }
        }
        /// <summary>
        /// 是否同步过酒店的数据
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }

    }
}

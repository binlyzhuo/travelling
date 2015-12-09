using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;

namespace Travelling.Domain.TC_Hotel
{
    /// <summary>
    /// 热门区域信息
    /// </summary>
    [Serializable]
    public partial class TC_HotelSectionInfo
    {
        public TC_HotelSectionInfo()
        { }
        #region Model
        private int _id;
        private string _name = "";
        private int _cityid = 0;
        private int _provinceid = 0;
        private int _sectionid;
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 城市ID
        /// </summary>
        public int CityId
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// 省份Id
        /// </summary>
        public int ProvinceId
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SectionID
        {
            set { _sectionid = value; }
            get { return _sectionid; }
        }
        #endregion Model

    }
}

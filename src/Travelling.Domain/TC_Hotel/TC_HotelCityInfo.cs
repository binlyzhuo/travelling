using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;

namespace Travelling.Domain.TC_Hotel
{
    /// <summary>
    /// 酒店城市信息
    /// </summary>
    [Serializable]
    [PrimaryKey("ID",AutoIncrement=false)]
    public partial class TC_HotelCityInfo
    {
        public TC_HotelCityInfo()
        { }
        #region Model
        private int _id;
        private string _name = "";
        private string _pinyin = "";
        private string _index = "";
        private int _provinceid = 0;
        /// <summary>
        /// 城市ID
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
        /// 拼音
        /// </summary>
        public string Pinyin
        {
            set { _pinyin = value; }
            get { return _pinyin; }
        }
        /// <summary>
        /// 索引
        /// </summary>
        public string Index
        {
            set { _index = value; }
            get { return _index; }
        }
        /// <summary>
        /// 省份ID
        /// </summary>
        public int ProvinceId
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }
        #endregion Model

    }
}

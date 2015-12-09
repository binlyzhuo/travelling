using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain
{
    /// <summary>
    ///  国家信息
    /// </summary>
    [Serializable]
    public partial class T_XC_HotelCountry
    {
        public T_XC_HotelCountry()
        { }
        #region Model
        private int _countryid;
        private string _countryname = "";
        private string _countryename = "";
        /// <summary>
        /// 主键
        /// </summary>
        public int CountryID
        {
            set { _countryid = value; }
            get { return _countryid; }
        }
        /// <summary>
        /// 国家名称
        /// </summary>
        public string CountryName
        {
            set { _countryname = value; }
            get { return _countryname; }
        }
        /// <summary>
        /// 国家英文名称
        /// </summary>
        public string CountryEName
        {
            set { _countryename = value; }
            get { return _countryename; }
        }
        #endregion Model

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain
{
    /// <summary>
    /// 中国省市信息
    /// </summary>
    [Serializable]
    public partial class T_XC_HotelProvince
    {
        public T_XC_HotelProvince()
        { }

        private int _provinceid;
        private string _provincename = "";
        private string _provinceename = "";
        private int _countryid = 0;
        /// <summary>
        /// 主键
        /// </summary>
        public int ProvinceID
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }
        /// <summary>
        /// 省市名称
        /// </summary>
        public string ProvinceName
        {
            set { _provincename = value; }
            get { return _provincename; }
        }
        /// <summary>
        ///  省市英文名称
        /// </summary>
        public string ProvinceEName
        {
            set { _provinceename = value; }
            get { return _provinceename; }
        }
        /// <summary>
        /// 国家ID
        /// </summary>
        public int CountryID
        {
            set { _countryid = value; }
            get { return _countryid; }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain
{
    /// <summary>
    /// 酒店主题
    /// </summary>
    [Serializable]
    public partial class T_XC_HotelTheme
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public T_XC_HotelTheme()
        { }
        private int _themeid;
        private string _themename = "";
        /// <summary>
        /// 主键
        /// </summary>
        public int ThemeID
        {
            set { _themeid = value; }
            get { return _themeid; }
        }
        /// <summary>
        /// 主题名称
        /// </summary>
        public string ThemeName
        {
            set { _themename = value; }
            get { return _themename; }
        }

    }
}

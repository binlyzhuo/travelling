using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;

namespace Travelling.Domain.TC_Hotel
{
    /// <summary>
    /// 酒店品牌信息
    /// </summary>
    [Serializable]
    [PrimaryKey("ID", AutoIncrement = false)]
    public partial class TC_HotelBrand
    {
        public TC_HotelBrand()
        { }
        #region Model
        private int _id;
        private string _name = "";
        private string _sname = "";
        private string _logo = "";
        private DateTime _adddate = DateTime.Now;
        /// <summary>
        /// 品牌ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 品牌名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 品牌缩写
        /// </summary>
        public string SName
        {
            set { _sname = value; }
            get { return _sname; }
        }
        /// <summary>
        /// 酒店Logo
        /// </summary>
        public string Logo
        {
            set { _logo = value; }
            get { return _logo; }
        }
        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        #endregion Model

    }
}

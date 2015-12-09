using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain.Zhuna_Hotel
{
    /// <summary>
    /// 住哪商圈
    /// </summary>
    [Serializable]
    public partial class Zhuna_CBD
    {
        public Zhuna_CBD()
        { }
        #region Model
        private int _id;
        private string _cbdid = "";
        private string _cityid;
        private string _cbdname = "";
        private int _hotelcount = 0;
        private string _cityname = "";
        private string _hotelidstring = "";
        /// <summary>
        /// 主键
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// cbdid
        /// </summary>
        public string cbdid
        {
            set { _cbdid = value; }
            get { return _cbdid; }
        }
        /// <summary>
        /// 住哪城市id
        /// </summary>
        public string cityid
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// cbdname
        /// </summary>
        public string cbdname
        {
            set { _cbdname = value; }
            get { return _cbdname; }
        }
        /// <summary>
        /// 酒店个数
        /// </summary>
        public int hotelcount
        {
            set { _hotelcount = value; }
            get { return _hotelcount; }
        }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string cityname
        {
            set { _cityname = value; }
            get { return _cityname; }
        }
        /// <summary>
        /// 商圈周边酒店
        /// </summary>
        public string hotelidstring
        {
            set { _hotelidstring = value; }
            get { return _hotelidstring; }
        }
        #endregion Model

    }
}

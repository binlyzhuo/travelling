using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain.Zhuna_Hotel
{
    /// <summary>
    /// 酒店周边热区
    /// </summary>
    [Serializable]
    public partial class Zhuna_RefPoint
    {
        public Zhuna_RefPoint()
        { }
        #region Model
        private int _id;
        private int _hotelid = 0;
        private string _refpoint = "";
        private string _zhunacityid = "";
        private int _classid = 0;
        private string _classname = "";
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 酒店ID
        /// </summary>
        public int HotelID
        {
            set { _hotelid = value; }
            get { return _hotelid; }
        }
        /// <summary>
        /// 区域名称
        /// </summary>
        public string RefPoint
        {
            set { _refpoint = value; }
            get { return _refpoint; }
        }
        /// <summary>
        /// 住哪城市id
        /// </summary>
        public string ZhunaCityId
        {
            set { _zhunacityid = value; }
            get { return _zhunacityid; }
        }
        /// <summary>
        /// 类别id
        /// </summary>
        public int ClassID
        {
            set { _classid = value; }
            get { return _classid; }
        }
        /// <summary>
        /// 类别名称
        /// </summary>
        public string ClassName
        {
            set { _classname = value; }
            get { return _classname; }
        }
        #endregion Model

    }
}

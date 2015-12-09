using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;

namespace Travelling.Domain.Zhuna_Hotel
{
    /// <summary>
    /// 住哪城市信息
    /// </summary>
    /// <summary>
    /// 住哪城市信息
    /// </summary>
    [Serializable]
    [PrimaryKey("cid",AutoIncrement=false)]
    public partial class Zhuna_CityInfo
    {
        public Zhuna_CityInfo()
        { }
        #region Model
        private string _cid;
        private string _pid = "";
        private string _pname = "";
        private string _cname = "";
        private int _areaid = 0;
        private string _abcd = "";
        private string _suoxie = "";
        private string _pinyin = "";
        private int _hotelnum = 0;
        private string _baidu_lat = "";
        private string _baidu_lng = "";
        private int _syncstate = 0;
        private DateTime _adddate = DateTime.Now;
        private int _ctripcityid = 0;
        /// <summary>
        /// 城市Id
        /// </summary>
        public string cid
        {
            set { _cid = value; }
            get { return _cid; }
        }
        /// <summary>
        /// 省名称
        /// </summary>
        public string pid
        {
            set { _pid = value; }
            get { return _pid; }
        }
        /// <summary>
        /// 省份名称
        /// </summary>
        public string pName
        {
            set { _pname = value; }
            get { return _pname; }
        }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string cName
        {
            set { _cname = value; }
            get { return _cname; }
        }
        /// <summary>
        /// 行政区域id
        /// </summary>
        public int areaid
        {
            set { _areaid = value; }
            get { return _areaid; }
        }
        /// <summary>
        /// 首字母
        /// </summary>
        public string abcd
        {
            set { _abcd = value; }
            get { return _abcd; }
        }
        /// <summary>
        /// 缩写
        /// </summary>
        public string suoxie
        {
            set { _suoxie = value; }
            get { return _suoxie; }
        }
        /// <summary>
        /// 拼音
        /// </summary>
        public string pinyin
        {
            set { _pinyin = value; }
            get { return _pinyin; }
        }
        /// <summary>
        /// 酒店个数
        /// </summary>
        public int hotelNum
        {
            set { _hotelnum = value; }
            get { return _hotelnum; }
        }
        /// <summary>
        /// 经度
        /// </summary>
        public string baidu_lat
        {
            set { _baidu_lat = value; }
            get { return _baidu_lat; }
        }
        /// <summary>
        /// 纬度
        /// </summary>
        public string baidu_lng
        {
            set { _baidu_lng = value; }
            get { return _baidu_lng; }
        }

        /// <summary>
        /// 酒店同步状态
        /// </summary>
        public int syncstate
        {
            set { _syncstate = value; }
            get { return _syncstate; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime adddate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ctripcityid
        {
            set { _ctripcityid = value; }
            get { return _ctripcityid; }
        }
        #endregion Model

    }
}

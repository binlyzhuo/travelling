using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain.Zhuna_Hotel
{
    /// <summary>
    /// 城市地标信息
    /// </summary>
    [Serializable]
    public partial class Zhuna_CityLableInfo
    {
        public Zhuna_CityLableInfo()
        { }
        #region Model
        private int _id;
        private string _ecityid;
        private string _name = "";
        private int _classid = 0;
        private string _classname = "";
        private string _roundhotel = "";
        private string _x = "";
        private string _y;
        private string _pinyin;
        private DateTime _adddate = DateTime.Now;
        private string _cityname = "";
        private int _indexstate = 0;
        private int _labelid = 0;
        /// <summary>
        /// 主键
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 城市ID
        /// </summary>
        public string ecityid
        {
            set { _ecityid = value; }
            get { return _ecityid; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 地标分类id
        /// </summary>
        public int classid
        {
            set { _classid = value; }
            get { return _classid; }
        }
        /// <summary>
        /// 地标分类名称 
        /// </summary>
        public string classname
        {
            set { _classname = value; }
            get { return _classname; }
        }
        /// <summary>
        /// string 附近酒店id
        /// </summary>
        public string roundhotel
        {
            set { _roundhotel = value; }
            get { return _roundhotel; }
        }
        /// <summary>
        /// 经度
        /// </summary>
        public string x
        {
            set { _x = value; }
            get { return _x; }
        }
        /// <summary>
        /// 纬度
        /// </summary>
        public string y
        {
            set { _y = value; }
            get { return _y; }
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
        /// 添加时间
        /// </summary>
        public DateTime adddate
        {
            set { _adddate = value; }
            get { return _adddate; }
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
        /// 索引状态
        /// </summary>
        public int indexstate
        {
            set { _indexstate = value; }
            get { return _indexstate; }
        }
        /// <summary>
        /// labelid
        /// </summary>
        public int labelid
        {
            set { _labelid = value; }
            get { return _labelid; }
        }
        #endregion Model

    }
}

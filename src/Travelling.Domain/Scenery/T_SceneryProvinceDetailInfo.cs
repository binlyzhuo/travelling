using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;


namespace Travelling.Domain.Scenery
{
    /// <summary>
    /// 景区相关省份
    /// </summary>
    [Serializable]
    [PrimaryKey("ID",AutoIncrement=false)]
    public partial class T_SceneryProvinceDetailInfo
    {
        public T_SceneryProvinceDetailInfo()
        { }
        #region Model
        private int _id;
        private string _name = "";
        private string _pinyin = "";
        private string _pinyinindex = "";
        private int _parentid = 0;
        private int _ordernum = 0;
        private int _isrecommend = 0;
        private int _scenerycount = 0;
        private int _syncstate = 0;
        private DateTime _lastsyncdate = Convert.ToDateTime("1900-1-1");
        /// <summary>
        /// 省份ID或者城市ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 省份城市名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 省份城市拼音
        /// </summary>
        public string PinYin
        {
            set { _pinyin = value; }
            get { return _pinyin; }
        }
        /// <summary>
        /// 省份城市索引
        /// </summary>
        public string PinYinIndex
        {
            set { _pinyinindex = value; }
            get { return _pinyinindex; }
        }
        /// <summary>
        /// 省份ID
        /// </summary>
        public int ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 暂时顺序
        /// </summary>
        public int OrderNum
        {
            set { _ordernum = value; }
            get { return _ordernum; }
        }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public int IsRecommend
        {
            set { _isrecommend = value; }
            get { return _isrecommend; }
        }
        /// <summary>
        /// 景区个数
        /// </summary>
        public int SceneryCount
        {
            set { _scenerycount = value; }
            get { return _scenerycount; }
        }

        /// <summary>
        /// 景区查询状态
        /// </summary>
        public int SyncState
        {
            set { _syncstate = value; }
            get { return _syncstate; }
        }
        /// <summary>
        /// 上次同步时间
        /// </summary>
        public DateTime LastSyncDate
        {
            set { _lastsyncdate = value; }
            get { return _lastsyncdate; }
        }
        #endregion Model

    }
}

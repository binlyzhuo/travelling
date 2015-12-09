using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;

namespace Travelling.Domain
{
    /// <summary>
    /// 景区信息
    /// </summary>
    [Serializable]
    [PrimaryKey("SceneryId",AutoIncrement=false)]
    public partial class T_SceneryInfoSyncRecord
    {
        public T_SceneryInfoSyncRecord()
        { }
        #region Model
        private int _sceneryid;
        private string _imgs = "";
        private string _sceneryname = "";
        private string _sceneryaddress;
        private string _scenerysummary = "";
        private int _provinceid = 0;
        private string _provincename = "";
        private int _cityid = 0;
        private string _cityname;
        private int _bookflag;
        private string _gradeid = "‘’";
        private string _lon;
        private string _lat = "0";
        private decimal _distance;
        private string _themes = "";
        private string _suitherds = "";
        private string _impressions = "";
        private DateTime _addtime = DateTime.Now;
        private DateTime _updatetime = Convert.ToDateTime("1900-1-1");
        private string _imgbaseurl;
        private int _pricesyncstate;
        private int _countyid = 0;
        private string _countyname = "";
        private int _commentcount = 0;
        private int _questioncount = 0;
        private int _blogcount = 0;
        private int _viewcount = 0;
        private int _sceneryamount = 0;
        private int _adviceamount = 0;
        private int _detailsyncstate = 0;
        private int _imgsyncstate = 0;
        /// <summary>
        /// 景区ID,主键
        /// </summary>
        public int SceneryId
        {
            set { _sceneryid = value; }
            get { return _sceneryid; }
        }
        /// <summary>
        /// 景区图片
        /// </summary>
        public string Imgs
        {
            set { _imgs = value; }
            get { return _imgs; }
        }
        /// <summary>
        /// 景区名称
        /// </summary>
        public string SceneryName
        {
            set { _sceneryname = value; }
            get { return _sceneryname; }
        }
        /// <summary>
        /// 景区地址
        /// </summary>
        public string SceneryAddress
        {
            set { _sceneryaddress = value; }
            get { return _sceneryaddress; }
        }
        /// <summary>
        /// 景点简介
        /// </summary>
        public string ScenerySummary
        {
            set { _scenerysummary = value; }
            get { return _scenerysummary; }
        }
        /// <summary>
        /// 景区省份ID
        /// </summary>
        public int ProvinceId
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }
        /// <summary>
        /// 省份名称
        /// </summary>
        public string ProvinceName
        {
            set { _provincename = value; }
            get { return _provincename; }
        }
        /// <summary>
        /// 城市ID
        /// </summary>
        public int CityId
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName
        {
            set { _cityname = value; }
            get { return _cityname; }
        }
        /// <summary>
        /// 可预订情况
        /// </summary>
        public int BookFlag
        {
            set { _bookflag = value; }
            get { return _bookflag; }
        }
        /// <summary>
        /// 星级
        /// </summary>
        public string GradeId
        {
            set { _gradeid = value; }
            get { return _gradeid; }
        }
        /// <summary>
        /// 纬度
        /// </summary>
        public string Lon
        {
            set { _lon = value; }
            get { return _lon; }
        }
        /// <summary>
        /// 经度
        /// </summary>
        public string Lat
        {
            set { _lat = value; }
            get { return _lat; }
        }
        /// <summary>
        /// 距离
        /// </summary>
        public decimal Distance
        {
            set { _distance = value; }
            get { return _distance; }
        }
        /// <summary>
        /// 景区主题,分开
        /// </summary>
        public string Themes
        {
            set { _themes = value; }
            get { return _themes; }
        }
        /// <summary>
        /// 适合人群,分开
        /// </summary>
        public string Suitherds
        {
            set { _suitherds = value; }
            get { return _suitherds; }
        }
        /// <summary>
        /// 游客印象,分开
        /// </summary>
        public string Impressions
        {
            set { _impressions = value; }
            get { return _impressions; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ImgBaseUrl
        {
            set { _imgbaseurl = value; }
            get { return _imgbaseurl; }
        }
        /// <summary>
        /// 价格计划是否同步
        /// </summary>
        public int PriceSyncState
        {
            set { _pricesyncstate = value; }
            get { return _pricesyncstate; }
        }
        /// <summary>
        /// 县市ID
        /// </summary>
        public int CountyId
        {
            set { _countyid = value; }
            get { return _countyid; }
        }
        /// <summary>
        /// 县市名称
        /// </summary>
        public string CountyName
        {
            set { _countyname = value; }
            get { return _countyname; }
        }
        /// <summary>
        /// 用户点评个数
        /// </summary>
        public int CommentCount
        {
            set { _commentcount = value; }
            get { return _commentcount; }
        }
        /// <summary>
        /// 问题个数
        /// </summary>
        public int QuestionCount
        {
            set { _questioncount = value; }
            get { return _questioncount; }
        }
        /// <summary>
        /// 博客个数
        /// </summary>
        public int BlogCount
        {
            set { _blogcount = value; }
            get { return _blogcount; }
        }
        /// <summary>
        /// 浏览次数
        /// </summary>
        public int ViewCount
        {
            set { _viewcount = value; }
            get { return _viewcount; }
        }
        /// <summary>
        /// 景区门票价格
        /// </summary>
        public int SceneryAmount
        {
            set { _sceneryamount = value; }
            get { return _sceneryamount; }
        }
        /// <summary>
        /// 同程优惠价格
        /// </summary>
        public int AdviceAmount
        {
            set { _adviceamount = value; }
            get { return _adviceamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DetailSyncState
        {
            set { _detailsyncstate = value; }
            get { return _detailsyncstate; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ImgSyncState
        {
            set { _imgsyncstate = value; }
            get { return _imgsyncstate; }
        }
        #endregion Model

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;


namespace Travelling.Domain
{
    /// <summary>
    /// t_sceneryinfodetail:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    [PrimaryKey("SceneryID",AutoIncrement=false)]
    public partial class T_SceneryInfoDetail
    {
        public T_SceneryInfoDetail()
        { }
        #region Model
        private int _sceneryid;
        private string _sceneryname = "";
        private string _gradeid;
        private int _gradeint = 0;
        private string _address = "";
        private int _cityid = 0;
        private int _provinceid = 0;
        private string _intro;
        private string _buynotice = "";
        private string _paymode;
        private string _lon = "";
        private string _lat = "";
        private string _sceneryalias = "";
        private int _amountadvice = 0;
        private int _ifusecard = 0;
        private string _cityname = "";
        private string _provincename = "";
        private string _scenerysummary = "";
        private int _bookflag;
        private decimal _distance;
        private string _themes;
        private string _suitherds;
        private string _impressions;
        private string _imgs;
        private string _imgbaseurl;
        private DateTime _updatetime = Convert.ToDateTime("1900-1-1");
        private int _haspricepolicy = 0;
        private int _countryid = 0;
        private string _countryname = "";
        private int _isindex = 0;

        /// <summary>
        /// 景区ID
        /// </summary>
        public int SceneryID
        {
            set { _sceneryid = value; }
            get { return _sceneryid; }
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
        /// 景点级别
        /// </summary>
        public string GradeId
        {
            set { _gradeid = value; }
            get { return _gradeid; }
        }
        /// <summary>
        /// 景点级别
        /// </summary>
        public int GradeInt
        {
            set { _gradeint = value; }
            get { return _gradeint; }
        }
        /// <summary>
        /// 景点地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 城市ID
        /// </summary>
        public int CityID
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// 省份ID
        /// </summary>
        public int ProvinceID
        {
            set { _provinceid = value; }
            get { return _provinceid; }
        }
        /// <summary>
        /// 景点简介
        /// </summary>
        public string Intro
        {
            set { _intro = value; }
            get { return _intro; }
        }
        /// <summary>
        /// 购票需知
        /// </summary>
        public string BuyNotice
        {
            set { _buynotice = value; }
            get { return _buynotice; }
        }
        /// <summary>
        /// 支付类型-例如:景区现付
        /// </summary>
        public string PayMode
        {
            set { _paymode = value; }
            get { return _paymode; }
        }
        /// <summary>
        /// Mapbar经度/百度经度-Cs为1时为Mapbar;cs为2时为百度
        /// </summary>
        public string Lon
        {
            set { _lon = value; }
            get { return _lon; }
        }
        /// <summary>
        /// Mapbar纬度/百度纬度,Cs为1时为Mapbar;cs为2时为百度
        /// </summary>
        public string Lat
        {
            set { _lat = value; }
            get { return _lat; }
        }
        /// <summary>
        /// 景点别名,多个已“|”隔开
        /// </summary>
        public string SceneryAlias
        {
            set { _sceneryalias = value; }
            get { return _sceneryalias; }
        }
        /// <summary>
        /// 同程价-该景点的最低价格，可能是儿童价
        /// </summary>
        public int AmountAdvice
        {
            set { _amountadvice = value; }
            get { return _amountadvice; }
        }
        /// <summary>
        /// 是否使用身份证
        /// </summary>
        public int IfUseCard
        {
            set { _ifusecard = value; }
            get { return _ifusecard; }
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
        /// 省份名称
        /// </summary>
        public string ProvinceName
        {
            set { _provincename = value; }
            get { return _provincename; }
        }
        /// <summary>
        /// 景区简介
        /// </summary>
        public string ScenerySummary
        {
            set { _scenerysummary = value; }
            get { return _scenerysummary; }
        }
        /// <summary>
        /// 可预订状态
        /// </summary>
        public int BookFlag
        {
            set { _bookflag = value; }
            get { return _bookflag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Distance
        {
            set { _distance = value; }
            get { return _distance; }
        }
        /// <summary>
        /// 景区主题
        /// </summary>
        public string Themes
        {
            set { _themes = value; }
            get { return _themes; }
        }
        /// <summary>
        /// 适合人群
        /// </summary>
        public string Suitherds
        {
            set { _suitherds = value; }
            get { return _suitherds; }
        }
        /// <summary>
        /// 游客印象
        /// </summary>
        public string Impressions
        {
            set { _impressions = value; }
            get { return _impressions; }
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
        /// 图片路径
        /// </summary>
        public string ImgBaseUrl
        {
            set { _imgbaseurl = value; }
            get { return _imgbaseurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 是否含有价格策络
        /// </summary>
        public int HasPricePolicy
        {
            set { _haspricepolicy = value; }
            get { return _haspricepolicy; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CountryID
        {
            set { _countryid = value; }
            get { return _countryid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CountryName
        {
            set { _countryname = value; }
            get { return _countryname; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int IsIndex
        {
            set { _isindex = value; }
            get { return _isindex; }
        }
		#endregion Model

    }
}

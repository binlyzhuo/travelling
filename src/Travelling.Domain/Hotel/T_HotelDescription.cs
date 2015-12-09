using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;

namespace Travelling.Domain.Hotel
{
    /// <summary>
    /// 携程酒店静态信息
    /// </summary>
    [Serializable]
    [PrimaryKey("HotelID", AutoIncrement = false)]
    public partial class T_HotelDescription2
    {

        public T_HotelDescription2()
        { }

        #region Model
        private int _hotelid;
        private int _areaid = 0;
        private int _brandcode = 0;
        private int _hotelcode = 0;
        private int _hotelcitycode = 0;
        private string _hotelname = "";
        private DateTime _whenbuild = Convert.ToDateTime("1900-1-1");
        private DateTime _lastupdated = Convert.ToDateTime("1900-1-1");
        private string _latitude = "";
        private string _longitude = "";
        private int _positiontypecode = 0;
        private decimal _hotelstarrate = 0M;
        private decimal _ctripstarrate = 0M;
        private decimal _ctripuserrate = 0M;
        private decimal _ctripcommrate = 0M;
        private decimal _commsurroundingrate = 0M;
        private decimal _commfacilityrate;
        private decimal _commcleanrate = 0M;
        private decimal _commservicerate = 0M;
        private string _segmentcategory = "";
        private string _addressline = "";
        private string _postcode = "";
        private string _cityname = "";
        private DateTime _adddate = DateTime.Now;
        private string _description;
        private string _policyinfo = "";
        private string _services = "";
        private string _textitems = "";
        private string _mediaitems = "";
        private string _areaname = "";
        private string _brandname = "";
        private int _zoneid = 0;
        private string _zonename = "";
        private string _shortdescription = "";
        private string _summary = "";
        private string _pageonoffice = "";
        private int _syncstate = 0;
        private string _hotelimg = "";
        private int _listamount = 0;
        private int _trueamount = 0;
        private int _isindex = 0;
        /// <summary>
        /// 酒店ID
        /// </summary>
        public int HotelID
        {
            set { _hotelid = value; }
            get { return _hotelid; }
        }
        /// <summary>
        /// 酒店行政区域ID
        /// </summary>
        public int AreaID
        {
            set { _areaid = value; }
            get { return _areaid; }
        }
        /// <summary>
        /// 酒店品牌
        /// </summary>
        public int BrandCode
        {
            set { _brandcode = value; }
            get { return _brandcode; }
        }
        /// <summary>
        /// 酒店编码
        /// </summary>
        public int HotelCode
        {
            set { _hotelcode = value; }
            get { return _hotelcode; }
        }
        /// <summary>
        /// 酒店所在城市ID
        /// </summary>
        public int HotelCityCode
        {
            set { _hotelcitycode = value; }
            get { return _hotelcitycode; }
        }
        /// <summary>
        /// 酒店名称
        /// </summary>
        public string HotelName
        {
            set { _hotelname = value; }
            get { return _hotelname; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime WhenBuild
        {
            set { _whenbuild = value; }
            get { return _whenbuild; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime LastUpdated
        {
            set { _lastupdated = value; }
            get { return _lastupdated; }
        }
        /// <summary>
        /// 纬度
        /// </summary>
        public string Latitude
        {
            set { _latitude = value; }
            get { return _latitude; }
        }
        /// <summary>
        /// 经度
        /// </summary>
        public string Longitude
        {
            set { _longitude = value; }
            get { return _longitude; }
        }
        /// <summary>
        /// 地图类型
        /// </summary>
        public int PositionTypeCode
        {
            set { _positiontypecode = value; }
            get { return _positiontypecode; }
        }
        /// <summary>
        /// 酒店星级
        /// </summary>
        public decimal HotelStarRate
        {
            set { _hotelstarrate = value; }
            get { return _hotelstarrate; }
        }
        /// <summary>
        /// 携程星级
        /// </summary>
        public decimal CtripStarRate
        {
            set { _ctripstarrate = value; }
            get { return _ctripstarrate; }
        }
        /// <summary>
        /// 用户推荐级别
        /// </summary>
        public decimal CtripUserRate
        {
            set { _ctripuserrate = value; }
            get { return _ctripuserrate; }
        }
        /// <summary>
        /// 酒店点评－综合评分
        /// </summary>
        public decimal CtripCommRate
        {
            set { _ctripcommrate = value; }
            get { return _ctripcommrate; }
        }
        /// <summary>
        /// 酒店点评－周边环境分类评分
        /// </summary>
        public decimal CommSurroundingRate
        {
            set { _commsurroundingrate = value; }
            get { return _commsurroundingrate; }
        }
        /// <summary>
        /// 酒店设施评分
        /// </summary>
        public decimal CommFacilityRate
        {
            set { _commfacilityrate = value; }
            get { return _commfacilityrate; }
        }
        /// <summary>
        /// 酒店点评－房间卫生分类评分
        /// </summary>
        public decimal CommCleanRate
        {
            set { _commcleanrate = value; }
            get { return _commcleanrate; }
        }
        /// <summary>
        /// 酒店点评－酒店服务分类评分
        /// </summary>
        public decimal CommServiceRate
        {
            set { _commservicerate = value; }
            get { return _commservicerate; }
        }
        /// <summary>
        /// 酒店常用的酒店标签和分类
        /// </summary>
        public string SegmentCategory
        {
            set { _segmentcategory = value; }
            get { return _segmentcategory; }
        }
        /// <summary>
        /// 酒店地址
        /// </summary>
        public string AddressLine
        {
            set { _addressline = value; }
            get { return _addressline; }
        }
        /// <summary>
        /// 邮编
        /// </summary>
        public string PostCode
        {
            set { _postcode = value; }
            get { return _postcode; }
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
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 酒店描述信息
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 预定规则
        /// </summary>
        public string PolicyInfo
        {
            set { _policyinfo = value; }
            get { return _policyinfo; }
        }
        /// <summary>
        /// 酒店服务信息
        /// </summary>
        public string Services
        {
            set { _services = value; }
            get { return _services; }
        }
        /// <summary>
        ///   酒店简介和预定地址
        /// </summary>
        public string TextItems
        {
            set { _textitems = value; }
            get { return _textitems; }
        }
        /// <summary>
        /// 酒店媒体信息
        /// </summary>
        public string MediaItems
        {
            set { _mediaitems = value; }
            get { return _mediaitems; }
        }
        /// <summary>
        /// 行政区域名称
        /// </summary>
        public string AreaName
        {
            set { _areaname = value; }
            get { return _areaname; }
        }
        /// <summary>
        /// 酒店品牌名称
        /// </summary>
        public string BrandName
        {
            set { _brandname = value; }
            get { return _brandname; }
        }
        /// <summary>
        /// 行政区域ID
        /// </summary>
        public int ZoneId
        {
            set { _zoneid = value; }
            get { return _zoneid; }
        }
        /// <summary>
        /// 行政区域名称
        /// </summary>
        public string ZoneName
        {
            set { _zonename = value; }
            get { return _zonename; }
        }
        /// <summary>
        /// 一句话介绍
        /// </summary>
        public string ShortDescription
        {
            set { _shortdescription = value; }
            get { return _shortdescription; }
        }
        /// <summary>
        /// 简介
        /// </summary>
        public string Summary
        {
            set { _summary = value; }
            get { return _summary; }
        }
        /// <summary>
        /// 官网页面
        /// </summary>
        public string PageOnOffice
        {
            set { _pageonoffice = value; }
            get { return _pageonoffice; }
        }
        /// <summary>
        /// 同步状态
        /// </summary>
        public int SyncState
        {
            set { _syncstate = value; }
            get { return _syncstate; }
        }
        /// <summary>
        /// 酒店图片
        /// </summary>
        public string HotelImg
        {
            set { _hotelimg = value; }
            get { return _hotelimg; }
        }
        /// <summary>
        /// 门市价格
        /// </summary>
        public int ListAmount
        {
            set { _listamount = value; }
            get { return _listamount; }
        }
        /// <summary>
        /// 实际最低
        /// </summary>
        public int TrueAmount
        {
            set { _trueamount = value; }
            get { return _trueamount; }
        }
        /// <summary>
        /// 是否添加索引
        /// </summary>
        public int IsIndex
        {
            set { _isindex = value; }
            get { return _isindex; }
        }
        #endregion Model

    }
}

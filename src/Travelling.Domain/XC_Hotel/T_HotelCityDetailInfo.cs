using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;

namespace Travelling.Domain.Hotel
{
    /// <summary>
    /// 酒店城市详细信息
    /// </summary>
    [Serializable]
    [PrimaryKey("CityID",AutoIncrement=false)]
    public partial class T_XC_HotelCityDetailInfo
    {
        public T_XC_HotelCityDetailInfo()
        { }
        #region Model
        private int _cityid;
        private string _cityname = "";
        private string _cityename = "";
        private int _provinceid;
        private string _provincename = "";
        private int _isrecommendcity = 0;
        private int _recommentindex = 0;
        private int _ishotcity = 0;
        private int _hotcityindex = 0;
        private int _hotelcount = 0;
        private DateTime _lastsynchotelinfodate = Convert.ToDateTime("1900-1-1");
        private int _ischoicecity = 0;
        private int _choicecityindex = 0;
        private int _issearch;
        private string _citycode = "";
        private int _syncstate = 0;
        /// <summary>
        /// 城市id
        /// </summary>
        public int CityID
        {
            set { _cityid = value; }
            get { return _cityid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CityName
        {
            set { _cityname = value; }
            get { return _cityname; }
        }
        /// <summary>
        /// 城市英文名称
        /// </summary>
        public string CityEName
        {
            set { _cityename = value; }
            get { return _cityename; }
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
        /// 省份名称
        /// </summary>
        public string ProvinceName
        {
            set { _provincename = value; }
            get { return _provincename; }
        }
        /// <summary>
        /// 是否是推荐城市
        ///   首页推荐
        /// </summary>
        public int IsRecommendCity
        {
            set { _isrecommendcity = value; }
            get { return _isrecommendcity; }
        }
        /// <summary>
        /// 推荐排序,从低到高
        /// </summary>
        public int RecommentIndex
        {
            set { _recommentindex = value; }
            get { return _recommentindex; }
        }
        /// <summary>
        /// 是否是热门城市，网页底部显示
        /// </summary>
        public int IsHotCity
        {
            set { _ishotcity = value; }
            get { return _ishotcity; }
        }
        /// <summary>
        /// 热门城市推荐索引，从低到高
        /// </summary>
        public int HotCityIndex
        {
            set { _hotcityindex = value; }
            get { return _hotcityindex; }
        }
        /// <summary>
        /// 城市包含城市个数
        /// </summary>
        public int HotelCount
        {
            set { _hotelcount = value; }
            get { return _hotelcount; }
        }
        /// <summary>
        /// 上次同步时间
        /// </summary>
        public DateTime LastSyncHotelInfoDate
        {
            set { _lastsynchotelinfodate = value; }
            get { return _lastsynchotelinfodate; }
        }
        /// <summary>
        /// 精选酒店城市
        /// </summary>
        public int IsChoiceCity
        {
            set { _ischoicecity = value; }
            get { return _ischoicecity; }
        }
        /// <summary>
        /// 精选酒店城市排名
        /// </summary>
        public int ChoiceCityIndex
        {
            set { _choicecityindex = value; }
            get { return _choicecityindex; }
        }
        /// <summary>
        /// 是否查询推荐,hotelcount>0
        /// </summary>
        public int IsSearch
        {
            set { _issearch = value; }
            get { return _issearch; }
        }

        /// <summary>
        /// 城市编码
        /// </summary>
        public string CityCode
        {
            set { _citycode = value; }
            get { return _citycode; }
        }

        /// <summary>
        /// 酒店同步状态
        /// </summary>
        public int SyncState
        {
            set { _syncstate = value; }
            get { return _syncstate; }
        }
        #endregion Model


    }
}

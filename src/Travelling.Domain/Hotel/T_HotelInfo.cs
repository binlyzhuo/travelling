using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain.Hotel
{
    /// <summary>
    /// 酒店信息
    /// </summary>
    [Serializable]
    public partial class T_HotelInfo
    {
        public T_HotelInfo()
        { }
        #region Model
        private int _id;
        private int _hotelid = 0;
        private string _hotelname = "";
        private int _unionid = 0;
        private string _address = "";
        private int _cityid = 0;
        private string _cityname = "";
        private string _refpoint = "";
        private int _locationid = 0;
        private string _locationname = "";
        private int _brandid = 0;
        private string _brandname;
        private int _amount = 0;
        private string _hotelimg = "";
        private string _lat = "";
        private string _lng = "";
        private int _state = 1;
        private string _description = "";
        private int _hotelstar = 0;
        private int _zhunahotelid = 0;
        private int _indexstate = 0;
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 携程酒店ID
        /// </summary>
        public int HotelID
        {
            set { _hotelid = value; }
            get { return _hotelid; }
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
        /// 联盟ID
        /// </summary>
        public int UnionId
        {
            set { _unionid = value; }
            get { return _unionid; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
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
        /// 周边
        /// </summary>
        public string RefPoint
        {
            set { _refpoint = value; }
            get { return _refpoint; }
        }
        /// <summary>
        /// 行政区ID
        /// </summary>
        public int LocationId
        {
            set { _locationid = value; }
            get { return _locationid; }
        }
        /// <summary>
        /// 行政区名称
        /// </summary>
        public string LocationName
        {
            set { _locationname = value; }
            get { return _locationname; }
        }
        /// <summary>
        /// 酒店品牌ID
        /// </summary>
        public int BrandId
        {
            set { _brandid = value; }
            get { return _brandid; }
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
        /// 最低价格
        /// </summary>
        public int Amount
        {
            set { _amount = value; }
            get { return _amount; }
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
        /// 纬度
        /// </summary>
        public string Lat
        {
            set { _lat = value; }
            get { return _lat; }
        }
        /// <summary>
        /// 经度
        /// </summary>
        public string Lng
        {
            set { _lng = value; }
            get { return _lng; }
        }
        /// <summary>
        /// 有效状态
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
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
        /// 酒店星级
        /// </summary>
        public int HotelStar
        {
            set { _hotelstar = value; }
            get { return _hotelstar; }
        }
        /// <summary>
        /// 住哪酒店ID
        /// </summary>
        public int ZhunaHotelID
        {
            set { _zhunahotelid = value; }
            get { return _zhunahotelid; }
        }
        /// <summary>
        /// 索引状态
        /// </summary>
        public int IndexState
        {
            set { _indexstate = value; }
            get { return _indexstate; }
        }
        #endregion Model

    }
}

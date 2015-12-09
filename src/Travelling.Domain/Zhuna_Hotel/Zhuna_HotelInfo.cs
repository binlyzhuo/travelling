using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;

namespace Travelling.Domain.Zhuna_Hotel
{
    /// <summary>
    /// 酒店信息
    /// </summary>
    [Serializable]
    [PrimaryKey("id",AutoIncrement=false)]
    public partial class Zhuna_HotelInfo
    {
        public Zhuna_HotelInfo()
        { }
        #region Model
        private int _id;
        private string _hotelname = "";
        private string _address = "";
        private string _picture = "";
        private string _x = "";
        private string _y = "";
        private int _min_jiage = 0;
        private string _max_jiangjin = "0";
        private string _liansuo = "";
        private int _xingji = 0;
        private string _fuwu = "";
        private string _kaiye = "";
        private string _zhuangxiu = "";
        private string _zaocanprice = "";
        private string _traffic = "";
        private string _service = "";
        private string _canyin = "";
        private string _card = "";
        private string _ecityid = "";
        private string _cityname = "";
        private string _df_scores = "";
        private string _df_haoping = "";
        private string _content = "";
        private string _lng = "";
        private string _lat = "";
        private string _baidu_lng = "";
        private string _baidu_lat = "";
        private string _tags = "";
        private string _esdid = "";
        private int _liansuoid = 0;
        private string _eareaid = "0";
        private string _esdname = "";
        private int _juli = 0;
        private string _yulejianshen = "";
        private string _traffic_zhinan = "";
        private string _jianshu = "";
        private string _teshe = "";
        private int _is_kezhan = 0;
        private DateTime _adddate = DateTime.Now;
        private int _ctriphotelid = 0;
        private int _unionid = 1;
        private int _isindex = 0;

        /// <summary>
        /// 酒店id 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 酒店名称 
        /// </summary>
        public string hotelname
        {
            set { _hotelname = value; }
            get { return _hotelname; }
        }
        /// <summary>
        /// 酒店地址 
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 酒店代表图 
        /// </summary>
        public string picture
        {
            set { _picture = value; }
            get { return _picture; }
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
        /// 最低价格 
        /// </summary>
        public int min_jiage
        {
            set { _min_jiage = value; }
            get { return _min_jiage; }
        }
        /// <summary>
        ///  最大价格 
        /// </summary>
        public string max_jiangjin
        {
            set { _max_jiangjin = value; }
            get { return _max_jiangjin; }
        }
        /// <summary>
        /// 连锁酒店名称 
        /// </summary>
        public string liansuo
        {
            set { _liansuo = value; }
            get { return _liansuo; }
        }
        /// <summary>
        /// 酒店星级 
        /// </summary>
        public int xingji
        {
            set { _xingji = value; }
            get { return _xingji; }
        }
        /// <summary>
        /// 酒店服务(以|分隔，如：adsl|card，推荐使用service字段) 
        /// </summary>
        public string fuwu
        {
            set { _fuwu = value; }
            get { return _fuwu; }
        }
        /// <summary>
        ///  开业时间 
        /// </summary>
        public string kaiye
        {
            set { _kaiye = value; }
            get { return _kaiye; }
        }
        /// <summary>
        /// 装修时间 
        /// </summary>
        public string zhuangxiu
        {
            set { _zhuangxiu = value; }
            get { return _zhuangxiu; }
        }
        /// <summary>
        /// 早餐价格 
        /// </summary>
        public string zaocanPrice
        {
            set { _zaocanprice = value; }
            get { return _zaocanprice; }
        }
        /// <summary>
        /// 交通位置 
        /// </summary>
        public string traffic
        {
            set { _traffic = value; }
            get { return _traffic; }
        }
        /// <summary>
        /// 服务 
        /// </summary>
        public string service
        {
            set { _service = value; }
            get { return _service; }
        }
        /// <summary>
        /// 餐饮信息 
        /// </summary>
        public string canyin
        {
            set { _canyin = value; }
            get { return _canyin; }
        }
        /// <summary>
        /// 所支持的银行卡((以|分隔，如：牡丹卡,金穗卡,长城卡,龙卡,太平洋卡,东方卡) 
        /// </summary>
        public string card
        {
            set { _card = value; }
            get { return _card; }
        }
        /// <summary>
        ///  城市id 
        /// </summary>
        public string ecityid
        {
            set { _ecityid = value; }
            get { return _ecityid; }
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
        /// 评分（好评+中评-差评=总分） 
        /// </summary>
        public string df_scores
        {
            set { _df_scores = value; }
            get { return _df_scores; }
        }
        /// <summary>
        /// 评价（以$分隔，如：37$13$2，代表好评$中评$差评） 
        /// </summary>
        public string df_haoping
        {
            set { _df_haoping = value; }
            get { return _df_haoping; }
        }
        /// <summary>
        ///  酒店简介 
        /// </summary>
        public string content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 经度 
        /// </summary>
        public string lng
        {
            set { _lng = value; }
            get { return _lng; }
        }
        /// <summary>
        /// 纬度 
        /// </summary>
        public string lat
        {
            set { _lat = value; }
            get { return _lat; }
        }
        /// <summary>
        /// 百度地图经度 
        /// </summary>
        public string baidu_lng
        {
            set { _baidu_lng = value; }
            get { return _baidu_lng; }
        }
        /// <summary>
        /// 百度地图纬度 
        /// </summary>
        public string baidu_lat
        {
            set { _baidu_lat = value; }
            get { return _baidu_lat; }
        }
        /// <summary>
        /// 酒店tags（以，分隔，如：安静,经济,出行方便,繁华地区,优质服务） 
        /// </summary>
        public string tags
        {
            set { _tags = value; }
            get { return _tags; }
        }
        /// <summary>
        /// 商业区id 
        /// </summary>
        public string esdid
        {
            set { _esdid = value; }
            get { return _esdid; }
        }
        /// <summary>
        /// 连锁酒店id 
        /// </summary>
        public int liansuoid
        {
            set { _liansuoid = value; }
            get { return _liansuoid; }
        }
        /// <summary>
        /// 行政区域id 
        /// </summary>
        public string eareaid
        {
            set { _eareaid = value; }
            get { return _eareaid; }
        }
        /// <summary>
        /// 商业区名称 
        /// </summary>
        public string esdname
        {
            set { _esdname = value; }
            get { return _esdname; }
        }
        /// <summary>
        /// 距离（单位米，如果经纬度不为空，则显示此字段） 
        /// </summary>
        public int juli
        {
            set { _juli = value; }
            get { return _juli; }
        }
        /// <summary>
        /// 娱乐信息 
        /// </summary>
        public string yulejianshen
        {
            set { _yulejianshen = value; }
            get { return _yulejianshen; }
        }
        /// <summary>
        /// 交通指南 
        /// </summary>
        public string traffic_zhinan
        {
            set { _traffic_zhinan = value; }
            get { return _traffic_zhinan; }
        }
        /// <summary>
        /// 酒店简述 
        /// </summary>
        public string jianshu
        {
            set { _jianshu = value; }
            get { return _jianshu; }
        }
        /// <summary>
        /// 酒店荣誉（特色） 
        /// </summary>
        public string teshe
        {
            set { _teshe = value; }
            get { return _teshe; }
        }
        /// <summary>
        /// 1为客栈 0为酒店
        /// </summary>
        public int is_kezhan
        {
            set { _is_kezhan = value; }
            get { return _is_kezhan; }
        }

        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime adddate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }
        /// <summary>
        /// 携程酒店id
        /// </summary>
        public int ctriphotelid
        {
            set { _ctriphotelid = value; }
            get { return _ctriphotelid; }
        }
        /// <summary>
        /// 联盟id
        /// </summary>
        public int unionid
        {
            set { _unionid = value; }
            get { return _unionid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int isindex
        {
            set { _isindex = value; }
            get { return _isindex; }
        }
        #endregion Model

    }
}

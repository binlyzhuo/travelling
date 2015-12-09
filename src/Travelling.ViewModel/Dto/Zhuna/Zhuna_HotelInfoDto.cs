using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.Zhuna
{
    public class Zhuna_HotelInfoDto
    {
        /// <summary>
        /// 酒店id 
        /// </summary>
        public int id
        {
            get;
            set;
        }
        /// <summary>
        /// 酒店名称 
        /// </summary>
        public string hotelname
        {
            get;
            set;
        }
        /// <summary>
        /// 酒店地址 
        /// </summary>
        public string address
        {
            get;
            set;
        }
        /// <summary>
        /// 酒店代表图 
        /// </summary>
        public string picture
        {
            get;
            set;
        }
        /// <summary>
        /// 经度 
        /// </summary>
        public string x
        {
            get;
            set;
        }
        /// <summary>
        /// 纬度 
        /// </summary>
        public string y
        {
            get;
            set;
        }
        /// <summary>
        /// 最低价格 
        /// </summary>
        public int min_jiage
        {
            get;
            set;
        }
        /// <summary>
        ///  最大价格 
        /// </summary>
        public string max_jiangjin
        {
            get;
            set;
        }
        /// <summary>
        /// 连锁酒店名称 
        /// </summary>
        public string liansuo
        {
            get;
            set;
        }
        /// <summary>
        /// 酒店星级 
        /// </summary>
        public int xingji
        {
            get;
            set;
        }
        /// <summary>
        /// 酒店服务(以|分隔，如：adsl|card，推荐使用service字段) 
        /// </summary>
        public string fuwu
        {
            get;
            set;
        }
        /// <summary>
        ///  开业时间 
        /// </summary>
        public string kaiye
        {
            get;
            set;
        }
        /// <summary>
        /// 装修时间 
        /// </summary>
        public string zhuangxiu
        {
            get;
            set;
        }
        /// <summary>
        /// 早餐价格 
        /// </summary>
        public string zaocanPrice
        {
            get;
            set;
        }
        /// <summary>
        /// 交通位置 
        /// </summary>
        public string traffic
        {
            get;
            set;
        }
        /// <summary>
        /// 服务 
        /// </summary>
        public string service
        {
            get;
            set;
        }
        /// <summary>
        /// 餐饮信息 
        /// </summary>
        public string canyin
        {
            get;
            set;
        }
        /// <summary>
        /// 所支持的银行卡((以|分隔，如：牡丹卡,金穗卡,长城卡,龙卡,太平洋卡,东方卡) 
        /// </summary>
        public string card
        {
            get;
            set;
        }
        /// <summary>
        ///  城市id 
        /// </summary>
        public string ecityid
        {
            get;
            set;
        }
        /// <summary>
        /// 城市名称 
        /// </summary>
        public string cityname
        {
            get;
            set;
        }
        /// <summary>
        /// 评分（好评+中评-差评=总分） 
        /// </summary>
        public string df_scores
        {
            get;
            set;
        }
        /// <summary>
        /// 评价（以$分隔，如：37$13$2，代表好评$中评$差评） 
        /// </summary>
        public string df_haoping
        {
            get;
            set;
        }
        /// <summary>
        ///  酒店简介 
        /// </summary>
        public string content
        {
            get;
            set;
        }
        /// <summary>
        /// 经度 
        /// </summary>
        public string lng
        {
            get;
            set;
        }
        /// <summary>
        /// 纬度 
        /// </summary>
        public string lat
        {
            get;
            set;
        }
        /// <summary>
        /// 百度地图经度 
        /// </summary>
        public string baidu_lng
        {
            get;
            set;
        }
        /// <summary>
        /// 百度地图纬度 
        /// </summary>
        public string baidu_lat
        {
            get;
            set;
        }
        /// <summary>
        /// 酒店tags（以，分隔，如：安静,经济,出行方便,繁华地区,优质服务） 
        /// </summary>
        public string tags
        {
            get;
            set;
        }
        /// <summary>
        /// 商业区id 
        /// </summary>
        public string esdid
        {
            get;
            set;
        }
        /// <summary>
        /// 连锁酒店id 
        /// </summary>
        public int liansuoid
        {
            get;
            set;
        }
        /// <summary>
        /// 行政区域id 
        /// </summary>
        public string eareaid
        {
            get;
            set;
        }
        /// <summary>
        /// 商业区名称 
        /// </summary>
        public string esdname
        {
            get;
            set;
        }
        /// <summary>
        /// 距离（单位米，如果经纬度不为空，则显示此字段） 
        /// </summary>
        public int juli
        {
            get;
            set;
        }
        /// <summary>
        /// 娱乐信息 
        /// </summary>
        public string yulejianshen
        {
            get;
            set;
        }
        /// <summary>
        /// 交通指南 
        /// </summary>
        public string traffic_zhinan
        {
            get;
            set;
        }
        /// <summary>
        /// 酒店简述 
        /// </summary>
        public string jianshu
        {
            get;
            set;
        }
        /// <summary>
        /// 酒店荣誉（特色） 
        /// </summary>
        public string teshe
        {
            get;
            set;
        }
        /// <summary>
        /// 1为客栈 0为酒店
        /// </summary>
        public int is_kezhan
        {
            get;
            set;
        }

        /// <summary>
        /// 添加日期
        /// </summary>
        public DateTime adddate
        {
            get;
            set;
        }
        /// <summary>
        /// 携程酒店id
        /// </summary>
        public int ctriphotelid
        {
            get;
            set;
        }
        /// <summary>
        /// 联盟id
        /// </summary>
        public string unionid
        {
            get;
            set;
        }
    }
}

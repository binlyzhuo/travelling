using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Zhuna
{
    /// <summary>
    /// 酒店信息
    /// </summary>
    public class ZhunaHotelInfo
    {
        /// <summary>
        /// 酒店ID
        /// </summary>
        public int id { set; get; }

        /// <summary>
        /// 酒店名称
        /// </summary>
        public string hotelname { set; get; }

        /// <summary>
        /// 地址
        /// </summary>
        public string address { set; get; }

        /// <summary>
        /// 酒店图片
        /// </summary>
        public string picture { set; get; }

        /// <summary>
        /// 经度
        /// </summary>
        public string x { set; get; }

        /// <summary>
        /// 纬度
        /// </summary>
        public string y { set; get; }

        /// <summary>
        /// 最低价格 
        /// </summary>
        public int min_jiage { set; get; }

        /// <summary>
        /// 最大价格 
        /// </summary>
        public string max_jiangjin { set; get; }

        /// <summary>
        /// 连锁酒店名称 
        /// </summary>
        public string liansuo { set; get; }

        /// <summary>
        /// 酒店星级 
        /// </summary>
        public int xingji { set; get; }

        /// <summary>
        /// 酒店服务(以|分隔，如：adsl|card，推荐使用service字段) 
        /// </summary>
        public string fuwu { set; get; }

        /// <summary>
        /// 开业时间 
        /// </summary>
        public string kaiye { set; get; }

        /// <summary>
        /// 装修时间
        /// </summary>
        public string zhuangxiu { set; get; }

        /// <summary>
        /// 早餐价格 
        /// </summary>
        public string zaocanPrice { set; get; }

        /// <summary>
        /// 交通位置 
        /// </summary>
        public string traffic { set; get; }

        /// <summary>
        ///  服务
        /// </summary>
        public string service { set; get; }

        /// <summary>
        /// 餐饮信息 
        /// </summary>
        public string canyin { set; get; }

        /// <summary>
        /// 所支持的银行卡((以|分隔，如：牡丹卡,金穗卡,长城卡,龙卡,太平洋卡,东方卡) 
        /// </summary>
        public string card { set; get; }

        /// <summary>
        /// 城市id 
        /// </summary>
        public string ecityid { set; get; }

        public string cityid { set; get; }

        /// <summary>
        /// 城市名称 
        /// </summary>
        public string cityname { set; get; }

        /// <summary>
        /// 评分（好评+中评-差评=总分） 
        /// </summary>
        public string df_scores { set; get; }

        /// <summary>
        /// 评价（以$分隔，如：37$13$2，代表好评$中评$差评） 
        /// </summary>
        public string df_haoping { set; get; }

        /// <summary>
        /// 酒店简介 
        /// </summary>
        public string content { set; get; }

        /// <summary>
        ///  经度 
        /// </summary>
        public string lng { set; get; }

        /// <summary>
        /// 纬度 
        /// </summary>
        public string lat { set; get; }

        /// <summary>
        /// 百度地图经度 
        /// </summary>
        public string baidu_lng { set; get; }

        /// <summary>
        /// 百度地图纬度 
        /// </summary>
        public string baidu_lat { set; get; }

        /// <summary>
        /// 酒店tags（以，分隔，如：安静,经济,出行方便,繁华地区,优质服务） 
        /// </summary>
        public string tags { set; get; }

        /// <summary>
        /// 商业区id 
        /// </summary>
        public string esdid { set; get; }

        /// <summary>
        /// 连锁酒店id 
        /// </summary>
        public int? liansuoid { set; get; }

        /// <summary>
        /// 行政区域id 
        /// </summary>
        public string eareaid { set; get; }

        /// <summary>
        /// 商业区名称 
        /// </summary>
        public string esdname { set; get; }

        /// <summary>
        /// 距离（单位米，如果经纬度不为空，则显示此字段） 
        /// </summary>
        public int juli { set; get; }

        /// <summary>
        /// 娱乐信息 
        /// </summary>
        public string yulejianshen { set; get; }

        /// <summary>
        /// 交通指南 
        /// </summary>
        public string traffic_zhinan { set; get; }

        /// <summary>
        /// 酒店简述 
        /// </summary>
        public string jianshu { set; get; }

        /// <summary>
        /// 酒店荣誉（特色） 
        /// </summary>
        public string teshe { set; get; }

        /// <summary>
        /// 1为客栈 0为酒店 
        /// </summary>
        public int is_kezhan { set; get; }

        public int ctripcityid { set; get; }
    }
}

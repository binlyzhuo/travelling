using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.TC.Hotel
{
    public class TCHotelDetailInfo:TCHotelInfo
    {
        public string nearby { set; get; }
        public List<TCHotelImpress> impressList { set; get; }
        public int chainId { set; get; }
        public string chainName { set; get; }

        /// <summary>
        /// 商业区
        /// </summary>
        public List<TCBizSection> bizSection { set; get; }

        /// <summary>
        /// 开业日期
        /// </summary>
        public string openingDate { set; get; }

        /// <summary>
        /// 装修日期
        /// </summary>
        public string decoDate { set; get; }

        /// <summary>
        /// 额外服务
        /// </summary>
        public string additionalService { set; get; }

        /// <summary>
        /// 服务
        /// </summary>
        public string service { set; get; }

        /// <summary>
        /// 设施
        /// </summary>
        public string facility { set; get; }

        /// <summary>
        /// 酒店服务列表
        /// </summary>
        public List<TCHotelServiceInfo> est2List { set; get; }

        /// <summary>
        /// 餐饮
        /// </summary>
        public string catering { set; get; }

        /// <summary>
        /// 休闲
        /// </summary>
        public string recreation { set; get; }

        /// <summary>
        /// 支持信用卡
        /// </summary>
        public string creditCard { set; get; }

        public string introPhoto { set; get; }

        public int UnionId = 1;


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.TC.Hotel
{
    public class TCHotelInfo
    {
        public int hotelId { set; get; }
        public string hotelName { set; get; }

        /// <summary>
        /// 酒店介绍
        /// </summary>
        public string intro { set; get; }
        public string oneWord { set; get; }
        public string address { set; get; }
        public string street { set; get; }
        public string streetAddr { set; get; }
        public string img { set; get; }
        public int groupBuy { set; get; }
        public string roomType { set; get; }
        public string createDate { set; get; }
        public int viewCount { set; get; }
        public int recmdLevel { set; get; }
        public decimal lowestPrice { set; get; }
        public decimal highestPrice { set; get; }
        public string longitude { set; get; }
        public string latitude { set; get; }
        public int cityId { set; get; }
        public string cityName { set; get; }
        public int sectionId { set; get; }
        public string sectionName { set; get; }
        public int bizSectionId { set; get; }

        public string bizSectionName { set; get; }
        public int starRatedId { set; get; }
        public string starRatedClass { set; get; }
        public string starRatedName { set; get; }
        public int commentTotal { set; get; }

        public int commentGood { set; get; }
        public int commentMid { set; get; }
        public int commentBad { set; get; }
        public string remark { set; get; }

        public int UnionId = 1;
        
    }
}

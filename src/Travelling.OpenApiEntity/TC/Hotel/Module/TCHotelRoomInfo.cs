using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.TC.Hotel.Module
{
    /// <summary>
    /// 酒店房型信息
    /// </summary>
    public class TCHotelRoomInfo
    {
        /// <summary>
        /// 房型Id
        /// </summary>
        public int roomTypeId { set; get; }

        /// <summary>
        /// 房型名称
        /// </summary>
        public string roomName { set; get; }

        /// <summary>
        /// 房间数
        /// </summary>
        public int roomCount { set; get; }

        /// <summary>
        /// 床型
        /// </summary>
        public string bed { set; get; }

        /// <summary>
        /// 床宽
        /// </summary>
        public string bedWidth { set; get; }

        /// <summary>
        /// 是否允许加床
        /// </summary>
        public int allowAddBed { set; get; }

        /// <summary>
        /// 加床说明
        /// </summary>
        public string allowAddBedRemark { set; get; }

        /// <summary>
        /// 早餐
        /// </summary>
        public string breakfast { set; get; }

        /// <summary>
        /// 面积
        /// </summary>
        public int area { set; get; }

        /// <summary>
        /// 楼层
        /// </summary>
        public string floor { set; get; }

        /// <summary>
        /// 宽带
        /// 0-无1-有(全免) 2-有(部免) 3-有(全收) 4-有(部收)
        /// </summary>
        public int adsl { set; get; }

        /// <summary>
        /// 宽带说明
        /// </summary>
        public string adslRemark { set; get; }

        /// <summary>
        /// 是否无烟
        /// 0-有,1-可无烟处理,2-无烟房,3-无烟楼层
        /// </summary>
        public int noSmoking { set; get; }

        /// <summary>
        /// 是否有卫浴
        /// 0-无卫浴,1-独立卫浴,2-淋浴,3-浴缸
        /// </summary>
        public int ownBath { set; get; }

        /// <summary>
        /// 图片路径
        /// </summary>
        public string photoUrl { set; get; }

        /// <summary>
        /// 
        /// </summary>
        public int adviceAmount { set; get; }

        /// <summary>
        /// 房型备注
        /// </summary>
        public string roomTypeRemark { set; get; }

        /// <summary>
        /// 证件类型
        /// </summary>
        public string certificateType { set; get; }

        /// <summary>
        /// 价格策略列表
        /// </summary>
        public List<TCHotelRoomPricePolicyInfo> PolicyInfos { set; get; }

    }
}

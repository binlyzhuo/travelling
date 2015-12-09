using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.Hotel
{
    public class HotelRoomInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            get;
            set;
        }
        /// <summary>
        /// 酒店ID
        /// </summary>
        public int HotelId
        {
            get;
            set;
        }
        /// <summary>
        /// 房间类型名称
        /// </summary>
        public string RoomTypeName
        {
            get;
            set;
        }
        /// <summary>
        /// 标准入住人数
        /// </summary>
        public int StandardOccupancy
        {
            get;
            set;
        }
        /// <summary>
        /// 床的尺寸
        /// </summary>
        public string Size
        {
            get;
            set;
        }
        /// <summary>
        /// 房型代码，对应Ctrip基础房型
        /// </summary>
        public int RoomTypeCode
        {
            get;
            set;
        }
        /// <summary>
        /// 楼层
        /// </summary>
        public string Floor
        {
            get;
            set;
        }
        /// <summary>
        /// 床型代码，参考CodeList(BED)
        /// </summary>
        public string BedTypeCode
        {
            get;
            set;
        }
        /// <summary>
        /// 房间数量
        /// </summary>
        public int Quantity
        {
            get;
            set;
        }
        /// <summary>
        /// 房型描述信息
        /// </summary>
        public string DescriptiveText
        {
            get;
            set;
        }
        /// <summary>
        /// 是否可预定
        /// </summary>
        public int EnableBooking
        {
            get;
            set;
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            get;
            set;
        }
        /// <summary>
        /// 房间设施
        /// </summary>
        public string Facility
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public int InvBlockCode
        {
            get;
            set;
        }
        /// <summary>
        /// 房间大小
        /// </summary>
        public int RoomSize
        {
            get;
            set;
        }
        /// <summary>
        /// 禁止吸烟
        /// </summary>
        public int NonSmoking
        {
            get;
            set;
        }
        /// <summary>
        /// 同步状态
        /// </summary>
        public int SyncState
        {
            get;
            set;
        }
    }
}

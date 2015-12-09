using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.ViewModel.Dto.Hotel;

namespace Travelling.ViewModel.Hotel
{
    /// <summary>
    /// 酒店相关信息
    /// </summary>
    public class HotelDetailInfo
    {
        /// <summary>
        /// 酒店详细信息
        /// </summary>
        public HotelDescription HotelDescription { set; get; }

        /// <summary>
        /// 酒店服务设施
        /// </summary>
        public List<HotelServiceInfo> HotelServices { set; get; }

        /// <summary>
        /// 酒店策络信息
        /// </summary>
        public HotelPolicyInfo PolicyInfo { set; get; }

        /// <summary>
        /// 酒店相关描述信息
        /// </summary>
        public List<HotelMediaTextDescription> TextDescriptions { set; get; }

        /// <summary>
        /// 酒店图片信息
        /// </summary>
        public List<HotelMediaImgDescription> ImgDescriptions { set; get; }
    }
}

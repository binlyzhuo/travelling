using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.Hotel
{
    public class HotelBrandDto
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
        /// 品牌ID
        /// </summary>
        public int BrandID
        {
            set;
            get;
        }
        /// <summary>
        /// 住哪品牌ID
        /// </summary>
        public int ZhunaBrandID
        {
            get;
            set;
        }
        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName
        {
            get;
            set;
        }
        /// <summary>
        /// 品牌图片
        /// </summary>
        public string BrandImg
        {
            get;
            set;
        }
        /// <summary>
        /// 酒店个数
        /// </summary>
        public int HotelCount
        {
            get;
            set;
        }
    }
}

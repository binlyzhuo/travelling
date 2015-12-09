using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.Hotel
{
    public class HotelBrandDetailInfo
    {
        /// <summary>
        /// 品牌id
        /// </summary>
        public int BrandID
        {
            set;
            get;
        }
        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName
        {
            set;
            get;
        }
        /// <summary>
        /// 品牌英文名称
        /// </summary>
        public string BrandEName
        {
            set;
            get;
        }
        /// <summary>
        /// 品牌描述
        /// </summary>
        public string Description
        {
            set;
            get;
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            set;
            get;
        }
        /// <summary>
        /// 品牌图片
        /// </summary>
        public string BrandImg
        {
            set;
            get;
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string BrandTel
        {
            set;
            get;
        }
        /// <summary>
        /// 品牌类型
        /// </summary>
        public int BrandType
        {
            set;
            get;
        }
        /// <summary>
        /// 是否查询推荐
        /// </summary>
        public int IsSearchRecommend
        {
            set;
            get;
        }
        /// <summary>
        /// 是否热门品牌
        /// </summary>
        public int IsHotBrand
        {
            set;
            get;
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int OrderIndex
        {
            set;
            get;
        }

        /// <summary>
        /// 类型,0-经济,1-高端
        /// </summary>
        public int Type
        {
            set;
            get;
        }
        /// <summary>
        /// 有效状态
        /// </summary>
        public int State
        {
            set;
            get;
        }
    }
}

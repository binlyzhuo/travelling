using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.OpenApiEntity.Scenery;

namespace Travelling.OpenApiEntity.TC.Hotel
{
    public class GetHotelListCallEntity : TongChengBaseCallEntity
    {
        private int page = 1;
        private int pagesize = 12;
        /// <summary>
        /// 城市ID
        /// </summary>
        public int cityId { set; get; }

        /// <summary>
        /// 城市名称
        /// </summary>
        public string CityName { set; get; }

        /// <summary>
        /// 格式为：最低价，最高价
        /// 价格为decimal类型，保留两位小数
        /// </summary>
        public string priceRange { set; get; }

        /// <summary>
        /// 行政区域ID
        /// </summary>
        public int? sectionId { set; get; }

        /// <summary>
        /// 入住日期
        /// </summary>
        public DateTime comeDate { set; get; }

        /// <summary>
        /// 离店日期
        /// </summary>
        public DateTime leaveDate { set; get; }

        /// <summary>
        /// 酒店主题
        /// </summary>
        public int? themeId { set; get; }

        /// <summary>
        /// 商业区Id
        /// </summary>
        public int? bizSectionId { set; get; }

        /// <summary>
        /// 连锁酒店id
        /// </summary>
        public int? chainId { set; get; }

        /// <summary>
        /// 星级酒店对应的数字格式:1,2英文逗号分隔多个
        /// </summary>
        public string starRatedId { set; get; }

        /// <summary>
        /// 排序类型
        /// 1价格由低到高
        /// 2价格由高到低
        /// 3入住量有多到少
        /// 4推荐度
        /// 5按照距离由近及远排序,仅再传入坐标和距离时有效
        /// 6同程推荐排序
        /// </summary>
        public int? sortType { set; get; }

        /// <summary>
        /// 搜索关键字
        /// </summary>
        public string keyword { set; get; }

        /// <summary>
        /// keyword不为空时必传
        /// </summary>
        public string searchFields { set; get; }

        /// <summary>
        /// 支付类型(新)
        /// 0-现付；
        /// 3-预付；
        /// 1，2，4， 5担保 （不考虑超时超量）
        /// 1，2 肯定不包含超时超量
        /// 4，5 不确定，可能包含也可能不包含
        /// </summary>
        public int? ifPDB { set; get; }

        /// <summary>
        /// 页码
        /// </summary>
        public int Page { 
          get
            {
                return this.page;
            }
            set
            {
                this.page = value;
            }
        }


        public int PageSize
        {
            get
            {
                return this.pagesize;
            }
            set
            {
                this.pagesize = value;
            }
        }

    }
}

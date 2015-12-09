using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Dto.Zhuna
{
    public class Zhuna_HotelChainDto
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        public int id
        {
            get;
            set;
        }
        /// <summary>
        /// 连锁名称
        /// </summary>
        public string lsname
        {
            get;
            set;
        }
        /// <summary>
        /// 连锁名称
        /// </summary>
        public string liansuo
        {
            get;
            set;
        }
        /// <summary>
        /// 图片
        /// </summary>
        public string tupian
        {
            get;
            set;
        }
        /// <summary>
        /// 酒店个数
        /// </summary>
        public int hotelnum
        {
            get;
            set;
        }
        /// <summary>
        /// 连锁品牌名称
        /// </summary>
        public string ls
        {
            get;
            set;
        }
        /// <summary>
        /// 级别
        /// </summary>
        public int jibie
        {
            get;
            set;
        }
        /// <summary>
        /// 连锁ID
        /// </summary>
        public int lsid
        {
            get;
            set;
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime adddate
        {
            get;
            set;
        }
    }
}

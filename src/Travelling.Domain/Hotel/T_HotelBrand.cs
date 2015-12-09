using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Domain.Hotel
{
    /// <summary>
    /// 酒店品牌信息
    /// </summary>
    [Serializable]
    public partial class T_HotelBrand
    {
        public T_HotelBrand()
        { }
        #region Model
        private int _id;
        private int _brandid = 0;
        private int _zhunabrandid = 0;
        private string _brandname = "";
        private string _brandimg = "";
        private int _hotelcount = 0;
        /// <summary>
        /// 主键
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 品牌ID
        /// </summary>
        public int BrandID
        {
            set { _brandid = value; }
            get { return _brandid; }
        }
        /// <summary>
        /// 住哪品牌ID
        /// </summary>
        public int ZhunaBrandID
        {
            set { _zhunabrandid = value; }
            get { return _zhunabrandid; }
        }
        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName
        {
            set { _brandname = value; }
            get { return _brandname; }
        }
        /// <summary>
        /// 品牌图片
        /// </summary>
        public string BrandImg
        {
            set { _brandimg = value; }
            get { return _brandimg; }
        }
        /// <summary>
        /// 酒店个数
        /// </summary>
        public int HotelCount
        {
            set { _hotelcount = value; }
            get { return _hotelcount; }
        }
        #endregion Model

    }
}

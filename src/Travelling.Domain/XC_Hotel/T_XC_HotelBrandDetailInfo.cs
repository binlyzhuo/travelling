using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;

namespace Travelling.Domain.Hotel
{
    /// <summary>
    /// 酒店品牌详细信息
    /// </summary>
    [Serializable]
    [PrimaryKey("BrandID", AutoIncrement = false)]
    public partial class T_XC_HotelBrandDetailInfo
    {
        public T_XC_HotelBrandDetailInfo()
        { }
        #region Model
        private int _brandid;
        private string _brandname = "";
        private string _brandename;
        private string _description = "";
        private DateTime _adddate = DateTime.Now;
        private string _brandimg = "";
        private string _brandtel = "";
        private int _brandtype = 0;
        private int _issearchrecommend = 0;
        private int _ishotbrand = 0;
        private int _orderindex = 0;
        private int _type = 0;
        private int _state = 1;
        /// <summary>
        /// 品牌id
        /// </summary>
        public int BrandID
        {
            set { _brandid = value; }
            get { return _brandid; }
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
        /// 品牌英文名称
        /// </summary>
        public string BrandEName
        {
            set { _brandename = value; }
            get { return _brandename; }
        }
        /// <summary>
        /// 品牌描述
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddDate
        {
            set { _adddate = value; }
            get { return _adddate; }
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
        /// 联系电话
        /// </summary>
        public string BrandTel
        {
            set { _brandtel = value; }
            get { return _brandtel; }
        }
        /// <summary>
        /// 品牌类型
        /// </summary>
        public int BrandType
        {
            set { _brandtype = value; }
            get { return _brandtype; }
        }
        /// <summary>
        /// 是否查询推荐
        /// </summary>
        public int IsSearchRecommend
        {
            set { _issearchrecommend = value; }
            get { return _issearchrecommend; }
        }
        /// <summary>
        /// 是否热门品牌
        /// </summary>
        public int IsHotBrand
        {
            set { _ishotbrand = value; }
            get { return _ishotbrand; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int OrderIndex
        {
            set { _orderindex = value; }
            get { return _orderindex; }
        }

        /// <summary>
        /// 类型,0-经济,1-高端
        /// </summary>
        public int Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 有效状态
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        #endregion Model

    }
}

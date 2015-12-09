using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;

namespace Travelling.Domain.Zhuna_Hotel
{
    /// <summary>
    /// 酒店连锁品牌
    /// </summary>
    [Serializable]
    [PrimaryKey("id",AutoIncrement=false)]
    public partial class Zhuna_HotelChain
    {
        public Zhuna_HotelChain()
        { }
        #region Model
        private int _id;
        private string _lsname = "";
        private string _liansuo = "";
        private string _tupian = "";
        private int _hotelnum = 0;
        private string _ls = "";
        private int _jibie = 0;
        private int _lsid = 0;
        private DateTime _adddate = DateTime.Now;
        private int _ctripbrandid = 0;
        /// <summary>
        /// 主键Id
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 连锁名称
        /// </summary>
        public string lsname
        {
            set { _lsname = value; }
            get { return _lsname; }
        }
        /// <summary>
        /// 连锁名称
        /// </summary>
        public string liansuo
        {
            set { _liansuo = value; }
            get { return _liansuo; }
        }
        /// <summary>
        /// 图片
        /// </summary>
        public string tupian
        {
            set { _tupian = value; }
            get { return _tupian; }
        }
        /// <summary>
        /// 酒店个数
        /// </summary>
        public int hotelnum
        {
            set { _hotelnum = value; }
            get { return _hotelnum; }
        }
        /// <summary>
        /// 连锁品牌名称
        /// </summary>
        public string ls
        {
            set { _ls = value; }
            get { return _ls; }
        }
        /// <summary>
        /// 级别
        /// </summary>
        public int jibie
        {
            set { _jibie = value; }
            get { return _jibie; }
        }
        /// <summary>
        /// 连锁ID
        /// </summary>
        public int lsid
        {
            set { _lsid = value; }
            get { return _lsid; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime adddate
        {
            set { _adddate = value; }
            get { return _adddate; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ctripbrandid
        {
            set { _ctripbrandid = value; }
            get { return _ctripbrandid; }
        }
        #endregion Model

    }
}

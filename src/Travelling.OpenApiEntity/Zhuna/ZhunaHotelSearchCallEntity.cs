using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Zhuna
{
    /// <summary>
    /// 住哪酒店查询请求实体
    /// </summary>
    public class ZhunaHotelSearchCallEntity
    {
        private int _page = 1;
        private int _pagesize = 15;


        public string cityid { set; get; }
        public int pagesize
        {
            get
            {
                return this._pagesize;
            }
            set
            {
                this._pagesize = value;
            }
        }
        public int pg
        {
            get
            {
                return this._page;
            }
            set
            {
                this._page = value;
            }
        }
        public int px { set; get; }
        public int minprice { set; get; }
        public int maxprice { set; get; }
        public string hn { set; get; }
        public string cityname { set; get; }
        public int lsid { set; get; }
        public string bid { set; get; }
        public string areaid { set; get; }
        public int rank { set; get; }
        public int hid { set; get; }
        public string x { set; get; }
        public string y { set; get; }
        public string lng { set; get; }
        public string lat { set; get; }
        public int juli { set; get; }
        public string field { set; get; }
        public string key { set; get; }

        public int promotion { set; get; }

        public int is_kezhan { set; get; }

    }
}

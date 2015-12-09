using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Ctrip.Tuan
{
    public class GroupProductListCallEntity : CtripBaseAPICallEntity
    {

        public GroupProductListCallEntity()
            : base("GroupProductList")
        {

        }

        private int pageSize = 21;
        public int PageSize
        {
            get
            {
                return this.pageSize;
            }
            set
            {
                this.pageSize = value;
            }
        }

        private int pageNumber = 1;
        public int PageNumber
        {
            set
            {
                this.PageNumber = value;
            }
            get
            {
                return this.pageNumber;
            }
        }

        private int sortType = 0;
        public int SortType
        {
            get
            {
                return this.sortType;
            }
            set
            {
                this.sortType = value;
            }
        }

        private int itemType = 1;
        public int ItemType
        {
            get
            {
                return this.itemType;
            }
            set
            {
                this.itemType = value;
            }
        }


        public DateTime BeginDate { set; get; }
        public DateTime EndDate { set; get; }
        public int? Lowprice { set; get; }
        public int? Upperprice { set; get; }
        public string CityName { set; get; }

        public int CityId { set; get; }
        public int TopCount { set; get; }

        public int ProductType { set; get; }
        public int Rank { set; get; }


    }
}

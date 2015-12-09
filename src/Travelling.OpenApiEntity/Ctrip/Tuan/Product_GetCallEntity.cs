using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Ctrip.Tuan
{
    public class Product_GetCallEntity:CtripBaseAPICallEntity
    {
        public Product_GetCallEntity()
            : base("Product_Get")
        {
          
        }

        private int itemType = 1;
        private int pageSize = 15;
        private int currentPageIndex = 1;

        public List<string> KeyWords{set;get;}
        public int MinPrice { set; get; }
        public int MaxPrice { set; get; }
        public int CityID { set; get; }
        public string CityName { set; get; }
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
        public int CurrentPageIndex
        {
            get
            {
                return this.currentPageIndex;
            }
            set
            {
                this.currentPageIndex = value;
            }
        }

    }
}

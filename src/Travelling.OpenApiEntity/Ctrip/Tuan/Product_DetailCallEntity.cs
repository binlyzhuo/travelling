using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Ctrip.Tuan
{
    public class Product_DetailCallEntity:CtripBaseAPICallEntity
    {
        public Product_DetailCallEntity()
            : base("Product_Detail")
        {

        }

        public List<int> Products { set; get; }
    }
}

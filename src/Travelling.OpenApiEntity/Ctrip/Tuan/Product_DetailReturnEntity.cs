using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Ctrip.Tuan
{
    public class Product_DetailReturnEntity:CtripBaseAPIReturnEntity
    {
        public List<ProductDetailInfo> ProductDetailInfos { set; get; }
    }
}

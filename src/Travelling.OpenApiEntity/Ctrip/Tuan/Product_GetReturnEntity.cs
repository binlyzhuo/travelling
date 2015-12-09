using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Ctrip.Tuan
{
    /// <summary>
    /// 团购产品请求返回实体
    /// </summary>
    public class Product_GetReturnEntity:CtripBaseAPIReturnEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Product_GetReturnEntity()
        {

        }

        /// <summary>
        /// 团购产品集合
        /// </summary>
        public List<GroupProductInfo> GroupProductInfoList { set; get; }
    }
}

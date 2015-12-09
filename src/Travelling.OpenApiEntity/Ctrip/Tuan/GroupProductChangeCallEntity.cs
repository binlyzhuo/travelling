using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Ctrip.Tuan
{
    public class GroupProductChangeCallEntity:CtripBaseAPICallEntity
    {
        public GroupProductChangeCallEntity()
            : base("GroupProductChange")
        { }

        public DateTime ChangeTime { set; get; }

        /// <summary>
        /// 为空或1是酒店,all不限制，2:餐饮美食;3:酒店套餐;4:其他;6:特惠票券;7:度假旅游
        /// </summary>
        public int? ProductType { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Ctrip.Tuan
{
    public class GroupProductListReturnEntity:CtripBaseAPIReturnEntity
    {
        public List<GroupProductListEntity> GroupDataList { set; get; }
    }
}

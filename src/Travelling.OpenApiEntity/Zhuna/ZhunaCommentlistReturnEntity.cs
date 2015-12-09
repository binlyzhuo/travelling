using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Zhuna
{
    public class ZhunaCommentlistReturnEntity:ZhunaBaseReturnEntity
    {
        public List<ZhunaHotelComment> reqdata { set; get; }
    }
}

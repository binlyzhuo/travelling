using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Zhuna
{
    public class ZhunaHotelCommentReturnEntity:ZhunaBaseReturnEntity
    {
        public List<ZhunaHotelComment> reqdata { set; get; }
    }
}

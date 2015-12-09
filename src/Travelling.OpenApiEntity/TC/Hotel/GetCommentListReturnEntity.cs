using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.OpenApiEntity.TC.Hotel.Module;

namespace Travelling.OpenApiEntity.TC.Hotel
{
    public class GetCommentListReturnEntity:TongChengBaseReturnEntity
    {
        public List<HotelCommentInfo> Comments { set; get; }
    }
}

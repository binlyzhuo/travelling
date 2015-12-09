using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Ctrip.Hotel.Module
{
    public class HotelBookErrorInfo
    {
        public int Type { set; get; }
        public string ShortText
        { set; get; }

        public int Code { set; get; }
        public string Content { set; get; }
    }
}

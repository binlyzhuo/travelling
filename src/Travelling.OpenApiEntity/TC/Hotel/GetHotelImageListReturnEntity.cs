using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.OpenApiEntity.TC.Hotel.Module;

namespace Travelling.OpenApiEntity.TC.Hotel
{
    public class GetHotelImageListReturnEntity:TongChengBaseReturnEntity
    {
        public List<TCHotelImage> Imgs { set; get; }
        public string imageBaseUrl { set; get; }
        public List<string> sizeCodeList { set; get; }
        public List<string> sizeCodeListWatermark { set; get; }
    }
}

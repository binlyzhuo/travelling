using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.ViewModel.Dto.Hotel;
using Travelling.ViewModel.Hotel;

namespace Travelling.ViewModel.Travel
{
    public class HotelFindAreaViewResult:JsonViewResult
    {
        public List<CityAreaPrimaryInfo> AreaInfos { set; get; }
        public List<LocationInfo> locations { set; get; }
        public int AreaCode { set; get; }
        public int IsLocation { set; get; }
        public int DataIndex { set; get; }

        public int CityId { set; get; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Admin
{
    public class HotelCityDetailSearchModel:BasePageQuery
    {
        //    var senddata = {
        //    provinceid: provinceid,
        //    cityname: cityname,
        //    isrecommend: isrecommend,
        //    ishotcity: ishotcity,
        //    issearchrecommend: issearchrecommend
        //};
        public int? ProvinceId { set; get; }
        public string CityName { set; get; }
        public int? IsRecommend { set; get; }

        public int? IsHotcity { set; get; }
        public int? IsSearchRecommend { set; get; }

        public int? OrderType { set; get; }

        public int? OrderField { set; get; }
    }
}

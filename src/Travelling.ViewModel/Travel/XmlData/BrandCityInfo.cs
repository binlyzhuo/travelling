using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.ViewModel.Travel.XmlData
{
    public class BrandCityInfo
    {
        public int BrandId { set; get; }
        public string BrandName { set; get; }

        public List<CityInfo> Cities { set; get; }
    }

    
}

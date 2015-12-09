using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.TC.Hotel.Module
{
    public class CityInfo
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Pinyin { set; get; }
        public string Index { set; get; }

        public List<RegionInfo> Regions { set; get; }
        public List<SectionInfo> Sections { set; get; }
    }
}

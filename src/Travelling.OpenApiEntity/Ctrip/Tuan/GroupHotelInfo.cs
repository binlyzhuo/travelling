using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.OpenApiEntity.Ctrip.Tuan
{
    public class GroupHotelInfo
    {
        public string Name { set; get; }
        public int ID { set; get; }
        public int StarRate { set; get; }
        public string IsStarRate { set; get; }
        public int CtripStar { set; get; }
        public decimal CommentValue { set; get; }
        public int HotelID { set; get; }
        public int ProvinceID { set; get; }
        public string ProvinceName { set; get; }
        public int CityID { set; get; }
        public string CityName { set; get; }
        public string Pinyin { set; get; }
        public int LocationID { set; get; }
        public string LocationName { set; get; }
        public int ZoneID { set; get; }
        public string ZoneName { set; get; }
        public string Address { set; get; }

        //public string Contact { set; get; }
        //public string Phone { set; get; }

        public ContactInfo Contact { set; get; }

        public List<PositionInfo> Postions { set; get; }

        public List<RoomInfo> RoomInfos { set; get; }
    }
}

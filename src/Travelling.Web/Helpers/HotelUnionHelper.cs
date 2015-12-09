using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.Web.Helpers
{
    public class HotelUnionHelper
    {
        public static string GetUnionName(int unionid)
        {
            string union = "";
            switch(unionid)
            {
                case 0:
                    union = "携程";
                    break;
                case 1:
                    union = "住哪";
                    break;
                case 2:
                    union = "同程";
                    break;
            }
            return union;
        }

        public static string GetHotelInfoUrl(int hotelid,int unionid)
        {
            if(unionid==0)
            {
                return string.Format("/hotelinfo_{0}.html",hotelid);
            }
            else
            {
                return string.Format("/hotelinfo{0}_{1}.html",unionid,hotelid);
            }
        }

        public static string GetHotelInfoUrl(int hotelid, int unionid,DateTime inroomDate,DateTime leftRoomDate)
        {
            if (unionid == 0)
            {
                return string.Format("/hotelinfo_{0}.html?startDate={1}&endDate={2}", hotelid,inroomDate.ToString("yyyy-MM-dd"),leftRoomDate.ToString("yyyy-MM-dd"));
            }
            else
            {
                return string.Format("/hotelinfo{0}_{1}.html?startDate={2}&endDate={3}", unionid, hotelid, inroomDate.ToString("yyyy-MM-dd"), leftRoomDate.ToString("yyyy-MM-dd"));
            }
        }

        public static string GetHotelCityBrandInfo(int cityid,int brandid)
        {
            return string.Format("/city{0}/chain{1}.html",cityid,brandid);
        }

        public static string GetHotelMap(int unionId,string lat,string lng,string point)
        {
            if(unionId==0)
            {
                return string.Format("/map/amap?lat={0}&lng={1}&name={2}", lat, lng, point);
            }
            return string.Format("/map/baidumap?lat={0}&lng={1}&name={2}", lat, lng, point);
        }

        public static string HotelSearchWithKey(int cityid,string keywords)
        {
            return string.Format("/hotelsearchlist_{0}/{1}",cityid,keywords.Replace("/","_"));
        }
    }
}

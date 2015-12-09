using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.OpenApiEntity.Zhuna;
using Travelling.OpenApiSDK;

namespace Travelling.OpenApiLogic
{
    public class ZhunaHotelServiceLogic
    {
        public static ZhunaCityReturnEntity GetCity()
        {
            return ZhunaHotelOTAService.Instance().GetCity();
        }

        public static ZhunaCBDReturnEntity GetCBD(string cityid)
        {
            return ZhunaHotelOTAService.Instance().GetCBD(cityid);
        }

        /// <summary>
        /// 获取城市地标信息
        /// </summary>
        /// <param name="cityid">城市ID</param>
        /// <param name="startIndex">起始索引</param>
        /// <param name="totalCount">个数</param>
        /// <returns>城市地标信息</returns>
        public static ZhunaLableInfoReturnEntity GetLable(string cityid,int startIndex=1,int totalCount=100)
        {
            return ZhunaHotelOTAService.Instance().GetLable(cityid,startIndex,totalCount);
        }

        public static ZhunaHotelChainReturnEntity GetHotelChain(string cityid = "")
        {
            return ZhunaHotelOTAService.Instance().GetHotelChain(cityid);
        }

        public static ZhunaCityareaReturnEntity GetCityarea(string cityid)
        {
            return ZhunaHotelOTAService.Instance().GetCityarea(cityid);
        }

        public static ZhunaLabletypeReturnEntity GetLableType()
        {
            return ZhunaHotelOTAService.Instance().GetLableType();
        }

        public static ZhunaCitychainReturnEntity GetCitychain(int lsid)
        {
            return ZhunaHotelOTAService.Instance().GetCitychain(lsid);
        }

        /// <summary>
        /// 获取城市学校系想你
        /// </summary>
        /// <param name="cityid">城市ID</param>
        /// <returns></returns>
        public static ZhunaSchoolReturnEntity GetSchool(string cityid)
        {
            return ZhunaHotelOTAService.Instance().GetSchool(cityid);
        }

        public static ZhunaSubwaylineReturnEntity GetSubwayline(string cityid)
        {
            return ZhunaHotelOTAService.Instance().GetSubwayline(cityid);
        }

        public static ZhunaSubwaylineReturnEntity GetLablesearchnearby(string cityid, string lng, string lat)
        {
            return ZhunaHotelOTAService.Instance().GetLablesearchnearby(cityid, lng, lat);
        }

        public static ZhunaLablegetxyReturnEntity GetLablegetxy(int lableid)
        {
            return ZhunaHotelOTAService.Instance().GetLablegetxy(lableid);
        }

        /// <summary>
        /// 酒店信息查询
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static ZhunaHotelSearchReturnEntity HotelSearch(ZhunaHotelSearchCallEntity search)
        {
            return ZhunaHotelOTAService.Instance().HotelSearch(search);
        }

        public static ZhunaHotelPromotionReturnEntity HotelPromotionSearch(string cityid)
        {
            return ZhunaHotelOTAService.Instance().HotelPromotionSearch(cityid);
        }

        /// <summary>
        /// 获取酒店房型信息
        /// </summary>
        /// <param name="hotelid">酒店id</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns>酒店房型信息实体</returns>
        public static ZhunaHotelPriceReturnEntity HotelRoomPlanSearch(int hotelid,DateTime start,DateTime end)
        {
            return ZhunaHotelOTAService.Instance().HotelRoomPlanSearch(hotelid, start, end);
        }

        public static ZhunaHotelInfoReturnEntity HotelInfoSearch(int hotelid)
        {
            return ZhunaHotelOTAService.Instance().HotelInfoSearch(hotelid);
        }

        public static ZhunaCommentlistReturnEntity GetCommentlist(string cityid)
        {
            return ZhunaHotelOTAService.Instance().GetCommentlist(cityid);
        }

        /// <summary>
        /// 获取酒店评论
        /// </summary>
        /// <param name="hotelid">酒店ID</param>
        /// <returns></returns>
        public static ZhunaHotelCommentReturnEntity GetHotelComment(int hotelid)
        {
            return ZhunaHotelOTAService.Instance().GetHotelComment(hotelid);
        }

        public static ZhunaQuestionlistReturnEntity GetQuestionlist(string cityid)
        {
            return ZhunaHotelOTAService.Instance().GetQuestionlist(cityid);
        }

        public static ZhunaHotelQuestionReturnEntity GetHotelQuestion(int hotelid)
        {
            return ZhunaHotelOTAService.Instance().GetHotelQuestion(hotelid);
        }

        public static ZhunaHotelpicReturnEntity GetHotelPic(int hotelid)
        {
            return ZhunaHotelOTAService.Instance().GetHotelPic(hotelid);
        }

        public static ZhunaHotelSearchNearByReturnEntity HotelSearchNearBy(string lng,string lat)
        {
            return ZhunaHotelOTAService.Instance().HotelSearchNearBy(lng,lat);
        }
    }
}

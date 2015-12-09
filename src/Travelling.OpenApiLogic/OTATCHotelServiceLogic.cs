using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.OpenApiEntity.TC.Hotel;
using Travelling.OpenApiSDK;

namespace Travelling.OpenApiLogic
{
    /// <summary>
    /// 酒店接口业务
    /// </summary>
    public class OTATCHotelServiceLogic
    {
        static TCHotelOTAService tcHotelOTAService;
        static OTATCHotelServiceLogic()
        {
            tcHotelOTAService = new TCHotelOTAService();
        }

        /// <summary>
        /// 获取省份信息
        /// </summary>
        /// <returns></returns>
        public static GetProvinceListReturnEntity GetProvinceList()
        {
            var provinces = tcHotelOTAService.GetProvinceList();
            return provinces;
        }

        /// <summary>
        /// 获取酒店信息列表
        /// </summary>
        /// <param name="callEntity"></param>
        /// <returns></returns>
        public static GetHotelListReturnEntity TC_GetHotelList(GetHotelListCallEntity callEntity)
        {
            return tcHotelOTAService.GetHotelList(callEntity);
        }

        /// <summary>
        /// 获取酒店详细信息
        /// </summary>
        /// <param name="hotelId">酒店ID</param>
        /// <returns></returns>
        public static GetHotelDetailReturnEntity TC_GetHotelDetail(int hotelId)
        {

            GetHotelDetailCallEntity callEntity = new GetHotelDetailCallEntity();
            callEntity.HotelId = hotelId;
            return tcHotelOTAService.GetHotelDetail(callEntity);
        }

        /// <summary>
        /// 获取酒店房间信息
        /// </summary>
        /// <param name="callEntity">请求实体</param>
        /// <returns></returns>
        public static GetHotelRoomsReturnEntity TC_GetHotelRooms(int hotelid,DateTime comeDate,DateTime leaveDate)
        {
            GetHotelRoomsCallEntity callEntity = new GetHotelRoomsCallEntity();
            callEntity.comeDate = comeDate;
            callEntity.leaveDate = leaveDate;
            callEntity.hotelId = hotelid;
            return tcHotelOTAService.GetHotelRooms(callEntity);
        }

        public static GetHotelImageListReturnEntity TC_GetHotelImageList(int hotelId)
        {
            GetHotelImageListCallEntity callEntity = new GetHotelImageListCallEntity() { hotelId = hotelId };
            return tcHotelOTAService.GetHotelImageList(callEntity);
        }

        public static GetHotelTrafficInfoReturnEntity TC_GetHotelTrafficInfo(int hotelId)
        {
            GetHotelTrafficInfoCallEntity callEntity = new GetHotelTrafficInfoCallEntity() { HotelId = hotelId };
            return tcHotelOTAService.GetHotelTrafficInfo(callEntity);
        }

        public static GetHotelRoomsMultiReturnEntity TC_GetHotelRoomsMulti(GetHotelRoomsMultiCallEntity callEntity)
        {
            return tcHotelOTAService.GetHotelRoomsMulti(callEntity);
        }

        public static GetHotelBookingPolicyReturnEntity TC_GetHotelBookingPolicy()
        {
            GetHotelBookingPolicyCallEntity callEntity = new GetHotelBookingPolicyCallEntity();
            //callEntity.comeDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            return null;
        }

        /// <summary>
        /// 游客酒店点评
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public static GetCommentListReturnEntity GetCommentList(int hotelId)
        {
            return tcHotelOTAService.GetCommentList(hotelId);
        }
    }
}

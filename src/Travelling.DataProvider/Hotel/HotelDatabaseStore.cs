using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.DataProvider
{
    public class HotelDatabaseStore
    {
        public static readonly string HotelRoomRatePlanSeachProc = "SP_HotelRoomPlanSearch";
        public static readonly string HotelRoomRatePlansImport = "SP_HotelRoomRatePlanImportOneMonth";
        public static readonly string HotelPriceImport = "SP_HotelLowestPriceImport";
        public static readonly string HotelRoomInfoQuery = "P_HotelRoomInfoServiceQuery";
        public static readonly string HotelRoomInfo = "SP_HotelRoomInfo";
        public static readonly string SceneryInfoSyncRecordInit = "SP_SceneryInfoSyncRecordInit";
        public static readonly string SceneryHotForProvinces = "SP_SceneryHotForProvinces";

        public static readonly string HotCityHotelInfos = "P_HotHotelsForCityInfo";
        public static readonly string HotelNearHotelInfos = "P_GetNearHotelInfos";
        public static readonly string HotelFullQuery = "P_HotelFullQuery";
        public static readonly string HotelRoomPriceQuery = "P_HotelRoomPriceQuery";

        public static readonly string HotelRoomInfoPriceQuery = "P_HotelRoomInfoQuery";

        /// <summary>
        /// 城市推荐酒店信息
        /// </summary>
        public static readonly string HotelPracticalForCity = "P_HotelPracticalForCity";

        /// <summary>
        /// 精选酒店以及城市信息
        /// </summary>
        public static readonly string ChoiceHotelCityInfos = "P_HotelsForChoiceCityInfos";

        /// <summary>
        /// 最优惠酒店信息
        /// </summary>
        public static readonly string HotelMostPractical = "P_HotelMostPractical";

        /// <summary>
        /// 经济型酒店信息
        /// </summary>
        public static readonly string HotelCheapMost = "P_HotelCheapMost";

    }
}

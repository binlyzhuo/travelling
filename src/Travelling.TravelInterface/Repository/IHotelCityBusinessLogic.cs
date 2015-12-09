using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Travelling.Domain;
using Travelling.ViewModel.Dto.Hotel;
using Travelling.ViewModel.Travel;

namespace Travelling.TravelInterface.Repository
{
    /// <summary>
    /// 相关城市信息
    /// </summary>
    public interface IHotelCityBusinessLogic
    {
        
        /// <summary>
        /// 获取酒店推荐城市信息
        /// </summary>
        /// <returns></returns>
        
       
        void InsertProvinces(List<T_XC_HotelProvince> provinces);
        void InsertLocations(List<T_XC_HotelLocation> locations);
        void InsertCountry(List<T_XC_HotelCountry> items);
        void InsertThemes(List<T_XC_HotelTheme> themes);

        

        void InsertHotelCityDetailInfos(List<HotelCityDetailInfo> hotelCityDetailInfos);

        /// <summary>
        /// 获取省份信息
        /// </summary>
        /// <returns></returns>
        List<HotelProvinceInfo> GetHotelProvinces();

        void InsertHotelBrandDetailInfos(List<HotelBrandDetailInfo> hotelBrandDetailsDto);

        /// <summary>
        /// 获取城市信息
        /// </summary>
        /// <returns></returns>
        List<HotelCityDetailInfo> HotelCityDetailInfosGet();

        /// <summary>
        /// 根据城市ID获取城市信息
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        HotelCityDetailInfo HotelCityDetailInfoGetByCityID(int cityId);

        Tuple<List<HotelBrandDetailInfo>, List<HotelBrandDetailInfo>> HotelBrandSearchRecommends();

        /// <summary>
        /// 获取行政区域
        /// </summary>
        /// <returns></returns>
        List<LocationInfo> HotelLocationGet();

        /// <summary>
        /// 根据城市ID获取行政区域
        /// </summary>
        /// <returns></returns>
        List<LocationInfo> HotelLocationGetByCityId(int cityId);

        ReadOnlyCollection<HotelBrandDetailInfo> HotelBrandDetailInfoGetAll();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Hotel;
using Travelling.ViewModel;
using Travelling.ViewModel.Admin;
using Travelling.ViewModel.Dto.Hotel;
using Travelling.ViewModel.Travel;

namespace Travelling.TravelInterface.Repository
{
    public interface IHotelManageBusinessLogic
    {
        PageObjectResult<HotelCityDetailInfo> HotelCityDetailSearch(HotelCityDetailSearchModel search);
        List<HotelProvinceInfo> GetHotelProvinces();

        bool UpdateRecommendState(List<int> cityidList, int state);

        HotelCityDetailInfo GetHotelCityInfo(int cityId);

        bool UpdateHotCityState(List<int> cityidList, int state);

        bool UpdateSearchCityState(List<int> cityidList, int state);

        bool UpdateCityInfo(HotelCityDetailInfo cityInfo);

        PageObjectResult<HotelBrandDetailInfo> HotelBrandInfosSearch(HotelBrandInfoSearchModel search);

        HotelBrandDetailInfo GetHotelBrandDetailInfo(int brandId);

        bool UpdateHotelBrandInfo(HotelBrandDetailInfo brandInfo);

        PageObjectResult<HotelBookingOrder> HotelBookingOrderGetPageResult(HotelOrderInfoSearchModel search);

        bool HotelBookOrderCancel(string orderno);
    }
}

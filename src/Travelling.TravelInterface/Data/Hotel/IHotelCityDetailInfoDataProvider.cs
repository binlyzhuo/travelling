using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;
using Travelling.Domain.Hotel;
using Travelling.ViewModel.Admin;
using Travelling.ViewModel.Hotel;

namespace Travelling.TravelInterface.Data.Hotel
{
    public interface IXC_HotelCityDetailInfoDataProvider : IDataProvider<T_XC_HotelCityDetailInfo>
    {
        Page<T_XC_HotelCityDetailInfo> GetHotelCityDetailInfo(HotelCityDetailSearchModel searchModel);

        bool UpdateRecommendState(List<int> cityidList, int state);

        bool UpdateHotCityState(List<int> cityidList, int state);

        bool UpdateSearchCityState(List<int> cityidList, int state);

        List<T_XC_HotelCityDetailInfo> HotelCityDetailInfoSearch(HotelCityDetailSearchType searchType);

        bool HotelCityDetailInfoInitSyncState();

        bool HotelCityDetailInfoUpdateSyncState(List<int> cityIdList);

        T_XC_HotelCityDetailInfo HotelCityDetailInfoToSyncHotelInfo(int topCount = 1);

        int HotelCityDetailInfoGetToSyncStateCount();
    }
}

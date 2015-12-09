using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.HotelSyncRecord;
using Travelling.ViewModel.Hotel;

namespace Travelling.TravelInterface.Data.HotelSyncRecord
{
    public interface IXC_HotelAreaInfoDataProvider : IDataProvider<T_XC_HotelAreaInfo>
    {
        void InitAreaTypeCode();

        bool InitSyncState();

        bool UpdateSyncState(List<int> idList);

        List<T_XC_HotelAreaInfo> GetAreaInfoToSync(int count = 100);

        List<CityAreaPrimaryInfo> GetCityAreaSummaryInfo();

        

        List<T_XC_HotelAreaInfo> GetCityAreaInfoForLuceneIndex(int topCount = 200);

        List<CityAreaPrimaryInfo> CityAreaInfoGetDistinct();
    }
}

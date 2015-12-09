using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Hotel;
using Travelling.ViewModel.Lucene;
using Travelling.ViewModel.Travel;

namespace Travelling.TravelInterface.Data.Hotel
{
    public interface IHotelInfoDataProvider : IDataProvider<T_HotelInfo>
    {
        List<HotelLuceneIndexInfo> HotelsToLucene();

        void InitHotelInfoIndexState();

        void UpdateIndexState(List<int> idList);

        int GetHotelIndexCount(bool isIndex);

        List<HotelBrandSummaryInfo> HotelBrandSummaryInfos();

        List<HotelCitySummaryInfo> HotelCitySummaryInfos();
    }
}

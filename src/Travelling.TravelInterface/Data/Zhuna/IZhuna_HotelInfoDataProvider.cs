using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Zhuna_Hotel;
using Travelling.ViewModel.Lucene;

namespace Travelling.TravelInterface.Data.Zhuna
{
    public interface IZhuna_HotelInfoDataProvider : IDataProvider<Zhuna_HotelInfo>
    {
        List<HotelLuceneIndexInfo> HotelInfoToLucene();

        bool UpdateHotelLuceneIndexState(List<int> hotelList);

        bool UpdateHotelLuceneIndexStateInit();

        int GetHotelLuceneStateCount(int indexState);
    }
}

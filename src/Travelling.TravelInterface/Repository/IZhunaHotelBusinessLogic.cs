using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Zhuna_Hotel;
using Travelling.ViewModel.Dto.Zhuna;
using Travelling.ViewModel.Lucene;
using Travelling.ViewModel.Travel;

namespace Travelling.TravelInterface.Repository
{
    public interface IZhunaHotelBusinessLogic
    {
        List<Zhuna_CityInfo> ZhunaCityInfosGet();

        bool UpdateCityIdWithCtrip(Zhuna_CityInfo city);
        List<HotelLuceneIndexInfo> HotelsToLucene();

        List<Zhuna_HotelChain> ZhunaHotelChainsGet();

        bool ZhunaHotelChainUpdate(Zhuna_HotelChain hotelChain);

        List<TradeAreaInfo> HotCityTradeAreaGet();

        Tuple<List<SchoolSummaryInfo>, List<SchoolCityInfo>> SchoolSummaryInfos();

        Zhuna_CityInfo GetZhunaCityInfoByCtripCityId(int cityid);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.TravelInterface.Data.Zhuna;
using Travelling.TravelInterface.Repository;
using Ninject;
using Travelling.Domain.Zhuna_Hotel;
using Travelling.ViewModel.Dto.Zhuna;
using Travelling.ViewModel.Lucene;
using Travelling.Caching;
using Travelling.ViewModel.Travel;

namespace Travelling.Repository
{
    public class ZhunaHotelBusinessLogic : BaseZhunaHotelLogic,IZhunaHotelBusinessLogic
    {
        private readonly IZhuna_CityInfoDataProvider zhunaCityData;
        private readonly IZhuna_HotelChainDataProvider zhunaHotelChainData;
        private readonly IZhuna_HotelInfoDataProvider zhunaHotelData;
        private readonly IZhuna_CBDDataProvider cbdData;
        private readonly IZhuna_SchoolInfoDataProvider schoolData;

        public ZhunaHotelBusinessLogic()
        {
            this.zhunaCityData = kernel.Get<IZhuna_CityInfoDataProvider>();
            this.zhunaHotelChainData = kernel.Get<IZhuna_HotelChainDataProvider>();
            this.zhunaHotelData = kernel.Get<IZhuna_HotelInfoDataProvider>();
            this.cbdData = kernel.Get<IZhuna_CBDDataProvider>();
            this.schoolData = kernel.Get<IZhuna_SchoolInfoDataProvider>(); 
        }

        public List<Zhuna_CityInfo> ZhunaCityInfosGet()
        {

            var cityinfos = cacheProvider.GetCacheItem<List<Zhuna_CityInfo>>(CacheKeys.ZhunaCityInfoCache); 
            if(cityinfos==null||cityinfos.Count==0)
            {
                cityinfos = zhunaCityData.All();
                cacheProvider.InsertCacheItems(CacheKeys.ZhunaCityInfoCache,cityinfos);
            }
            
            return cityinfos;
        }

        public bool UpdateCityIdWithCtrip(Zhuna_CityInfo city)
        {
            return zhunaCityData.Update(city)>0;
        }

        public List<HotelLuceneIndexInfo> HotelsToLucene()
        {
            var hotels = zhunaHotelData.HotelInfoToLucene();
            return hotels;
        }

        public List<HotelLuceneIndexInfo> ZhunaHotelToLucene()
        {

            return null;
        }

        public List<Zhuna_HotelChain> ZhunaHotelChainsGet()
        {
            return zhunaHotelChainData.All();
        }

        public bool ZhunaHotelChainUpdate(Zhuna_HotelChain hotelChain)
        {
            return zhunaHotelChainData.Update(hotelChain)>0;
        }

        public List<TradeAreaInfo> HotCityTradeAreaGet()
        {
            var items = cacheProvider.GetCacheItem<List<TradeAreaInfo>>(CacheKeys.HotCityTradeAreaGetCache);
            if (items == null || items.Count==0)
            {
                items = cbdData.HotCityTradeAreaGet();
                cacheProvider.InsertCacheItems(CacheKeys.HotCityTradeAreaGetCache, items);
            }
            return items;
        }

        public Tuple<List<SchoolSummaryInfo>, List<SchoolCityInfo>> SchoolSummaryInfos()
        {
            var items = cacheProvider.GetCacheItem<Tuple<List<SchoolSummaryInfo>, List<SchoolCityInfo>>>(CacheKeys.SchoolSummaryInfoCache);
            if(items==null||items.Item1.Count==0)
            {
                items = schoolData.SchoolSummaryInfos();
                cacheProvider.InsertCacheItems(CacheKeys.SchoolSummaryInfoCache, items);
            }
            return items;
        }

        public Zhuna_CityInfo GetZhunaCityInfoByCtripCityId(int cityid)
        {
            var cityinfo = ZhunaCityInfosGet().SingleOrDefault(u => u.ctripcityid == cityid);
            return cityinfo;
        }
    }
}

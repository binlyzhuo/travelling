using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.TravelInterface.Data;
using Travelling.TravelInterface.Repository;
using Ninject;
using Travelling.Domain;
using Travelling.Caching;
using Travelling.TravelInterface.Data.Hotel;
using Travelling.ViewModel.Dto.Hotel;
using Travelling.Domain.Hotel;
using Travelling.ViewModel.Travel;
using Travelling.FrameWork;
using System.Collections.ObjectModel;

namespace Travelling.Repository
{
    /// <summary>
    /// 携程提供的相关城市信息
    /// </summary>
    public class HotelCityBusinessLogic : BaseLogic, IHotelCityBusinessLogic
    {
        
        private readonly IXC_HotelProvinceDataProvider provinceData;
        private readonly IXC_HotelLocationDataProvider locationData;
        private readonly IXC_HotelCountryDataProvider countrydata;
        private readonly IXC_HotelThemeDataProvider themeData;
        
        private readonly IXC_HotelCityDetailInfoDataProvider hotelCityDetailInfoData;
        private readonly IXC_HotelBrandDetailInfoDataProvider brandDetailInfoData;
        /// <summary>
        /// 构造函数
        /// </summary>
        public HotelCityBusinessLogic()
        {
            
            provinceData = kernel.Get<IXC_HotelProvinceDataProvider>();
            locationData = kernel.Get<IXC_HotelLocationDataProvider>();
            countrydata = kernel.Get<IXC_HotelCountryDataProvider>();
            themeData = kernel.Get<IXC_HotelThemeDataProvider>();
            
            hotelCityDetailInfoData = kernel.Get<IXC_HotelCityDetailInfoDataProvider>();
            brandDetailInfoData = kernel.Get<IXC_HotelBrandDetailInfoDataProvider>();
        }

        

        public void InsertProvinces(List<T_XC_HotelProvince> provinces)
        {
            provinceData.Truncate();
            provinceData.InsertBulk(provinces);
        }

        public void InsertLocations(List<T_XC_HotelLocation>locations)
        {
            locationData.Truncate();
            locationData.InsertBulk(locations);
        }

        public void InsertCountry(List<T_XC_HotelCountry> items)
        {
            countrydata.Truncate();
            countrydata.InsertBulk(items);
        }

        public void InsertThemes(List<T_XC_HotelTheme> themes)
        {
            themeData.Truncate();
            themeData.InsertBulk(themes);
        }

       
        public void InsertHotelCityDetailInfos(List<HotelCityDetailInfo> hotelCityDetailInfos)
        {
            var hotelCityInfosDomain = AutoMapper.Mapper.Map<List<HotelCityDetailInfo>, List<T_XC_HotelCityDetailInfo>>(hotelCityDetailInfos);
            hotelCityDetailInfoData.Truncate();
            hotelCityDetailInfoData.InsertBulk(hotelCityInfosDomain);
        }

        public List<HotelProvinceInfo> GetHotelProvinces()
        {
            var provincesDomain = provinceData.All();
            var provincesDto = AutoMapper.Mapper.Map<List<T_XC_HotelProvince>, List<HotelProvinceInfo>>(provincesDomain);
            return provincesDto;
        }

        public void InsertHotelBrandDetailInfos(List<HotelBrandDetailInfo> hotelBrandDetailsDto)
        {
            var hotelBrandDetailInfosDomain = AutoMapper.Mapper.Map<List<HotelBrandDetailInfo>, List<T_XC_HotelBrandDetailInfo>>(hotelBrandDetailsDto);
            brandDetailInfoData.Truncate();
            brandDetailInfoData.InsertBulk(hotelBrandDetailInfosDomain);
        }

        public List<HotelCityDetailInfo> HotelCityDetailInfosGet()
        {
            var hotelCityInfosDto = cacheProvider.GetCacheItem<List<HotelCityDetailInfo>>(CacheKeys.HoteCitylDetailInfos);
            if (hotelCityInfosDto == null)
            {
                hotelCityInfosDto = AutoMapper.Mapper.Map<List<T_XC_HotelCityDetailInfo>, List<HotelCityDetailInfo>>(hotelCityDetailInfoData.All());
                cacheProvider.InsertCacheItems(CacheKeys.HoteCitylDetailInfos, hotelCityInfosDto);
            }
            return hotelCityInfosDto;
        }

        public HotelCityDetailInfo HotelCityDetailInfoGetByCityID(int cityId)
        {
            return HotelCityDetailInfosGet().Where(u => u.CityID == cityId).SingleOrDefault();
        }

        public ReadOnlyCollection<HotelBrandDetailInfo> HotelBrandDetailInfoGetAll()
        {
            var brandDetailInfosDto = cacheProvider.GetCacheItem<List<HotelBrandDetailInfo>>(CacheKeys.HotelBrandDetailInfos);
            if (brandDetailInfosDto == null)
            {
                brandDetailInfosDto = AutoMapper.Mapper.Map<List<T_XC_HotelBrandDetailInfo>, List<HotelBrandDetailInfo>>(brandDetailInfoData.All());
                cacheProvider.InsertCacheItems(CacheKeys.HotelBrandDetailInfos, brandDetailInfosDto);
            }
            return brandDetailInfosDto.AsReadOnly();
        }

        public Tuple<List<HotelBrandDetailInfo>,List<HotelBrandDetailInfo>> HotelBrandSearchRecommends()
        {

            var brands = cacheProvider.GetCacheItem<Tuple<List<HotelBrandDetailInfo>, List<HotelBrandDetailInfo>>>(CacheKeys.HotelBrandSearchRecommends);
            if(brands==null)
            {
                var brandSearchRecommends = HotelBrandDetailInfoGetAll().Where(u => u.IsSearchRecommend == 1).OrderBy(u => u.OrderIndex).ToList();
                brandSearchRecommends = brandSearchRecommends.Count > 9 ? brandSearchRecommends.Range(9) : brandSearchRecommends;

                var brandLeft = HotelBrandDetailInfoGetAll().ToList();
                brandSearchRecommends.ForEach(u =>
                {
                    brandLeft.Remove(u);
                });

                brands = new Tuple<List<HotelBrandDetailInfo>, List<HotelBrandDetailInfo>>(brandSearchRecommends, brandLeft);
                cacheProvider.InsertCacheItems(CacheKeys.HotelBrandSearchRecommends, brands);
            }

            return brands;
        }

        public List<LocationInfo> HotelLocationGet()
        {
            List<LocationInfo> locations = cacheProvider.GetCacheItem<List<LocationInfo>>(CacheKeys.XC_HotelLocationInfos);
            if(locations==null)
            {
                locations = AutoMapper.Mapper.Map<List<T_XC_HotelLocation>, List<LocationInfo>>(locationData.All());
                cacheProvider.InsertCacheItems(CacheKeys.XC_HotelLocationInfos,locations);

            }
            return locations;
        }

        /// <summary>
        /// 根据城市ID获取行政区域信息
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        public List<LocationInfo> HotelLocationGetByCityId(int cityId)
        {
            return HotelLocationGet().Where(u => u.LocationCityID == cityId).ToList();
        }

        
    }
}

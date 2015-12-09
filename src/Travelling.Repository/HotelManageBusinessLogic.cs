using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Travelling.TravelInterface.Data.Hotel;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel;
using Travelling.ViewModel.Dto.Hotel;
using Travelling.ViewModel.Admin;
using Travelling.ViewModel.Travel;
using Travelling.TravelInterface.Data;
using Travelling.Domain;
using Travelling.Domain.Hotel;
using Travelling.OpenApiLogic;

namespace Travelling.Repository
{
    public class HotelManageBusinessLogic : BaseLogic,IHotelManageBusinessLogic
    {
        private readonly IXC_HotelCityDetailInfoDataProvider hotelCityInfoData;
        private readonly IXC_HotelProvinceDataProvider hotelProvincesData;
        private readonly IXC_HotelBrandDetailInfoDataProvider brandDetailInfoData;
        private readonly IHotelBookingOrderDataProvider bookOrderData;

        public HotelManageBusinessLogic()
        {
            hotelCityInfoData = kernel.Get<IXC_HotelCityDetailInfoDataProvider>();
            hotelProvincesData = kernel.Get<IXC_HotelProvinceDataProvider>();
            brandDetailInfoData = kernel.Get<IXC_HotelBrandDetailInfoDataProvider>();
            bookOrderData = kernel.Get<IHotelBookingOrderDataProvider>();
        }

        public PageObjectResult<HotelCityDetailInfo> HotelCityDetailSearch(HotelCityDetailSearchModel search)
        {
            var page = hotelCityInfoData.GetHotelCityDetailInfo(search);
            if (page.TotalItems == 0)
                return new PageObjectResult<HotelCityDetailInfo>();
            List<HotelCityDetailInfo> hotelCityInfoDto = AutoMapper.Mapper.Map<List<T_XC_HotelCityDetailInfo>, List<HotelCityDetailInfo>>(page.Items);
            PageObjectResult<HotelCityDetailInfo> pageObject = new PageObjectResult<HotelCityDetailInfo>()
            {
                Items = hotelCityInfoDto,
                Page = page.CurrentPage,
                PageSize = page.ItemsPerPage,
                TotalCount = page.TotalItems,
                TotalPages = page.TotalPages
            };
            return pageObject;
        }

        public List<HotelProvinceInfo> GetHotelProvinces()
        {
            var provinces = hotelProvincesData.All();
            var provincesDto = AutoMapper.Mapper.Map<List<T_XC_HotelProvince>, List<HotelProvinceInfo>>(provinces);
            return provincesDto;
        }

        public bool UpdateRecommendState(List<int> cityidList,int state)
        {
            return hotelCityInfoData.UpdateRecommendState(cityidList,state);
        }

        public HotelCityDetailInfo GetHotelCityInfo(int cityId)
        {
            var cityinfo = hotelCityInfoData.SingleOrDefault(cityId);
            var cityinfoDto = AutoMapper.Mapper.Map<T_XC_HotelCityDetailInfo, HotelCityDetailInfo>(cityinfo);
            return cityinfoDto;
        }

        public bool UpdateHotCityState(List<int> cityidList, int state)
        {
            return hotelCityInfoData.UpdateHotCityState(cityidList, state);
        }

        public bool UpdateSearchCityState(List<int> cityidList, int state)
        {
            return hotelCityInfoData.UpdateSearchCityState(cityidList, state);
        }

        public bool UpdateCityInfo(HotelCityDetailInfo cityInfo)
        {
            var cityDetailInfo = hotelCityInfoData.SingleOrDefault(cityInfo.CityID);
            cityDetailInfo.IsRecommendCity = cityInfo.IsRecommendCity;
            cityDetailInfo.RecommentIndex = cityInfo.RecommentIndex;
            cityDetailInfo.IsHotCity = cityInfo.IsHotCity;
            cityDetailInfo.HotCityIndex = cityInfo.HotCityIndex;
            cityDetailInfo.IsChoiceCity = cityInfo.IsChoiceCity;
            cityDetailInfo.ChoiceCityIndex = cityInfo.ChoiceCityIndex;
            cityDetailInfo.IsSearch = cityInfo.IsSearch;
            

            bool updateResult = hotelCityInfoData.Update(cityDetailInfo)>0;
            return updateResult;
        }

        public PageObjectResult<HotelBrandDetailInfo> HotelBrandInfosSearch(HotelBrandInfoSearchModel search)
        {
            var pageResult = brandDetailInfoData.GetHotelBrandInfos(search);
            if (pageResult.TotalItems == 0)
                return new PageObjectResult<HotelBrandDetailInfo>();
            List<HotelBrandDetailInfo> hotelBrandInfoDto = AutoMapper.Mapper.Map<List<T_XC_HotelBrandDetailInfo>, List<HotelBrandDetailInfo>>(pageResult.Items);
            var pageObject = new PageObjectResult<HotelBrandDetailInfo>()
            {
                Items = hotelBrandInfoDto,
                Page = pageResult.CurrentPage,
                PageSize = pageResult.ItemsPerPage,
                TotalCount = pageResult.TotalItems,
                TotalPages = pageResult.TotalPages
            };
            return pageObject;
        }

        public HotelBrandDetailInfo GetHotelBrandDetailInfo(int brandId)
        {
            var brandinfo = brandDetailInfoData.SingleOrDefault(brandId);
            var brandinfoDto = AutoMapper.Mapper.Map<T_XC_HotelBrandDetailInfo, HotelBrandDetailInfo>(brandinfo);
            return brandinfoDto;
        }

        public bool UpdateHotelBrandInfo(HotelBrandDetailInfo brandInfo)
        {
            var brandDetailInfo = brandDetailInfoData.SingleOrDefault(brandInfo.BrandID);
            brandDetailInfo.BrandImg = brandInfo.BrandImg??"";
            brandDetailInfo.BrandTel = brandInfo.BrandTel??"";
            brandDetailInfo.BrandType = brandInfo.BrandType;
            brandDetailInfo.Description = brandInfo.Description??"";
            brandDetailInfo.IsHotBrand = brandInfo.IsHotBrand;
            brandDetailInfo.OrderIndex = brandInfo.OrderIndex;
            brandDetailInfo.IsSearchRecommend = brandInfo.IsSearchRecommend;

            bool updateResult = brandDetailInfoData.Update(brandDetailInfo)>0;
            return updateResult;
        }

        public PageObjectResult<HotelBookingOrder> HotelBookingOrderGetPageResult(HotelOrderInfoSearchModel search)
        {
            var pageResult = bookOrderData.HotelBookingOrderGetPageResult(search);
            if (pageResult.TotalItems == 0)
                return new PageObjectResult<HotelBookingOrder>();
            var pageViewResult = new PageObjectResult<HotelBookingOrder>() {
                Items = AutoMapper.Mapper.Map<List<T_HotelBookingOrder>,List<HotelBookingOrder>>(pageResult.Items),
                Page = pageResult.CurrentPage,
                PageSize = pageResult.ItemsPerPage,
                TotalCount = pageResult.TotalItems,
                TotalPages = pageResult.TotalPages
            };
            return pageViewResult;
        }

        public bool HotelBookOrderCancel(string orderno)
        {
           bool apiRep = OTAHotelServiceLogic.OTA_CancelHotelBookOrder(orderno);
           return apiRep;
        }


    }
}

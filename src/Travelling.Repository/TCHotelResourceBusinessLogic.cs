using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.TravelInterface.Data.TC_Hotel;
using Ninject;
using Travelling.Domain.TC_Hotel;
using Travelling.TravelInterface.Repository;

namespace Travelling.Repository
{
    public class TCHotelResourceBusinessLogic : BaseTCHotelLogic, ITCHotelResourceBusinessLogic
    {
        private readonly ITC_HotelCityInfoDataProvider hotelCityData;
        private readonly ITC_HotelProvinceInfoDataProvider hotelProvinceData;
        private readonly ITC_HotelRegionInfoDataProvider hotelRegionData;
        private readonly ITC_HotelSectionInfoDataProvider hotelSectionData;
        private readonly ITC_HotelListDataProvider hotellistData;
        private readonly ITC_HotelBrandDataProvider hotelBrandData;
        public TCHotelResourceBusinessLogic()
        {
            hotelCityData = kernel.Get<ITC_HotelCityInfoDataProvider>();
            hotelProvinceData = kernel.Get<ITC_HotelProvinceInfoDataProvider>();
            hotelRegionData = kernel.Get<ITC_HotelRegionInfoDataProvider>();
            hotelSectionData = kernel.Get<ITC_HotelSectionInfoDataProvider>();
            hotellistData = kernel.Get<ITC_HotelListDataProvider>();
            hotelBrandData = kernel.Get<ITC_HotelBrandDataProvider>();
        }

        public void ImportTCHotelProvinceInfo(List<TC_HotelProvinceInfo> provinces,List<TC_HotelCityInfo> cityInfos,List<TC_HotelRegionInfo> regions,List<TC_HotelSectionInfo> sections)
        {
            hotelProvinceData.Truncate();
            hotelCityData.Truncate();
            hotelRegionData.Truncate();
            hotelSectionData.Truncate();
            hotelCityData.InsertBulk<TC_HotelProvinceInfo,TC_HotelCityInfo, TC_HotelRegionInfo, TC_HotelSectionInfo>(provinces, cityInfos, regions, sections);
        }

        public void ImportHotelList(List<TC_HotelList> hotelList)
        {
            hotellistData.Truncate();
            hotellistData.BulkInsertItems<TC_HotelList>(hotelList, typeof(TC_HotelList).Name);
        }

        public void ImportHotelBrands(List<TC_HotelBrand> brands)
        {
            hotelBrandData.Truncate();
            hotelBrandData.BulkInsertItems<TC_HotelBrand>(brands, typeof(TC_HotelBrand).Name);
        }
    }
}

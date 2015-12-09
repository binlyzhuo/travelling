using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.TC_Hotel;

namespace Travelling.TravelInterface.Repository
{
    public interface ITCHotelResourceBusinessLogic
    {
        void ImportTCHotelProvinceInfo(List<TC_HotelProvinceInfo> provinces, List<TC_HotelCityInfo> cityInfos, List<TC_HotelRegionInfo> regions, List<TC_HotelSectionInfo> sections);

        void ImportHotelList(List<TC_HotelList> hotelList);

        void ImportHotelBrands(List<TC_HotelBrand> brands);
    }
}

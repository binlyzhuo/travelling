using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.ViewModel.Dto.Hotel;

namespace Travelling.TravelInterface.Repository
{
    public interface IHotelBrandBusinessLogic
    {
        List<HotelBrandDto> HotelBrandsGet();

        HotelBrandDto HotelBrandsGet(int brandid);
    }
}

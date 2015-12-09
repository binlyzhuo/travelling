using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;
using Travelling.Domain.Hotel;
using Travelling.ViewModel.Admin;

namespace Travelling.TravelInterface.Data.Hotel
{
    public interface IXC_HotelBrandDetailInfoDataProvider : IDataProvider<T_XC_HotelBrandDetailInfo>
    {
        Page<T_XC_HotelBrandDetailInfo> GetHotelBrandInfos(HotelBrandInfoSearchModel searchModel);
    }
}

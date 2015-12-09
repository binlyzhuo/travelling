using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain;

namespace Travelling.TravelInterface.Data
{
    public interface IXC_HotelLocationDataProvider : IDataProvider<T_XC_HotelLocation>
    {
        List<T_XC_HotelLocation> GetLocationByCityID(int cityID);
    }
}

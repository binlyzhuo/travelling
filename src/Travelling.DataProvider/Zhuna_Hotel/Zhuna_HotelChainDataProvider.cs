using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Zhuna_Hotel;
using Travelling.TravelInterface.Data.Zhuna;

namespace Travelling.DataProvider.Zhuna_Hotel
{
    public class Zhuna_HotelChainDataProvider : BaseRecord<Zhuna_HotelChain>, IZhuna_HotelChainDataProvider
    {
        public Zhuna_HotelChainDataProvider()
        {
            this.defaultDatabase = OTA_TCHotelDatabase;
        }
    }
}

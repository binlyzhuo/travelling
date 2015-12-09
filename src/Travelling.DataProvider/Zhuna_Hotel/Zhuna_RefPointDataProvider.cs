using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Zhuna_Hotel;
using Travelling.TravelInterface.Data.Zhuna;

namespace Travelling.DataProvider.Zhuna_Hotel
{
    public class Zhuna_RefPointDataProvider : BaseRecord<Zhuna_RefPoint>, IZhuna_RefPointDataProvider
    {
        public Zhuna_RefPointDataProvider()
        {
            this.defaultDatabase = OTA_TCHotelDatabase;
        }
    }
}

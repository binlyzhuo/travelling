using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Zhuna_Hotel;

namespace Travelling.TravelInterface.Data.Zhuna
{
    public interface IZhuna_CityInfoDataProvider : IDataProvider<Zhuna_CityInfo>
    {
        Zhuna_CityInfo GetToSyncHotelInfo();

        int GetSyncStateCount(int syncState);

        bool InitSyncState();
    }
}

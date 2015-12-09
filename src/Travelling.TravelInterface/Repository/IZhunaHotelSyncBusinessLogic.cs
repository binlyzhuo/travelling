using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.Domain.Zhuna_Hotel;

namespace Travelling.TravelInterface.Repository
{
    public interface IZhunaHotelSyncBusinessLogic
    {
        void ImportZhunaCity(List<Zhuna_CityInfo> items);

        void ImportZhunaChains(List<Zhuna_HotelChain> items);

        void ImportHotelInfo(bool isDelete,Action<string> action);

        void ImportZhunaCityAreaInfo(Action<string> action);

        void ImportCityLables(bool isDelete, Action<string> action);

        void ImportSchoolInfos(bool isDelete, Action<string> action);

        void ImportHotelRefpoints(bool isDelete, Action<string> action);

        void ImportCityCBD(bool isDelete, Action<string> action);

        void ImportCityLableInfos(bool isDelete, Action<string> action);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.DataLayer;
using Travelling.Domain.Scenery;
using Travelling.ViewModel.Admin;

namespace Travelling.TravelInterface.Data.SceneryTicket
{
    public interface ISceneryProvinceDetailInfoDataProvider : IDataProvider<T_SceneryProvinceDetailInfo>
    {
        Page<T_SceneryProvinceDetailInfo> TicketProvinceInfoPageResult(TicketProvinceInfoSearchModel searchModel);

        T_SceneryProvinceDetailInfo GetCityRecordToSearchSync();

        int GetCityCountToSearchSync();

        int InitScenerySearchState();
    }
}

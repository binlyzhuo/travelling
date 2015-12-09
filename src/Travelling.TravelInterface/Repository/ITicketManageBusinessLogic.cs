using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.ViewModel;
using Travelling.ViewModel.Admin;
using Travelling.ViewModel.Dto.Ticket;

namespace Travelling.TravelInterface.Repository
{
    public interface ITicketManageBusinessLogic
    {
        PageObjectResult<SceneryProvinceDetailInfo> TicketProvinceInfoSearchResult(TicketProvinceInfoSearchModel searchModel);

        SceneryProvinceDetailInfo GetProvinceDetailInfo(int id);

        bool UpdateSceneryProvinceInfo(SceneryProvinceDetailInfo provinceInfoDto);

        List<SceneryProvinceDetailInfo> Provinces();

        PageObjectResult<SceneryTicketOrder> SceneryTicketOrderGetPageResult(SceneryTicketOrderSearchModel search);
    }
}

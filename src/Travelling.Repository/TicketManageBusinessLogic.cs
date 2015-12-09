using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.TravelInterface.Data.SceneryTicket;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel;
using Travelling.ViewModel.Admin;
using Travelling.ViewModel.Dto.Ticket;
using Ninject;
using Travelling.Domain.Scenery;

namespace Travelling.Repository
{
    public class TicketManageBusinessLogic : BaseTicketLogic, ITicketManageBusinessLogic
    {
        private readonly ISceneryProvinceDetailInfoDataProvider provinceInfoData;
        private readonly ISceneryTicketOrderDataProvider ticketOrderData;
        public TicketManageBusinessLogic()
        {
            provinceInfoData = kernel.Get<ISceneryProvinceDetailInfoDataProvider>();
            ticketOrderData = kernel.Get<ISceneryTicketOrderDataProvider>();
        }
        public PageObjectResult<SceneryProvinceDetailInfo> TicketProvinceInfoSearchResult(TicketProvinceInfoSearchModel searchModel)
        {
            var pageResult = provinceInfoData.TicketProvinceInfoPageResult(searchModel);
            if (pageResult.TotalItems == 0)
                return new PageObjectResult<SceneryProvinceDetailInfo>();

            var pageViewResult = new PageObjectResult<SceneryProvinceDetailInfo>()
            {
                Items = AutoMapper.Mapper.Map<List<T_SceneryProvinceDetailInfo>, List<SceneryProvinceDetailInfo>>(pageResult.Items),
                Page = pageResult.CurrentPage,
                PageSize = pageResult.ItemsPerPage,
                TotalCount = pageResult.TotalItems,
                TotalPages = pageResult.TotalPages
            };

            return pageViewResult;
        }

        public SceneryProvinceDetailInfo GetProvinceDetailInfo(int id)
        {
            var provinceinfoDomain = provinceInfoData.SingleOrDefault(id);
            var provinceinfoDto = AutoMapper.Mapper.Map<T_SceneryProvinceDetailInfo, SceneryProvinceDetailInfo>(provinceinfoDomain);
            return provinceinfoDto;
        }

        public bool UpdateSceneryProvinceInfo(SceneryProvinceDetailInfo provinceInfoDto)
        {
            var provinceinfoDomain = provinceInfoData.SingleOrDefault(provinceInfoDto.ID);
            provinceinfoDomain.IsRecommend = provinceInfoDto.IsRecommend;
            provinceinfoDomain.OrderNum = provinceInfoDto.OrderNum;

            return provinceInfoData.Update(provinceinfoDomain)>0;
        }

        public List<SceneryProvinceDetailInfo> Provinces()
        {
            var provinces = AllCityProvinces().Where(u => u.ParentID == 0).ToList();
            return provinces;
        }

        private List<SceneryProvinceDetailInfo> AllCityProvinces()
        {
            var allAreaInfosDomain = provinceInfoData.All();
            var allAreaInfosDto = AutoMapper.Mapper.Map<List<T_SceneryProvinceDetailInfo>, List<SceneryProvinceDetailInfo>>(allAreaInfosDomain);
            return allAreaInfosDto;
        }

        public PageObjectResult<SceneryTicketOrder> SceneryTicketOrderGetPageResult(SceneryTicketOrderSearchModel search)
        {
            var pageResult = ticketOrderData.SceneryTicketOrderGetPageResult(search);
            if (pageResult.TotalItems == 0)
                return new PageObjectResult<SceneryTicketOrder>();

            var pageViewResult = new PageObjectResult<SceneryTicketOrder>()
            {
                Items = AutoMapper.Mapper.Map<List<T_SceneryTicketOrder>, List<SceneryTicketOrder>>(pageResult.Items),
                Page = pageResult.CurrentPage,
                PageSize = pageResult.ItemsPerPage,
                TotalCount = pageResult.TotalItems,
                TotalPages = pageResult.TotalPages
            };

            return pageViewResult;
        }
    }
}

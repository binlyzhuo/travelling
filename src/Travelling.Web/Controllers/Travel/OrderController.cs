using System.Web.Mvc;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel.Hotel;
using Travelling.ViewModel.Ticket;
using Travelling.ViewModel.Travel;

namespace Travelling.Web.Controllers.Travel
{
    /// <summary>
    /// 订单
    /// </summary>
    public class OrderController : BaseController
    {
        private readonly IHotelManageBusinessLogic hotelManageBusinessLogic;
        private readonly IHotelInfoBusinessLogic hotelInfoBusinessLogic;
        private readonly ISceneryTicketInfoBusinessLogic ticketOrderBusinessLogic;
        private readonly string BaseViewPath = "~/Areas/Travel/Views/Order/{0}.cshtml";

        private string GetView(string viewName)
        {
            return string.Format(BaseViewPath, viewName);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public OrderController(IHotelManageBusinessLogic hotelBusiness, IHotelInfoBusinessLogic hotelinfoBusiness, ISceneryTicketInfoBusinessLogic ticketOrderBusiness)
        {
            this.hotelManageBusinessLogic = hotelBusiness;
            this.hotelInfoBusinessLogic = hotelinfoBusiness;
            this.ticketOrderBusinessLogic = ticketOrderBusiness;
        }

        [Authorize]
        [HttpGet]
        public ActionResult OrderSearch()
        {
            SetPageSEO("订单查询");
            return View(GetView("OrderSearch"));
        }

        [HttpPost]
        public ActionResult OrderSearchResult(OrderInfoSearchModel search)
        {
            if (search.OrderType == 0) // 酒店订单
            {
                HotelOrderResult hotelOrderResult = new HotelOrderResult();
                var hotelOrderInfo = hotelInfoBusinessLogic.GetHotelBookOrderBySerial(search.OrderNo);
                if (hotelOrderInfo != null)
                {
                    hotelOrderResult.Success = true;
                    hotelOrderResult.OrderInfo = hotelOrderInfo;
                }
                else
                {
                    hotelOrderResult.Success = false;
                    hotelOrderResult.Message = "没有相关订单信息";
                }

                return View(GetView("HotelOrderInfo"), hotelOrderResult);
            }
            if (search.OrderType == 1) // 景区门票
            {
                var ticketOrder = ticketOrderBusinessLogic.GetSceneryRicketOrderByOrderNo(search.OrderNo);
                SceneryTicketOrderSearchResult ticketOrderSearchResult = new SceneryTicketOrderSearchResult();
                if (ticketOrder != null)
                {
                    ticketOrderSearchResult.Success = true;
                    ticketOrderSearchResult.TicketOrder = ticketOrder;
                }
                else
                {
                    ticketOrderSearchResult.Success = false;
                    ticketOrderSearchResult.Message = "没有相关订单信息";
                }
            }
            return View(GetView("OrderSearch"));
        }
    }
}
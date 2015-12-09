using System.Web.Mvc;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel;
using Travelling.ViewModel.Admin;
using Travelling.ViewModel.Dto.Ticket;

namespace Travelling.Web.Controllers.Admin
{
    /// <summary>
    /// 门票信息管理
    /// </summary>
    public class TicketManageController : BaseAdminController
    {
        private readonly ITicketManageBusinessLogic ticketManageBusinessLogic;

        private readonly string BaseViewPath = "~/Areas/Admin/Views/Ticket/{0}.cshtml";

        private string GetView(string viewName)
        {
            return string.Format(BaseViewPath, viewName);
        }

        public TicketManageController(ITicketManageBusinessLogic ticketBusiness)
        {
            this.ticketManageBusinessLogic = ticketBusiness;
        }

        public ActionResult ThemeList()
        {
            return View();
        }

        public ActionResult ProvinceList(int pageIndex = 1)
        {
            string viewPath = string.Format(BaseViewPath, "ProvinceList");

            var provinces = ticketManageBusinessLogic.Provinces();
            ViewBag.Provinces = provinces;

            TicketProvinceInfoSearchModel searchModel = new TicketProvinceInfoSearchModel();
            searchModel.PageSize = 10;
            searchModel.PageIndex = pageIndex;
            var pageViewResult = ticketManageBusinessLogic.TicketProvinceInfoSearchResult(searchModel);
            return View(viewPath);
        }

        [HttpPost]
        public ActionResult ProvinceInfoSearchResult(TicketProvinceInfoSearchModel searchModel)
        {
            var pageViewResult = ticketManageBusinessLogic.TicketProvinceInfoSearchResult(searchModel);
            ViewBag.SearchAreaType = searchModel.AreaType;
            return View(string.Format(BaseViewPath, "ProvinceInfoSearchResult"), pageViewResult);
        }

        [HttpGet]
        public ActionResult ProvinceInfoEdit(int pid)
        {
            var provinceinfo = ticketManageBusinessLogic.GetProvinceDetailInfo(pid);
            return View(string.Format(BaseViewPath, "ProvinceInfoEdit"), provinceinfo);
        }

        [HttpPost]
        public JsonResult ProvinceInfoEdit(SceneryProvinceDetailInfo provinceinfo)
        {
            JsonViewResult jsonViewResult = new JsonViewResult() { Success = false };
            jsonViewResult.Success = ticketManageBusinessLogic.UpdateSceneryProvinceInfo(provinceinfo);
            return Json(jsonViewResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult OrderList()
        {
            return View(GetView("OrderList"));
        }

        [HttpPost]
        public ActionResult OrderSearchResult(SceneryTicketOrderSearchModel search)
        {
            var pageViewResult = ticketManageBusinessLogic.SceneryTicketOrderGetPageResult(search);
            return View(GetView("OrderSearchResult"), pageViewResult);
        }
    }
}
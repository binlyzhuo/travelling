using System.Web.Mvc;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel;
using Travelling.ViewModel.Admin;
using Travelling.ViewModel.Dto.HotelSyncRecord;
using Travelling.ViewModel.Setting;

namespace Travelling.Web.Controllers.Admin
{
    public class JobTaskController : BaseAdminController
    {
        private readonly string BaseViewPath = "~/Areas/Admin/Views/JobTask/{0}.cshtml";
        private readonly IJobScheduleBusinessLogic jobTaskBusinessLogic;

        public JobTaskController(IJobScheduleBusinessLogic jobBusiness)
        {
            jobTaskBusinessLogic = jobBusiness;
        }

        public ActionResult JobList(int pageIndex = 1)
        {
            return View();
        }

        [HttpPost]
        public ActionResult JobTaskSearchResult(JobTaskSearchModel search)
        {
            search.PageIndex = 1;
            var pageViewResult = jobTaskBusinessLogic.GetJobSchedulerSearchResult(search);
            return View("~/Areas/Admin/Views/JobTask/JobTaskSearchResult.cshtml", pageViewResult);
        }

        [HttpGet]
        public ActionResult JobTaskEdit(int jobid)
        {
            var jobDto = jobTaskBusinessLogic.GetJobTaskDetailByJobID(jobid);
            return View("~/Areas/Admin/Views/JobTask/JobTaskEdit.cshtml", jobDto);
        }

        public JsonResult JobTaskEdit(JobScheduler jobDto)
        {
            JsonViewResult jsonViewResult = new JsonViewResult() { Success = false };
            jsonViewResult.Success = jobTaskBusinessLogic.UpdateJobTask(jobDto);
            return Json(jsonViewResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult JobTaskAdd()
        {
            //JobScheduler
            return View();
        }

        [HttpPost]
        public JsonResult JobTaskAdd(JobScheduler jobInfo)
        {
            JsonViewResult jsonViewResult = new JsonViewResult() { Success = false };
            jsonViewResult.Success = jobTaskBusinessLogic.AddNewJobTask(jobInfo);
            return Json(jsonViewResult, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult JobTaskDelete(int id)
        {
            JsonViewResult jsonViewResult = new JsonViewResult() { Success = false };
            jsonViewResult.Success = jobTaskBusinessLogic.DeleteJobTask(id);
            return Json(jsonViewResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult HotelPriceSchedule()
        {
            return View(string.Format(BaseViewPath, "HotelPriceSchedule"));
        }

        [HttpGet]
        public ActionResult HotelPriceScheduleAdd()
        {
            return View(string.Format(BaseViewPath, "HotelPriceScheduleAdd"));
        }

        [HttpPost]
        public JsonResult HotelPriceScheduleAdd(HotelRoomRateJobScheduler jobSchedule)
        {
            JsonViewResult jsonViewResult = new JsonViewResult() { Success = false };
            jsonViewResult.Success = jobTaskBusinessLogic.HotelRoomPriceSyncJobAdd(jobSchedule);
            return Json(jsonViewResult, JsonRequestBehavior.AllowGet);
        }

        public ActionResult HotelPriceScheduleSearchResult(HotelRoomRateJobSearchModel search)
        {
            var pageViewResult = jobTaskBusinessLogic.GetHotelRoomRateJobSchedulerResult(search);
            return View(string.Format(BaseViewPath, "HotelPriceScheduleSearchResult"), pageViewResult);
        }

        [HttpGet]
        public ActionResult HotelPriceScheduleEdit(int jobid)
        {
            var jobDto = jobTaskBusinessLogic.GetHotelRoomRateJobScheduler(jobid);
            return View(string.Format(BaseViewPath, "HotelPriceScheduleEdit"), jobDto);
        }

        [HttpPost]
        public JsonResult HotelPriceScheduleEdit(HotelRoomRateJobScheduler jobSchedule)
        {
            JsonViewResult jsonViewResult = new JsonViewResult() { Success = false };
            jsonViewResult.Success = jobTaskBusinessLogic.HotelRoomPriceSyncJobUpdate(jobSchedule);
            return GetJsonResult(jsonViewResult);
        }

        [HttpPost]
        public JsonResult HotelRoomPriceJobDelete(int jobId)
        {
            JsonViewResult jsonViewResult = new JsonViewResult();
            jsonViewResult.Success = jobTaskBusinessLogic.HotelRoomPriceSyncJobDelete(jobId);
            return GetJsonResult(jsonViewResult);
        }
    }
}
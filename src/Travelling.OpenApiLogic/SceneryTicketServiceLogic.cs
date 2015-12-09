using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Travelling.OpenApiEntity.Scenery;
using Travelling.OpenApiEntity.Scenery.Module;
using Travelling.OpenApiSDK;

namespace Travelling.OpenApiLogic
{
    /// <summary>
    /// 景区门票相关业务处理
    /// </summary>
    public class SceneryTicketServiceLogic
    {
        static readonly SceneryTicketService ticketService;

        /// <summary>
        /// 构造函数
        /// </summary>
        static SceneryTicketServiceLogic()
        {
            ticketService = new SceneryTicketService();
        }

        /// <summary>
        /// 景区查询
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static GetSceneryListReturnEntity SceneryInfoSync(int cityId,int page,int pageSize)
        {
            var callEntity = new GetSceneryListCallEntity();
            callEntity.CityId = cityId;
            callEntity.Page = page;
            callEntity.PageSize = pageSize;
            var rep = ticketService.GetSceneryList(callEntity);
            return rep;
        }

        /// <summary>
        /// 获取景区详细信息
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <returns></returns>
        public static GetSceneryDetailReturnEntity GetSceneryDetail(int sceneryId)
        {
            var rep = ticketService.GetSceneryDetail(sceneryId);
            return rep;
        }

        /// <summary>
        /// 获取景区附近交通信息
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <returns></returns>
        public static GetSceneryTrafficInfoReturnEntity GetSceneryTrafficInfo(int sceneryId)
        {
            GetSceneryTrafficInfoCallEntity callEntity = new GetSceneryTrafficInfoCallEntity();
            callEntity.SceneryId = sceneryId;
            var rep = ticketService.GetSceneryTrafficInfo(callEntity);
            return rep;
        }

        /// <summary>
        /// 获取景区图片信息
        /// </summary>
        /// <param name="sceneryId">景区ID</param>
        /// <returns></returns>
        public static GetSceneryImageListReturnEntity GetSceneryImageList(int sceneryId)
        {
            GetSceneryImageListCallEntity callEntity = new GetSceneryImageListCallEntity(sceneryId, 1, 100);
            var rep = ticketService.GetSceneryImageList(callEntity);
            return rep;
        }

        /// <summary>
        /// 获取景区附近景点
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <returns></returns>
        public static List<int> GetNearbyScenery(int sceneryId)
        {
            GetNearbySceneryCallEntity callEntity = new GetNearbySceneryCallEntity(sceneryId,1,100);
            var rep = ticketService.GetNearbyScenery(callEntity);
            if(rep.SceneryList!=null&&rep.SceneryList.Count>0)
            {
                return rep.SceneryList.Select(u=>u.SceneryId).ToList();
            }
            return null;
        }

        /// <summary>
        /// 获取酒店门票价格策略
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <returns></returns>
        public static GetSceneryPriceReturnEntity GetSceneryPrice(int sceneryId)
        {
            List<int> sceneryIdList = new List<int>() { sceneryId };
            GetSceneryPriceCallEntity callEntity = new GetSceneryPriceCallEntity(sceneryIdList);
            var rep = ticketService.GetSceneryPrice(callEntity);
            return rep;
        }

        /// <summary>
        /// 获取用户点评信息
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <returns></returns>
        public static List<Comment> GetCommentList(int sceneryId)
        {
            GetCommentListCallEntity callEntity = new GetCommentListCallEntity() { SceneryId = sceneryId };
            var rep = ticketService.GetCommentList(callEntity);
            List<Comment> comments = rep.Comments;
            return comments;
        }

        public static void GetPriceCalendar(DateTime start,DateTime enddate,int policyId,bool isShoeDetail=true)
        {
            GetPriceCalendarCallEntity callEntity = new GetPriceCalendarCallEntity() {
                showDetail = isShoeDetail,
                endDate = enddate,
                startDate = start,
                policyId = policyId
            };
            ticketService.GetPriceCalendar(callEntity);
        }

        /// <summary>
        /// 景区门票下单
        /// </summary>
        /// <param name="sceneryId">景点ID</param>
        /// <param name="bookMan">预定人</param>
        /// <param name="bookTel">预定人手机</param>
        /// <param name="takeMan">取票人</param>
        /// <param name="takeTel">取票人联系电话</param>
        /// <param name="policyId">价格策略</param>
        /// <param name="ticketCount">门票张数</param>
        /// <param name="travelDate">旅游日期</param>
        /// <param name="ip"></param>
        public static SubmitSceneryOrderReturnEntity SubmitSceneryOrder(int sceneryId,string bookMan,string bookTel,string takeMan,string takeTel,int policyId,int ticketCount,DateTime travelDate,string ip="127.0.0.1")
        {
            SubmitSceneryOrderCallEntity callEntity = new SubmitSceneryOrderCallEntity()
            {
                SceneryId = sceneryId,
                Man = bookMan,
                Mobile = bookTel,
                OrderIP = ip,
                Tickets = ticketCount,
                PolicyId = policyId.ToString(),
                TravelDate = travelDate, tName = takeMan, 
                tMobile = takeTel
            };

            var rep = ticketService.SubmitSceneryOrder(callEntity);
            return rep;
        }

        /// <summary>
        /// 取消景区门票订单
        /// </summary>
        /// <param name="orderno"></param>
        /// <returns></returns>
        public static bool SceneryTicketOrderCancel(string orderno)
        {
            var callEntity = new CancelSceneryOrderCallEntity()
            {
                SerialId = orderno
            };

            var rep = ticketService.CancelSceneryOrder(callEntity);
            return rep.IsSuccess == "1" ? true : false;
        }
    }
}

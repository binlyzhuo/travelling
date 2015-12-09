using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Travelling.OpenApiEntity.Zhuna;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Travelling.OpenApiSDK
{
    public class ZhunaHotelOTAService
    {
        private static ZhunaHotelOTAService instance;
        public static ZhunaHotelOTAService Instance()
        {
            //if (instance == null)
            //{
            //    instance = new ZhunaHotelOTAService();
            //}
            //return instance;
            return new ZhunaHotelOTAService();
        }

        private readonly string agent_id;
        private readonly string agent_md;
        private readonly string baseUrl;

        private ZhunaHotelOTAService()
        {
            agent_id = ConfigurationManager.AppSettings["Zhuna_agent_id"];
            agent_md = ConfigurationManager.AppSettings["Zhuna_agent_md"];
            baseUrl = ConfigurationManager.AppSettings["Zhuna_apiurl"];
        }

        private string GetApiUrl(string method)
        {
            return string.Format("{0}?agent_id={1}&agent_md={2}&method={3}",baseUrl,agent_id,agent_md,method);
        }

        public ZhunaCityReturnEntity GetCity()
        {
            string method = "city";
            string repData=HttpCaller.PostDataToServer(GetApiUrl(method),"","GET");
            ZhunaCityReturnEntity returnEntity = JsonConvert.DeserializeObject<ZhunaCityReturnEntity>(repData);
            return returnEntity;
        }

        public ZhunaCBDReturnEntity GetCBD(string cityid)
        {
            string method = "cbd";
            string data = string.Format("cityid={0}",cityid);
            string repData = HttpCaller.PostDataToServer(string.Format("{0}&{1}", GetApiUrl(method), data), "", "GET");
            ZhunaCBDReturnEntity returnEntity = JsonConvert.DeserializeObject<ZhunaCBDReturnEntity>(repData);
            return returnEntity;
        }

        /// <summary>
        /// 获取城市地标
        /// </summary>
        /// <param name="cityid">城市ID</param>
        /// <param name="startIndex">起始索引</param>
        /// <param name="count">个数</param>
        /// <returns>地标信息实体</returns>
        public ZhunaLableInfoReturnEntity GetLable(string cityid,int startIndex=1,int count=10)
        {
            string method = "lable";
            string data = string.Format("cityid={0}&start={1}&rows={2}", cityid,startIndex,count);
            string repData = HttpCaller.PostDataToServer(string.Format("{0}&{1}", GetApiUrl(method), data), "", "GET");
            ZhunaLableInfoReturnEntity returnEntity = JsonConvert.DeserializeObject<ZhunaLableInfoReturnEntity>(repData);
            return returnEntity;
        }

        public ZhunaHotelChainReturnEntity GetHotelChain(string cityid="")
        {
            string method = "chain";
            string data = "";
            if(!string.IsNullOrEmpty(cityid))
            {
                 data = string.Format("&cityid={0}",cityid);
            }
            string repData = HttpCaller.PostDataToServer(string.Format("{0}{1}", GetApiUrl(method), data), "", "GET");
            ZhunaHotelChainReturnEntity returnEntity = JsonConvert.DeserializeObject<ZhunaHotelChainReturnEntity>(repData);
            return returnEntity;
        }

        /// <summary>
        /// 获取行政区域
        /// </summary>
        /// <param name="cityid"></param>
        /// <returns></returns>
        public ZhunaCityareaReturnEntity GetCityarea(string cityid)
        {
            try
            {
                string method = "cityarea";
                string data = string.Format("cityid={0}", cityid);
                string repData = HttpCaller.PostDataToServer(string.Format("{0}&{1}", GetApiUrl(method), data), "", "GET");
                ZhunaCityareaReturnEntity returnEntity = JsonConvert.DeserializeObject<ZhunaCityareaReturnEntity>(repData);
                return returnEntity;
            }
            catch(Exception ex)
            {
                ZhunaCityareaReturnEntity rep = new ZhunaCityareaReturnEntity();
                rep.retHeader = new ZhunaBaseReturnEntity.ReturnHeader();
                rep.retHeader.totalput = 0;
                return rep;
            }
        }

        public ZhunaLabletypeReturnEntity GetLableType()
        {
            string method = "lable.type";
            string data = "";
            string repData = HttpCaller.PostDataToServer(string.Format("{0}&{1}", GetApiUrl(method), data), "", "GET");
            ZhunaLabletypeReturnEntity returnEntity = JsonConvert.DeserializeObject<ZhunaLabletypeReturnEntity>(repData);
            return returnEntity;
        }

        public ZhunaCitychainReturnEntity GetCitychain(int lsid)
        {
            string method = "citychain";
            string data = string.Format("lsid={0}", lsid);
            string repData = HttpCaller.PostDataToServer(string.Format("{0}&{1}", GetApiUrl(method), data), "", "GET");
            ZhunaCitychainReturnEntity returnEntity = JsonConvert.DeserializeObject<ZhunaCitychainReturnEntity>(repData);
            return returnEntity;
        }

        /// <summary>
        /// 获取国内学校信息
        /// </summary>
        /// <param name="cityid"></param>
        /// <returns></returns>
        public ZhunaSchoolReturnEntity GetSchool(string cityid)
        {
            string method = "school";
            string data = string.Format("cityid={0}", cityid);
            string repData = HttpCaller.PostDataToServer(string.Format("{0}&{1}", GetApiUrl(method), data), "", "GET");
            ZhunaSchoolReturnEntity returnEntity = JsonConvert.DeserializeObject<ZhunaSchoolReturnEntity>(repData);
            return returnEntity;
        }

        public ZhunaSubwaylineReturnEntity GetSubwayline(string cityid)
        {
            string method = "subway.line";
            string data = string.Format("cityid={0}", cityid);
            string repData = HttpCaller.PostDataToServer(string.Format("{0}&{1}", GetApiUrl(method), data), "", "GET");
            ZhunaSubwaylineReturnEntity returnEntity = JsonConvert.DeserializeObject<ZhunaSubwaylineReturnEntity>(repData);
            return returnEntity;
        }

        public ZhunaSubwaylineReturnEntity GetLablesearchnearby(string cityid, string lng, string lat)
        {
            string method = "lable.search.nearby";
            string data = string.Format("cityid={0}&lng={1}&lat={2}", cityid,lng,lat);
            string repData = HttpCaller.PostDataToServer(string.Format("{0}&{1}", GetApiUrl(method), data), "", "GET");
            ZhunaSubwaylineReturnEntity returnEntity = JsonConvert.DeserializeObject<ZhunaSubwaylineReturnEntity>(repData);
            return returnEntity;
        }

        public ZhunaLablegetxyReturnEntity GetLablegetxy(int lableid)
        {
            string method = "lable.get.xy";
            string data = string.Format("lableid={0}", lableid);
            string repData = HttpCaller.PostDataToServer(string.Format("{0}&{1}", GetApiUrl(method), data), "", "GET");
            ZhunaLablegetxyReturnEntity returnEntity = JsonConvert.DeserializeObject<ZhunaLablegetxyReturnEntity>(repData);
            return returnEntity;
        }

        public ZhunaHotelSearchReturnEntity HotelSearch(ZhunaHotelSearchCallEntity search)
        {
            if(string.IsNullOrEmpty(search.cityid))
            {
                throw new ArgumentNullException("请填写住哪城市id");
            }
            string method = "search";
            //string cityid = "0101";
            StringBuilder data = new StringBuilder();
            data.AppendFormat("cid={0}&pg={1}&pagesize={2}",search.cityid,search.pg,search.pagesize);
            
            //string data = string.Format("cid={0}&lsid={1}",cityid,chain);
            string repData = HttpCaller.PostDataToServer(string.Format("{0}&{1}", GetApiUrl(method), data.ToString()), "", "GET");
            ZhunaHotelSearchReturnEntity returnEntity = JsonConvert.DeserializeObject<ZhunaHotelSearchReturnEntity>(repData);
            return returnEntity;
        }

        public ZhunaHotelPromotionReturnEntity HotelPromotionSearch(string cityid)
        {
            string method = "search";
            string data = string.Format("cityid={0}&promotion=1", cityid);
            string repData = HttpCaller.PostDataToServer(string.Format("{0}&{1}", GetApiUrl(method), data), "", "GET");
            ZhunaHotelPromotionReturnEntity returnEntity = JsonConvert.DeserializeObject<ZhunaHotelPromotionReturnEntity>(repData);
            return returnEntity;
        }

        public ZhunaHotelPriceReturnEntity HotelRoomPlanSearch(int hotelid, DateTime start, DateTime end)
        {
           
            string data = string.Format("hid={0}&tm1={1}&tm2={2}", hotelid,start.ToString("yyyy-MM-dd"),end.ToString("yyyy-MM-dd"));
            string baseUrl = "http://www.api.zhuna.cn/e/json.php";
            string repData = HttpCaller.PostDataToServer(string.Format("{0}?{1}", baseUrl, data), "", "GET");
            var returnEntity = JsonConvert.DeserializeObject<List<ZhunaHotelPriceReturnEntity>>(repData);
            returnEntity[0].hotelid = hotelid;
            //return returnEntity;
            return returnEntity[0];
        }

        /// <summary>
        /// 酒店查询结果
        /// </summary>
        /// <param name="hotelid"></param>
        /// <returns></returns>
        public ZhunaHotelInfoReturnEntity HotelInfoSearch(int hotelid)
        {
            string method = "hotel.info";
            string data = string.Format("hid={0}",hotelid);
            string repData = HttpCaller.PostDataToServer(string.Format("{0}&{1}", GetApiUrl(method), data), "", "GET");
            ZhunaHotelInfoReturnEntity returnEntity = JsonConvert.DeserializeObject<ZhunaHotelInfoReturnEntity>(repData);
            return returnEntity;
        }

        public ZhunaCommentlistReturnEntity GetCommentlist(string cityid)
        {
            string method = "comment.list";
            string data = string.Format("cityid={0}", cityid);
            string repData = HttpCaller.PostDataToServer(string.Format("{0}&{1}", GetApiUrl(method), data), "", "GET");
            ZhunaCommentlistReturnEntity returnEntity = JsonConvert.DeserializeObject<ZhunaCommentlistReturnEntity>(repData);
            return returnEntity;
        }

        /// <summary>
        /// 获取酒店点评信息
        /// </summary>
        /// <param name="hotelid"></param>
        /// <returns></returns>
        public ZhunaHotelCommentReturnEntity GetHotelComment(int hotelid)
        {
            string method = "hotel.comment";
            string data = string.Format("hid={0}", hotelid);
            string repData = HttpCaller.PostDataToServer(string.Format("{0}&{1}", GetApiUrl(method), data), "", "GET");
            
            ZhunaHotelCommentReturnEntity returnEntity = JsonConvert.DeserializeObject<ZhunaHotelCommentReturnEntity>(repData);
            return returnEntity;
        }

        public ZhunaQuestionlistReturnEntity GetQuestionlist(string cityid)
        {
            string method = "question.list";
            string data = string.Format("cityid={0}", cityid);
            string repData = HttpCaller.PostDataToServer(string.Format("{0}&{1}", GetApiUrl(method), data), "", "GET");
            var returnEntity = JsonConvert.DeserializeObject<ZhunaQuestionlistReturnEntity>(repData);
            return returnEntity;
        }

        public ZhunaHotelQuestionReturnEntity GetHotelQuestion(int hotelid)
        {
            string method = "hotel.question";
            string data = string.Format("hid={0}", hotelid);
            string repData = HttpCaller.PostDataToServer(string.Format("{0}&{1}", GetApiUrl(method), data), "", "GET");
            var returnEntity = JsonConvert.DeserializeObject<ZhunaHotelQuestionReturnEntity>(repData);
            return returnEntity;
        }

        public ZhunaHotelpicReturnEntity GetHotelPic(int hotelid)
        {
            try
            {
                string method = "hotel.pic";
                string data = string.Format("hid={0}", hotelid);
                string repData = HttpCaller.PostDataToServer(string.Format("{0}&{1}", GetApiUrl(method), data), "", "GET");
                var returnEntity = JsonConvert.DeserializeObject<ZhunaHotelpicReturnEntity>(repData);
                return returnEntity;
            }
            catch(Exception ex)
            {
                ZhunaHotelpicReturnEntity rep = new ZhunaHotelpicReturnEntity();
                rep.reqdata = null;
                return rep;
            }
        }

        public ZhunaHotelSearchNearByReturnEntity HotelSearchNearBy(string lng,string lat)
        {
            string method = "hotel.search.nearby";
            string data = string.Format("lng={0}&lat={1}",lng,lat);
            string repData = HttpCaller.PostDataToServer(string.Format("{0}&{1}", GetApiUrl(method), data), "", "GET");
            var returnEntity = JsonConvert.DeserializeObject<ZhunaHotelSearchNearByReturnEntity>(repData);
            return returnEntity;
        }
    }
}

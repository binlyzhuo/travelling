using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Travelling.Caching;
using Travelling.CommonLibrary;
using Travelling.FrameWork;
using Travelling.ViewModel.Dto.Hotel;
using Travelling.ViewModel.Dto.Ticket;
using Travelling.ViewModel.Travel;
using Travelling.Web.Filter;
using Travelling.Web.Helpers;

namespace Travelling.Web.Controllers
{
    /// <summary>
    /// 基类
    /// </summary>
    
    public class BaseController : Controller
    {
        /// <summary>
        /// 获取IP
        /// </summary>
        public string clientIP;

        private readonly string taobaoIPApiUrl = ConfigurationManager.AppSettings["TaoBaoIPApi"];
        private readonly string HotelQueryRouteUrl = "";
        private readonly string HotelOrderRouteUrl = "";
        private readonly string HotelInfoRouteUrl = "";

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseController()
        {
           // GetTopMenus();
        }

        

        

        /// <summary>
        /// 获取json对象
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected JsonResult GetJsonResult(dynamic obj)
        {
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 保存酒店浏览记录
        /// </summary>
        /// <param name="hotelId"></param>
        /// <param name="hotelName"></param>
        /// <param name="hotelIcon"></param>
        /// <param name="hotelStar"></param>
        protected void AddHotelToCookie(HotelCookieView hotelCookie)
        {
            System.Text.Encoding encode = System.Text.Encoding.GetEncoding("gb2312");
            HttpCookie cookie;
            Queue<HotelCookieView> hotelCookies;
            if (Request.Cookies["HotelViewed"] != null)
            {
                cookie = Request.Cookies["HotelViewed"];
                if (cookie["hotel"] != null)
                {
                    string cookesinfo = HttpUtility.UrlDecode(cookie["hotel"], encode);
                    hotelCookies = JsonConvert.DeserializeObject<Queue<HotelCookieView>>(cookesinfo);
                    var exists = hotelCookies.Where(u => { return u.HotelId == hotelCookie.HotelId; }).Count();
                    if (exists > 0)
                    {
                        return;
                    }
                }
                else
                {
                    hotelCookies = new Queue<HotelCookieView>();
                }
            }
            else
            {
                cookie = new HttpCookie("HotelViewed");
                hotelCookies = new Queue<HotelCookieView>();
            }

            if (hotelCookies.Count >= 10)
            {
                hotelCookies.Dequeue();
            }
            hotelCookies.Enqueue(hotelCookie);

            string cookieJson = JsonConvert.SerializeObject(hotelCookies);

            cookie["hotel"] = HttpUtility.UrlEncode(cookieJson, encode);
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 获取酒店浏览历史信息
        /// </summary>
        /// <returns></returns>
        protected Queue<HotelCookieView> GetHotelViewed()
        {
            System.Text.Encoding encode = System.Text.Encoding.GetEncoding("gb2312");
            Queue<HotelCookieView> hotelCookies;
            HttpCookie cookie;
            if (Request.Cookies["HotelViewed"] != null)
            {
                cookie = Request.Cookies["HotelViewed"];

                if (cookie["hotel"] != null)
                {
                    string cookiesInfo = HttpUtility.UrlDecode(cookie["hotel"], encode);
                    hotelCookies = JsonConvert.DeserializeObject<Queue<HotelCookieView>>(cookiesInfo);
                }
                else
                {
                    hotelCookies = new Queue<HotelCookieView>();
                }
            }
            else
            {
                hotelCookies = new Queue<HotelCookieView>();
            }
            return hotelCookies;
        }

        /// <summary>
        /// 保存景区浏览记录
        /// </summary>
        /// <param name="sceneryId"></param>
        /// <param name="amount"></param>
        /// <param name="listAmount"></param>
        /// <param name="sceneryName"></param>
        /// <param name="sceneryImg"></param>
        protected void AddSceneryToCookie(SceneryInfoDetail sceneryInfo)
        {
            HttpCookie cookie;
            System.Text.Encoding encode = System.Text.Encoding.GetEncoding("gb2312");
            Queue<SceneryInfoCookie> sceneryCookies;
            if (Request.Cookies["sceneryviewed"] != null)
            {
                cookie = Request.Cookies["sceneryviewed"];

                if (cookie["sceneryinfo"] != null)
                {
                    string cookiesInfo = HttpUtility.UrlDecode(cookie["sceneryinfo"], encode);
                    sceneryCookies = JsonConvert.DeserializeObject<Queue<SceneryInfoCookie>>(cookiesInfo);
                    var exists = sceneryCookies.Where(u => { return u.SceneryId == sceneryInfo.SceneryID; }).Count();
                    if (exists > 0)
                    {
                        return;
                    }
                }
                else
                {
                    sceneryCookies = new Queue<SceneryInfoCookie>();
                }
            }
            else
            {
                cookie = new HttpCookie("sceneryviewed");
                sceneryCookies = new Queue<SceneryInfoCookie>();
            }

            SceneryInfoCookie hotelCookie = new SceneryInfoCookie()
            {
                SceneryId = sceneryInfo.SceneryID,
                Amount = sceneryInfo.AmountAdvice,
                Img = sceneryInfo.ImgBaseUrl + sceneryInfo.Imgs,
                ListAmount = 0,
                SceneryName = sceneryInfo.SceneryName
            };
            if (sceneryCookies.Count >= 10)
            {
                sceneryCookies.Dequeue();
            }
            sceneryCookies.Enqueue(hotelCookie);

            string cookieJson = JsonConvert.SerializeObject(sceneryCookies);

            cookie["sceneryinfo"] = HttpUtility.UrlEncode(cookieJson, encode);
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 获取景区浏览记录
        /// </summary>
        /// <returns></returns>
        protected Queue<SceneryInfoCookie> GetSceneryViewed()
        {
            Queue<SceneryInfoCookie> sceneryCookies;
            HttpCookie cookie;
            if (Request.Cookies["sceneryviewed"] != null)
            {
                cookie = Request.Cookies["sceneryviewed"];
                if (cookie["sceneryinfo"] != null)
                {
                    System.Text.Encoding encode = System.Text.Encoding.GetEncoding("gb2312");
                    string sceneryCookiesInfo = HttpUtility.UrlDecode(cookie["sceneryinfo"], encode);

                    sceneryCookies = JsonConvert.DeserializeObject<Queue<SceneryInfoCookie>>(sceneryCookiesInfo);
                }
                else
                {
                    sceneryCookies = new Queue<SceneryInfoCookie>();
                }
            }
            else
            {
                sceneryCookies = new Queue<SceneryInfoCookie>();
            }
            return sceneryCookies;
        }

        /// <summary>
        /// 设置页面Title
        /// </summary>
        /// <param name="title"></param>
        protected void SetPageSEO(string title,string keywords="",string descriptions="")
        {
            ViewBag.Title = title;
            ViewBag.SeoKeywords = keywords;
            ViewBag.SeoDescription = descriptions;
        }

        protected void AddVisitLocationInfoToCookie(LocalCityCookie citycookie)
        {
            System.Text.Encoding encode = System.Text.Encoding.GetEncoding("gb2312");
            HttpCookie cookie;
            if(Request.Cookies["localcookie"]!=null)
            {
                cookie = Request.Cookies["localcookie"];
            }
            else
            {
                cookie = new HttpCookie("localcookie");
                cookie["localcitycookie"] = JsonConvert.SerializeObject(citycookie);
                cookie.Expires = DateTime.Now.AddDays(10);
                Response.Cookies.Add(cookie);
            }
        }

        protected LocalCityCookie GetLocalCityInfoFromCookie()
        {
            HttpCookie cookie;
            LocalCityCookie citycookie;
            if (Request.Cookies["localcookie"]!=null)
            {
                cookie = Request.Cookies["localcookie"];
                System.Text.Encoding encode = System.Text.Encoding.GetEncoding("gb2312");
                string localcitycookie = HttpUtility.UrlDecode(cookie["localcitycookie"], encode);
                citycookie = JsonConvert.DeserializeObject<LocalCityCookie>(localcitycookie);
                return citycookie;
            }
            return null;
        }
    }
}
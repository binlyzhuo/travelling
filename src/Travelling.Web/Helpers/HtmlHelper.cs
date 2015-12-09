using Microsoft.Security.Application;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Travelling.FrameWork;
using System.Text;

namespace Travelling.Web.Helpers
{
    /// <summary>
    /// Html扩展
    /// </summary>
    public static class MyHtmlHelper
    {
        /// <summary>
        /// 清除html
        /// </summary>
        /// <param name="Htmlstring"></param>
        /// <returns></returns>
        public static string RemoveHtmlTags(this string Htmlstring)
        {
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public static Tuple<int, int> GetPaging(int page, int pageSize, int totalRecords)
        {
            int totalPages = totalRecords % pageSize == 0 ? totalRecords / pageSize : totalRecords / pageSize + 1;

            int startIndex = page > 3 ? page - 3 : 1;
            int endIndex = page + pageSize > totalPages ? totalPages : (startIndex <= 3 ? pageSize : pageSize + page - 4);//pageSize + page-3;
            //if(startIndex==1)
            //{
            //    endIndex = 10;
            //}

            return Tuple.Create<int, int>(startIndex, endIndex);
        }

        /// <summary>
        /// 获取安全input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetSafeHtmlInput(this string input)
        {
            return Sanitizer.GetSafeHtmlFragment(input);
        }

        public static IEnumerable<SelectListItem> CreateHotelPriceSelectList(this HtmlHelper htmlHelper, Type enumType, string selectedItem)
        {

            return (from int val in Enum.GetValues(enumType)
                    let field = enumType.GetField(Enum.GetName(enumType, val))
                    let descatt = field.GetCustomAttributes(typeof(DescriptionAttribute), false).SingleOrDefault()
                    let desc = ((DescriptionAttribute)descatt).Description
                    let numatt = (NumberRangeAttribute)field.GetCustomAttributes(typeof(NumberRangeAttribute), false).SingleOrDefault()

                    select new SelectListItem
                    {

                        Value = numatt.Min + "-" + numatt.Max,
                        Text = desc,
                        Selected = val.ToString() == selectedItem

                    }).ToList();
        }

        public static IEnumerable<SelectListItem> CreateHotelLevelSelectList(this HtmlHelper htmlHelper, Type enumType, string selectedItem)
        {

            return (from int val in Enum.GetValues(enumType)
                    let field = enumType.GetField(Enum.GetName(enumType, val))
                    let descatt = field.GetCustomAttributes(typeof(DescriptionAttribute), false).SingleOrDefault()
                    let desc = ((DescriptionAttribute)descatt).Description
                    let numatt = (NumberRangeAttribute)field.GetCustomAttributes(typeof(NumberRangeAttribute), false).SingleOrDefault()

                    select new SelectListItem
                    {
                        Value = numatt.Min + "-" + numatt.Max,
                        Text = desc,
                        Selected = val.ToString() == selectedItem

                    }).ToList();

        }

        public static MvcHtmlString ToPageList(this HtmlHelper htmlhelper,int pageNumber,int pageSize,int totalItems,string queryfun)
        {

            StringBuilder pageString = new StringBuilder();
            int totalPages = totalItems % pageSize == 0 ? totalItems / pageSize : totalItems / pageSize + 1;
            int displayNum = 10;
            bool prev = true;
            bool next = true;
            if(pageNumber==1)
            {
                prev = false;
            }
            if(pageNumber==totalPages)
            {

                next = false;

            }

            int startIndex = (pageNumber-3) > 0 ? pageNumber-3 : pageNumber;
            int endIndex = (startIndex + displayNum) > totalPages ? totalPages : startIndex + displayNum;

            pageString.AppendFormat("<ul class=\"pagination\">");
            pageString.Append("<li class=\"prev\">");

            if(prev)
            {
                pageString.AppendFormat("<a href=\"#\" onclick=\"javascript:{0}({1});\">", queryfun, pageNumber-1);
            }
            else
            {
                pageString.Append("<a href=\"#\">");
            }

            pageString.Append("<i class=\"icondoubleangleleft\"></i></a>");

            //pageString.AppendFormat("<a href=\"{0}\"><i class=\"icondoubleangleleft\"></i></a>", prev?(pageNumber1).ToString():"#");

            pageString.Append("</li>");

           

            for (int index = startIndex; index <= endIndex;index++)
            {
                pageString.AppendFormat("<li class=\"{2}\"><a href=\"#\" onclick=\"javascript:{1}({0});\">{0}</a></li>", index, queryfun, pageNumber == index ? "active" : "");
            }

            //<i class=\"icondoubleangleright\"></i></a>",next?(pageNumber+1).ToString():"#");

            pageString.AppendFormat("<li class=\"next{0}\">", next ? "" : " disabled");

            if(next)
            {
                pageString.AppendFormat("<a href=\"#\" onclick=\"{0}(1)\">", queryfun, pageNumber + 1);
            }
            else
            {
                pageString.Append("<a href=\"#\">");
            }

            pageString.Append("<i class=\"icondoubleangleright\"></i></a>");
            pageString.Append("</li>");
            pageString.AppendFormat("</ul>");
            return new MvcHtmlString(pageString.ToString());

        }

        public static IEnumerable<SelectListItem> CreateSelectList(this HtmlHelper htmlHelper, Type enumType, string selectedItem)
        {

            return (from int val in Enum.GetValues(enumType)
                    let field = enumType.GetField(Enum.GetName(enumType, val))
                    let att = field.GetCustomAttributes(typeof(DescriptionAttribute), false).SingleOrDefault()
                    let desc = ((DescriptionAttribute)att).Description
                    select new SelectListItem
                    {

                        Value = val.ToString(),
                        Text = desc,
                        Selected = val.ToString() == selectedItem

                    }).ToList();

        }


    }
}
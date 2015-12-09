using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web;
using System.Web.Mvc;
using Travelling.FrameWork;
using Travelling.ViewModel.Travel.XmlData;
using Travelling.ViewModel.Travel;

namespace Travelling.Web.XmlData
{
    /// <summary>
    /// xml数据源
    /// </summary>
    public class XmlDataSource
    {
        private static XmlDocument xmlDoc;
        private static XmlDocument schoolsXmlDoc;
        private static XmlDocument hotelBrandXmlDoc;

        /// <summary>
        /// 构造函数
        /// </summary>
        static XmlDataSource()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(HttpContext.Current.Server.MapPath("/App_Data/hotelcitydata.xml"));

            schoolsXmlDoc = new XmlDocument();
            schoolsXmlDoc.Load(HttpContext.Current.Server.MapPath("/App_Data/schools.xml"));

            hotelBrandXmlDoc = new XmlDocument();
            hotelBrandXmlDoc.Load(HttpContext.Current.Server.MapPath("/App_Data/citybrands.xml"));
        }

        /// <summary>
        /// 获取团购城市信息
        /// </summary>
        /// <returns></returns>
        public static List<GroupCityInfo> HotelGroupCityInfosGet()
        {
            var groupCityNodes = xmlDoc.SelectNodes("citylist/group/city");
            List<GroupCityInfo> cityList = new List<GroupCityInfo>();
            GroupCityInfo cityInfo;
            foreach(XmlNode n in groupCityNodes)
            {
                cityInfo = new GroupCityInfo();
                cityInfo.CityId = n.ToXmlElement().GetAttribute("id").ToInt32();
                cityInfo.CityName = n.InnerText.Trim();
                cityInfo.Order = n.ToXmlElement().GetAttribute("order").ToInt32();
                cityList.Add(cityInfo);
            }
            return cityList;
            
        }

        /// <summary>
        /// 获取古镇城市信息
        /// </summary>
        /// <returns></returns>
        public static List<GuZhenCityInfo> GuZhenHotelCityInfoGet()
        {
            var cityNodes = xmlDoc.SelectNodes("citylist/kezhan/city");
            List<GuZhenCityInfo> guzhenCityinfos = new List<GuZhenCityInfo>();
            GuZhenCityInfo cityInfo;
            foreach (XmlNode n in cityNodes)
            {
                cityInfo = new GuZhenCityInfo();
                cityInfo.CityId = n.ToXmlElement().GetAttribute("id").ToInt32();
                cityInfo.KeyWords = n.ToXmlElement().GetAttribute("keywords");
                cityInfo.Order = n.ToXmlElement().GetAttribute("order").ToInt32();
                cityInfo.SectionId = n.ToXmlElement().GetAttribute("sectionid").ToInt32();
                cityInfo.CityName = n.InnerText.Trim();
                cityInfo.Pinyin = n.ToXmlElement().GetAttribute("pinyin");
                guzhenCityinfos.Add(cityInfo);
            }
            return guzhenCityinfos;
        }

        /// <summary>
        /// 获取学校信息
        /// </summary>
        /// <returns></returns>
        public static List<SchoolInfo> SchoolsGet()
        {
            var schoolNodes = schoolsXmlDoc.SelectNodes("schools/school");
            List<SchoolInfo> schools = new List<SchoolInfo>();
            SchoolInfo school;
            foreach(XmlNode n in schoolNodes)
            {
                school = new SchoolInfo() {
                    CityId = n.SelectSingleNode("cityid").InnerText.ToInt32(),
                    CityName = n.SelectSingleNode("cityname").InnerText,
                    ProvinceId = n.SelectSingleNode("provinceid").InnerText.ToInt32(),
                    ProvinceName = n.SelectSingleNode("provincename").InnerText,
                    SchoolName = n.SelectSingleNode("name").InnerText
                };
                schools.Add(school);
            }
            return schools;
        }

        public static List<BrandCityInfo> HotBrandsGet()
        {
            List<BrandCityInfo> hotelbrands = new List<BrandCityInfo>();
            BrandCityInfo brand;
            List<CityInfo> cityinfos;
            CityInfo cityinfo;
            var brands = hotelBrandXmlDoc.SelectNodes("brands/brand");
            foreach(XmlNode b in brands)
            {
                brand = new BrandCityInfo();
                brand.BrandId = b.ToXmlElement().GetAttribute("id").ToInt32();
                brand.BrandName = b.ToXmlElement().GetAttribute("name").Trim();

                cityinfos = new List<CityInfo>();
                var citynodelist = b.SelectNodes("city");
                foreach(XmlNode n in citynodelist)
                {
                    cityinfo = new CityInfo();
                    cityinfo.CityId = n.ToXmlElement().GetAttribute("id").ToInt32();
                    cityinfo.CityName = n.InnerText.Trim();
                    cityinfos.Add(cityinfo);
                }
                brand.Cities = cityinfos;
                hotelbrands.Add(brand);
            }
            return hotelbrands;
        }
    }
}

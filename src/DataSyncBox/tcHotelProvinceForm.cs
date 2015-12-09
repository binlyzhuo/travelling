using DataSyncBox.Core;
using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Travelling.Domain.TC_Hotel;
using Travelling.OpenApiLogic;
using Travelling.TravelInterface.Repository;
using System.Xml;
using Travelling.FrameWork;

namespace DataSyncBox
{
    public partial class tcHotelProvinceForm : BaseAdminForm
    {
        protected readonly StandardKernel kernel;
        private readonly ITCHotelResourceBusinessLogic tcHotelResourceLogic;
        public tcHotelProvinceForm()
        {
            InitializeComponent();
            kernel = new StandardKernel(new TCHotelResourceNInject());
            tcHotelResourceLogic = kernel.Get<ITCHotelResourceBusinessLogic>();
        }

        private void btnImportProvince_Click(object sender, EventArgs e)
        {
            //OTATCHotelServiceLogic.GetProvinceList();
            var apiprovinces = OTATCHotelServiceLogic.GetProvinceList().Provinces;
            List<TC_HotelProvinceInfo> provinces = new List<TC_HotelProvinceInfo>();
            List<TC_HotelCityInfo> cityinfos = new List<TC_HotelCityInfo>();
            List<TC_HotelRegionInfo> regions = new List<TC_HotelRegionInfo>();
            List<TC_HotelSectionInfo> sections = new List<TC_HotelSectionInfo>();
            TC_HotelProvinceInfo province;
            TC_HotelCityInfo cityinfo;
            TC_HotelRegionInfo region;
            TC_HotelSectionInfo section;
            foreach (var p in apiprovinces)
            {
                province = new TC_HotelProvinceInfo();
                province.ID = p.ID;
                province.Name = p.Name;
                province.Pinyin = p.Pinyin;
                province.Index = p.Index;
                provinces.Add(province);

                foreach(var city in p.CityList)
                {
                    cityinfo = new TC_HotelCityInfo();
                    cityinfo.ID = city.ID;
                    cityinfo.Name = city.Name;
                    cityinfo.Pinyin = city.Pinyin;
                    cityinfo.Index = city.Index;
                    cityinfo.ProvinceId = p.ID;
                    cityinfos.Add(cityinfo);

                    foreach(var r in city.Regions)
                    {
                        region = new TC_HotelRegionInfo();
                        region.CityId = city.ID;
                        region.RegionID = r.ID;
                        region.Name = r.Name;
                        region.Pinyin = r.Pinyin;
                        region.ProvinceId = p.ID;
                        regions.Add(region);
                    }

                    foreach(var s in city.Sections)
                    {
                        section = new TC_HotelSectionInfo();
                        section.CityId = city.ID;
                        section.SectionID = s.ID;
                        section.Name = s.Name;
                        section.ProvinceId = p.ID;
                        sections.Add(section);
                    }
                }
            }

            // 保存

            tcHotelResourceLogic.ImportTCHotelProvinceInfo(provinces,cityinfos,regions,sections);
            lblMsg.Text = "导入成功";

        }

        private void btnImportHotelList_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "开始执行操作";
            string xmlPath = "data/tc/hotellist.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            List<TC_HotelList> hotellist = new List<TC_HotelList>();
            TC_HotelList hotelinfo;
            var hotelNodes = xmlDoc.SelectNodes("hotelList/hotel");
            foreach(XmlNode h in hotelNodes)
            {
                hotelinfo = new TC_HotelList();
                hotelinfo.AddDate = h.GetChildNodeInnerText("addDate").ToDateTime();
                hotelinfo.Flag = h.GetChildNodeInnerText("flag").ToInt32();
                hotelinfo.HotelID = h.GetChildNodeInnerText("hotelId").ToInt32();
                hotelinfo.HotelName = h.GetChildNodeInnerText("hotelName");
                hotelinfo.ModifyDate = string.IsNullOrEmpty(h.GetChildNodeInnerText("modifyDate")) ? DateTime.Parse("1900-1-1") : h.GetChildNodeInnerText("modifyDate").ToDateTime();
                hotellist.Add(hotelinfo);
            }

            tcHotelResourceLogic.ImportHotelList(hotellist);
            lblMsg.Text = "导入成功";
        }

        private void btnImportHotelBrand_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "开始执行操作";
            string xmlPath = "data/tc/hotel-brands.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlPath);
            List<TC_HotelBrand> brands = new List<TC_HotelBrand>();
            TC_HotelBrand brand;
            var brandNodes = xmlDoc.SelectNodes("brandList/brand");
            foreach(XmlNode bn in brandNodes)
            {
                brand = new TC_HotelBrand();
                brand.AddDate = DateTime.Now;
                brand.ID = bn.GetChildNodeInnerText("id").ToInt32();
                brand.Logo = bn.GetChildNodeInnerText("logo");
                brand.Name = bn.GetChildNodeInnerText("name");
                brand.SName = bn.GetChildNodeInnerText("sname");

                brands.Add(brand);
            }

            tcHotelResourceLogic.ImportHotelBrands(brands);
            lblMsg.Text = "导入成功";
        }
    }
}

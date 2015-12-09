using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using Travelling.Domain;
using Travelling.FrameWork;
using Ninject;
using Travelling.TravelInterface.Repository;
using DataSyncBox.Core;
using Travelling.ViewModel;
using Travelling.ViewModel.Dto.Hotel;
using Travelling.Domain.Hotel;

namespace DataSyncBox
{
    public partial class CtripProvinceForm : BaseAdminForm
    {
        delegate void dShowForm();
        protected readonly StandardKernel kernel;

        private readonly IHotelCityBusinessLogic cityBusiness;

        public CtripProvinceForm()
        {

            InitializeComponent();
            kernel = new StandardKernel(new DependencyResolver());
            cityBusiness = kernel.Get<IHotelCityBusinessLogic>();
            logBusiness = kernel.Get<ISystemLogBusinessLogic>();
        }

        /// <summary>
        /// 初始化携程酒店城市以及省份信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            btnSyncProvince.Enabled = false;
            btnHotelBrand.Enabled = false;
            RunImportDate();

            lblCityMsg.ForeColor = Color.Blue;
            lblCityMsg.Text = "同步完成";
            btnSyncProvince.Enabled = true;
            btnHotelBrand.Enabled = true;

        }

        public delegate void dSetProgress(int total, int current);

        public void SetProgress(int total, int current)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new dSetProgress(this.SetProgress),
                        new object[] { total, current });
                }
                catch { }
            }
            else
            {
                //this.progressBar1.Maximum = total;
                //this.progressBar1.Value = current;

                ////YQ Test
                ////达到最大值后退出
                //if (this.progressBar1.Value == this.progressBar1.Maximum)
                //{
                //    //this.DialogResult = DialogResult.Cancel;
                //}
            }
        }

        /// <summary>
        /// 同步进度条
        /// </summary>
        void SetProgress()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (this.DialogResult == System.Windows.Forms.DialogResult.Cancel)
                {
                    break;
                }
                else
                {
                    this.SetProgress(100, i);
                    System.Threading.Thread.Sleep(130);
                }
            }

        }

        /// <summary>
        /// 同步省分数据
        /// </summary>
        void InitCtripProvinces()
        {

            string path = "data/chinaprovinces.xml";
            List<T_XC_HotelProvince> provinceList = new List<T_XC_HotelProvince>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            var provinceNodes = xmlDoc.SelectNodes("ProvinceDetails/ProvinceDetail");
            foreach (XmlElement el in provinceNodes)
            {
                provinceList.Add(new T_XC_HotelProvince()
                {
                    CountryID = el.SelectSingleNode("Country").InnerText.ToInt32(),
                    ProvinceEName = el.SelectSingleNode("ProvinceEName").InnerText.Trim(),
                    ProvinceID = el.SelectSingleNode("Province").InnerText.ToInt32(),
                    ProvinceName = el.SelectSingleNode("ProvinceName").InnerText.Trim()
                });
            }
            var items = provinceList;

            cityBusiness.InsertProvinces(provinceList);

        }

        /// <summary>
        /// 同步国家数据
        /// </summary>
        void InitCtripCountry()
        {

            string path = "data/countrydata.xml";
            List<T_XC_HotelCountry> items = new List<T_XC_HotelCountry>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            var countryNodes = xmlDoc.SelectNodes("SearchCountryResponse/CountryDetails/CountryDetail");
            foreach (XmlElement el in countryNodes)
            {
                items.Add(new T_XC_HotelCountry()
                {
                    CountryEName = el.SelectSingleNode("CountryEName").InnerText.Trim(),
                    CountryName = el.SelectSingleNode("CountryName").InnerText.Trim(),
                    CountryID = el.SelectSingleNode("Country").InnerText.Trim().ToInt32()
                });
            }

            cityBusiness.InsertCountry(items);
        }

        /// <summary>
        /// 同步城市数据
        /// </summary>
        void InitCtripCityData()
        {

            string path = "data/chinacity.xml";
            List<HotelCityDetailInfo> items = new List<HotelCityDetailInfo>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            var provinces = cityBusiness.GetHotelProvinces();
            var nodes = xmlDoc.SelectNodes("CityDetails/CityDetail");
            foreach (XmlElement el in nodes)
            {
                string provinceName = "";
                var province = provinces.SingleOrDefault(u2 => u2.ProvinceID == el.SelectSingleNode("Province").InnerText.Trim().ToInt32());
                if (province != null)
                {
                    provinceName = province.ProvinceName;
                }
                items.Add(new HotelCityDetailInfo()
                {

                    CityCode = el.SelectSingleNode("CityCode").InnerText.Trim(),
                    CityEName = el.SelectSingleNode("CityEName").InnerText.Trim(),

                    CityName = el.SelectSingleNode("CityName").InnerText.Trim(),

                    ProvinceID = el.SelectSingleNode("Province").InnerText.Trim().ToInt32(),
                    ChoiceCityIndex = 0,
                    CityID = el.SelectSingleNode("City").InnerText.Trim().ToInt32(),
                    HotCityIndex = 0,
                    HotelCount = 0,
                    IsChoiceCity = 0,
                    IsHotCity = 0,
                    IsRecommendCity = 0,
                    IsSearch = 0,
                    LastSyncHotelInfoDate = DateTime.Parse("1900-1-1"),
                    ProvinceName = provinceName,
                    RecommentIndex = 0
                });
            }

            cityBusiness.InsertHotelCityDetailInfos(items);
        }

        /// <summary>
        /// 同步行政区域
        /// </summary>
        public void ImportLocationData()
        {

            string path = "data/chinalocation.xml";
            List<T_XC_HotelLocation> items = new List<T_XC_HotelLocation>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            var locationNodes = xmlDoc.SelectNodes("LocationDetails/LocationDetail");
            foreach (XmlElement el in locationNodes)
            {
                items.Add(new T_XC_HotelLocation()
                {
                    LocationCityID = el.SelectSingleNode("LocationCity").InnerText.ToInt32(),
                    LocationEName = el.SelectSingleNode("LocationEName").InnerText.Trim(),
                    LocationID = el.SelectSingleNode("Location").InnerText.ToInt32(),
                    LocationName = el.SelectSingleNode("LocationName").InnerText.Trim()
                });
            }

            cityBusiness.InsertLocations(items);
        }

        /// <summary>
        /// 同步酒店主题
        /// </summary>
        public void ImportHotelThemeData()
        {

            string path = "data/hoteltheme.xml";
            List<T_XC_HotelTheme> items = new List<T_XC_HotelTheme>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            var themeNodes = xmlDoc.SelectNodes("HotelThemeList/DomesticHotelTheme");
            foreach (XmlElement el in themeNodes)
            {
                items.Add(new T_XC_HotelTheme()
                {
                    ThemeID = el.SelectSingleNode("ThemeID").InnerText.Trim().ToInt32(),
                    ThemeName = el.SelectSingleNode("ThemeName").InnerText.Trim()
                });
            }

            cityBusiness.InsertThemes(items);
        }


        /// <summary>
        /// 同步携程酒店基础数据
        /// </summary>
        void RunImportDate()
        {
            int logId = SaveLog(LogProjectType.Hotel, "同步携程酒店省份、城市、行政区域、酒店主题等基础信息");
            InitCtripProvinces();
            InitCtripCountry();
            InitCtripCityData();
            ImportLocationData();
            ImportHotelThemeData();
            UpdateLogEndDate(logId);
        }

        private void btnHotelBrand_Click(object sender, EventArgs e)
        {

            btnSyncProvince.Enabled = false;
            btnHotelBrand.Enabled = false;

            int logid = SaveLog(LogProjectType.Hotel, "添加酒店品牌信息");

            string path = "data/hotelbrandcode.xml";
            List<HotelBrandDetailInfo> hotelBrands = new List<HotelBrandDetailInfo>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            var brands = xmlDoc.SelectNodes("brands/brand");
            int brandId = 0;
            string brandName;
            string brandEName;
            string brandImgs;
            string brandTel;
            int type = 0;
            string description;
            foreach (XmlNode node in brands)
            {
                brandId = node.SelectSingleNode("id").InnerText.ToInt32();
                brandName = node.SelectSingleNode("name").InnerText.Trim();
                brandEName = node.SelectSingleNode("enname").InnerText.Trim();
                brandImgs = node.SelectSingleNode("img").InnerText.Trim()??"";
                brandTel = node.SelectSingleNode("tel").InnerText.Trim() ?? "";
                type = node.GetChildNodeInnerText("type").ToInt32();
                description = node.GetChildNodeInnerText("remark");
                

                hotelBrands.Add(new HotelBrandDetailInfo()
                {
                    AddDate = DateTime.Now,
                    BrandEName = brandEName,
                    BrandID = brandId,
                    BrandImg = brandImgs,
                    BrandName = brandName,
                    BrandTel = brandTel,
                    BrandType = 0,
                    Description = description,
                    IsHotBrand = 0,
                    IsSearchRecommend = 0,
                    OrderIndex = 0, State = 1,  Type = type
                });
            }



            cityBusiness.InsertHotelBrandDetailInfos(hotelBrands);

            UpdateLogEndDate(logid);
            lblThemeMsg.Text = "主题同步完成";
            lblThemeMsg.ForeColor = Color.Blue;
            btnSyncProvince.Enabled = true;
            btnHotelBrand.Enabled = true;
        }
    }
}

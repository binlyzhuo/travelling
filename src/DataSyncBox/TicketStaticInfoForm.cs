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
using System.Xml;
using Travelling.Domain;
using Travelling.TravelInterface.Repository;
using Travelling.FrameWork;
using Travelling.Domain.Scenery;

namespace DataSyncBox
{
    public partial class TicketStaticInfoForm : BaseAdminForm
    {
        private readonly ISceneryTicketInfoBusinessLogic ticketInfoBusiness;
        public TicketStaticInfoForm()
        {
            InitializeComponent();
            var kernel = new StandardKernel(new TicketInjectDataProvider());
            ticketInfoBusiness = kernel.Get<ISceneryTicketInfoBusinessLogic>();
        }

        private void btnImportTicketData_Click(object sender, EventArgs e)
        {
            btnImportSceneryTheme.Enabled = false;
            btnImportTicketData.Enabled = false;
            string path = "data/scenic-geo-cn.xml";
            List<T_SceneryProvinceDetailInfo> items = new List<T_SceneryProvinceDetailInfo>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
           
            
            var provinceNode = xmlDoc.SelectNodes("provincelist/province");
            foreach (XmlNode pn in provinceNode)
            {
                T_SceneryProvinceDetailInfo p = new T_SceneryProvinceDetailInfo();
                p.ID = pn.SelectSingleNode("id").InnerText.Trim().ToInt32();
                p.Name = pn.SelectSingleNode("name").InnerText.Trim();
                p.PinYin = pn.SelectSingleNode("pinyin").InnerText.Trim();
                p.PinYinIndex = pn.SelectSingleNode("index").InnerText.Trim();
                p.ParentID = 0;
                p.IsRecommend = 0;
                p.OrderNum = 0;
                p.SceneryCount = 0;
                items.Add(p);
                var cityNodes = pn.SelectNodes("cityList/city");
                T_SceneryProvinceDetailInfo city = null;
                foreach (XmlNode cn in cityNodes)
                {

                    city = new T_SceneryProvinceDetailInfo();
                    city.ID = cn.SelectSingleNode("id").InnerText.Trim().ToInt32();
                    city.Name = cn.SelectSingleNode("name").InnerText.Trim();
                    city.PinYin = cn.SelectSingleNode("pinyin").InnerText.Trim();
                    city.PinYinIndex = cn.SelectSingleNode("index").InnerText.Trim();
                    city.ParentID = p.ID;
                    city.IsRecommend = 0;
                    city.OrderNum = 0;
                    city.SceneryCount = 0;
                    items.Add(city);
                }
            }

            ticketInfoBusiness.AddProvinces(items);
            lblCityMsg.Text = "景区相关省份城市同步完成";
            lblCityMsg.ForeColor = Color.Blue;

            btnImportSceneryTheme.Enabled = true;
            btnImportTicketData.Enabled = true;
            
        }

        private void TicketStaticInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void btnImportSceneryTheme_Click(object sender, EventArgs e)
        {
            btnImportSceneryTheme.Enabled = false;
            btnImportTicketData.Enabled = false;

            string path = "data/scenic-theme.xml";
            List<T_SceneryTheme> items = new List<T_SceneryTheme>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);
            
            var themeNodes = xmlDoc.SelectNodes("themeList/theme");
            T_SceneryTheme theme = null;
            foreach (XmlNode n in themeNodes)
            {
                theme = new T_SceneryTheme();
                theme.ID = n.SelectSingleNode("id").InnerText.Trim().ToInt32();
                theme.Name = n.SelectSingleNode("name").InnerText.Trim();
                items.Add(theme);
            }
            ticketInfoBusiness.AddSceneryTheme(items);
            //lblMsg.Text = "景区主题同步完成";

            lblThemeMsg.ForeColor = Color.Blue;
            lblThemeMsg.Text = "景区主题同步完成";

            btnImportSceneryTheme.Enabled = true;
            btnImportTicketData.Enabled = true;

            
        }
    }
}

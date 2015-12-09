using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Travelling.TravelInterface.Repository;
using Ninject;
using System.Threading;
using Travelling.ViewModel.Travel;
using DataSyncBox.Core;
using Travelling.Lucene;

namespace DataSyncBox
{
    public partial class HotelLuceneIndexForm : BaseAdminForm
    {
        private readonly IHotelLuceneIndexBusinessLogic hotelLucene;
        public HotelLuceneIndexForm()
        {
            InitializeComponent();
            var kernel = new StandardKernel(new DependencyResolver());
            hotelLucene = kernel.Get<IHotelLuceneIndexBusinessLogic>();
        }

        private void btnCreateHotelDescIndex_Click(object sender, EventArgs e)
        {
            if(ckRepeat.Checked)
            {
                //hotelLucene.
                //hotelLucene.InitHotelInfoLuceneIndex();
                hotelLucene.InitHotelIndexState();
                HotelSearchLucene.DropHotelLuceneIndex();
            }
            ////////////
            CheckForIllegalCrossThreadCalls = false;
            btnCreateHotelDescIndex.Enabled = false;
            Thread myThread = new Thread(HotelDescriptionIndexCreate);
            myThread.IsBackground = true;
            myThread.Start();
            
        }

        private void btnTestIndexQuery_Click(object sender, EventArgs e)
        {
            //HotelInfoLucene.HotelSearch("","","");
            //HotelSearchEngine.HotelSearch();

            

            HotelInfoQuery query = new HotelInfoQuery()
            {
                //HotelPrice = (int)HotelPriceLevel.Over301,
                CityId = 2,
                KeyWords = "",
                //HotelStar = 3,
                //HotelBrandID = 0,
                LocationID = 0,
                AreaId = 0,
                EndDate = DateTime.Now,
                PageIndex = 1,
                PageSize = 20,
                StartDate = DateTime.Now
            };
            
            //hotellucene.HotelSearch(query, out totalRecords);

            //string cityName = "北京";
            //string address = "北京市景山前街4号";

            //hotellucene.HotelInfoQueryNearScenery(cityName, address);

            var items = HotelSearchLucene.GetInstance().HotelInfoPrimaryInfos();
        }

        private void btnAreaCreateIndex_Click(object sender, EventArgs e)
        {

        }

        private void btnCityAreaCreateIndex_Click(object sender, EventArgs e)
        {

        }

        void SetHotelInfoLuceneIndexProgress(string msg)
        {
            pgLuceneIndex.Value = 0;
            pgLuceneIndex.Maximum = 100;
            for (int i = 0; i < 100; i++)
            {
                pgLuceneIndex.Value = i;
                Thread.Sleep(1);
            }

            lblLuceneMsg.Text = msg;
        }

        private void HotelDescriptionIndexCreate()
        {
            //hotelLucene.IndexHotelDescriptionCreate(SetHotelInfoLuceneIndexProgress);
            hotelLucene.HotelInfoLuceneIndexAction(SetHotelInfoLuceneIndexProgress);
        }
    }
}

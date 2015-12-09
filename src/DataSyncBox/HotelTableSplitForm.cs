using DataSyncBox.Core;
using Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel;
using Travelling.ViewModel.Dto.HotelSyncRecord;

namespace DataSyncBox
{
    public partial class HotelTableSplitForm : BaseAdminForm
    {
        private readonly IHotelInfoBusinessLogic hotelInfoBusiness;
        private readonly IHotelDataSyncBusinssLogic hotelDataSyncBusiness;
        public HotelTableSplitForm()
        {
            InitializeComponent();
            var kernel = new StandardKernel(new DependencyResolver());
            hotelInfoBusiness = kernel.Get<IHotelInfoBusinessLogic>();
            hotelDataSyncBusiness = kernel.Get<IHotelDataSyncBusinssLogic>();
            CheckForIllegalCrossThreadCalls = false;
            //
        }

        //private void btnCreateCityHotelPrice_Click(object sender, EventArgs e)
        //{
        //    hotelInfoBusiness.CreateTableForCityHotelPrices();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //hotelInfoBusiness.HotelRoomRatePlanSyncForCity();
        }

        private void btnSplitSyncDatabase_Click(object sender, EventArgs e)
        {
            //
            CheckForIllegalCrossThreadCalls = false;
            btnSplitSyncDatabase.Enabled = false;
            Thread myThread = new Thread(HotelSyncRoomRatePlanTablesCreate);
            myThread.IsBackground = true;
            myThread.Start();
        }

        void HotelSyncRoomRatePlanTablesCreate()
        {
            int account = accountinfo.ID;
            int logid = SaveLog(Travelling.ViewModel.LogProjectType.Hotel, "酒店同步库创建价格计划分表");
            hotelDataSyncBusiness.CreateHotelRoomRateTablesForCities(CreateSyncRoomPlanTablesProgress);
            UpdateLogEndDate(logid);
        }

        void CreateSyncRoomPlanTablesProgress(string msg)
        {
            pgSyncDatabase.Value = 0;

            pgSyncDatabase.Maximum = 100;
            for (int i = 0; i < 100; i++)
            {
                pgSyncDatabase.Value = i;
                Thread.Sleep(1);
            }

            lblSyncMsg.Text = msg;
        }

        [Obsolete("废弃")]
        private void btnCreateCityHotelPrice_Click(object sender, EventArgs e)
        {
           
        }

        void CreateHotelRoomPlanTablesProgress(string msg)
        {
            pgHotelRoomRateTables.Value = 0;

            pgHotelRoomRateTables.Maximum = 100;
            for (int i = 0; i < 100; i++)
            {
                pgHotelRoomRateTables.Value = i;
                Thread.Sleep(1);
            }

            lblHotelMsg.Text = msg;
        }

        
    }
}

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

namespace DataSyncBox
{
    public partial class HotelDataImportOnlineForm : BaseAdminForm
    {
        private readonly IHotelDataSyncBusinssLogic hotelDataSyncBusiness;
        private readonly IHotelInfoBusinessLogic hotelinfoBusiness;
        public HotelDataImportOnlineForm()
        {
            InitializeComponent();

            var kernel = new StandardKernel(new DependencyResolver());
            hotelDataSyncBusiness = kernel.Get<IHotelDataSyncBusinssLogic>();
            hotelinfoBusiness = kernel.Get<IHotelInfoBusinessLogic>();
        }

        private void btnImportHotelDescription_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            btnImportHotelDescription.Enabled = false;
            Thread myThread = new Thread(ImportHotelInfoDateOnline);
            myThread.IsBackground = true;
            myThread.Start();
        }

        private void btnImportHotelRoomRatePlan_Click(object sender, EventArgs e)
        {
            
        }

        private void btnImportHotelPrice_Click(object sender, EventArgs e)
        {

        }

        private void ImportHotelInfoDateOnline()
        {
            //hotelDataSyncBusiness.HotelInfoSyncOnline(SetHotelRecordSyncProgress);
        }

        void SetHotelRecordSyncProgress(string msg)
        {
            ImportprogressBar.Value = 0;
            ImportprogressBar.Maximum = 100;
            for (int i = 0; i < 100; i++)
            {
                ImportprogressBar.Value = i;
                Thread.Sleep(4);
            }

            lblMsg.Text = msg;
        }

        

        private void btnImportHotelMinPrice_Click(object sender, EventArgs e)
        {
            hotelDataSyncBusiness.ImportHotelMinPrice();
            lblMsg.Text = "导入酒店最低价格成功";
        }

        private void btnSyncCityHotelCount_Click(object sender, EventArgs e)
        {
            //hotelinfoBusiness.HotelCityDetailInfoUpdateHotelCount();
            //lblMsg.Text = "同步酒店个数完成";
        }

    }
}

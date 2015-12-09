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
using Travelling.TravelInterface.Repository;

namespace DataSyncBox
{
    public partial class RoomRatePlanSyncLogEditForm : BaseAdminForm
    {
        private readonly IHotelDataSyncBusinssLogic hotelDataSyncBusiness;
        public RoomRatePlanSyncLogEditForm()
        {
            InitializeComponent();

            var kernel = new StandardKernel(new DependencyResolver());
            hotelDataSyncBusiness = kernel.Get<IHotelDataSyncBusinssLogic>();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

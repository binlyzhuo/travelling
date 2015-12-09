using DataSyncBox.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Travelling.OpenApiLogic;

namespace DataSyncBox
{
    public partial class SceneryTicketTestForm : BaseAdminForm
    {
        public SceneryTicketTestForm()
        {
            InitializeComponent();
        }

        private void btnSceneryTrafficInfo_Click(object sender, EventArgs e)
        {
            int sceneryId  = 79; //Convert.ToInt32(txtSceneryID.Text);
            
            var rep=SceneryTicketServiceLogic.GetSceneryTrafficInfo(sceneryId);
        }

        private void btmGetSceneryImgs_Click(object sender, EventArgs e)
        {
            int sceneryId  = 79; //Convert.ToInt32(txtSceneryID.Text);
            var rep = SceneryTicketServiceLogic.GetSceneryImageList(sceneryId);

            
        }

        private void btnGetNearbyScenery_Click(object sender, EventArgs e)
        {
            int sceneryId = 14041; 
            var rep = SceneryTicketServiceLogic.GetNearbyScenery(sceneryId);
        }

        private void btnGetSceneryPrice_Click(object sender, EventArgs e)
        {
            int sceneryId = 26319;
            var rep = SceneryTicketServiceLogic.GetSceneryPrice(sceneryId);
        }

        private void btnGetSceneryDetail_Click(object sender, EventArgs e)
        {
            int sceneryId = 3177;
            var rep = SceneryTicketServiceLogic.GetSceneryDetail(sceneryId);
        }

        private void btnGetSceneryByCityID_Click(object sender, EventArgs e)
        {
            int cityId = 45;
            var rep = SceneryTicketServiceLogic.SceneryInfoSync(cityId,1,10);
        }

        private void btnGetCaluar_Click(object sender, EventArgs e)
        {
            SceneryTicketServiceLogic.GetPriceCalendar(DateTime.Now.AddDays(1), DateTime.Now.AddDays(20), 56085);
        }

        
    }
}

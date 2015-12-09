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
using Travelling.OpenApiEntity.TC.Hotel;
using Travelling.OpenApiLogic;
using Travelling.TravelInterface.Repository;

namespace DataSyncBox
{
    public partial class tcHotelApiTestForm : Form
    {
        protected readonly StandardKernel kernel;
        private readonly ITCHotelResourceBusinessLogic tcHotelResourceLogic;

        public tcHotelApiTestForm()
        {
            InitializeComponent();
            kernel = new StandardKernel(new TCHotelResourceNInject());
            tcHotelResourceLogic = kernel.Get<ITCHotelResourceBusinessLogic>();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            int hotelId = 135;
            int cityid = 583;
            //OTAHotelServiceLogic.TC_GetHotelDetail(hotelId);
            GetHotelListCallEntity search = new GetHotelListCallEntity();
            search.cityId = cityid;
            search.comeDate = DateTime.Now.AddDays(1);
            search.leaveDate = DateTime.Now.AddDays(3);
            search.chainId = 8;
            //search.keyword = "7天";
            var rep=OTATCHotelServiceLogic.TC_GetHotelList(search);
            
            GetHotelListCallEntity callEntity = new GetHotelListCallEntity();
            callEntity.cityId = cityid;
            callEntity.comeDate = DateTime.Now.AddDays(1);
            callEntity.leaveDate = DateTime.Now.AddDays(3);
            //var rep=OTATCHotelServiceLogic.TC_GetHotelList(callEntity);
            //OTATCHotelServiceLogic.GetCommentList(61366);
        }
    }
}

using DataSyncBox.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Travelling.OpenApiEntity.Ctrip.Tuan;
using Travelling.OpenApiEntity.TC.Hotel;
using Travelling.OpenApiLogic;

namespace DataSyncBox
{
    public partial class HotelApiTestForm : BaseAdminForm
    {
        public HotelApiTestForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int hotelId = Convert.ToInt32(txtHotelID.Text);
            List<int> hotelIds = new List<int>() { 1221829 };
            //var rep = OTAHotelServiceLogic.OTA_HotelDescriptiveInfo(hotelIds,true,true);
            //var rep = OTAHotelServiceLogic.OTA_HotelRatePlan(hotelIds,DateTime.Now,DateTime.Now.AddDays(20));
            var query = OTAHotelServiceLogic.OTA_HotelSearch(true, 1);
            int hotelid = 345025;
            int roomid = 129580;
            int roomCount = 1;
            int guestCount = 1;

            DateTime InRoomDate = DateTime.Now;
            DateTime OffRoomDate = DateTime.Now.AddDays(1);

            string BeforeCheckInTime = "16:00";

            string LastCheckInTime = "18:00";

            string startDateTime = InRoomDate.ToString("yyyy-MM-dd") + " " + BeforeCheckInTime;
            string endDateTime = OffRoomDate.ToString("yyyy-MM-dd") + " " + LastCheckInTime;
            string lastCheckInDate = InRoomDate.ToString("yyyy-MM-dd") + " " + LastCheckInTime;
            //var rep2=OTAHotelServiceLogic.HotelRoomBookAvaible(hotelid, roomid, roomCount, guestCount, Convert.ToDateTime(startDateTime), Convert.ToDateTime(endDateTime), Convert.ToDateTime(lastCheckInDate));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var rep = OTAHotelServiceLogic.OTA_HotelSearch(false, Convert.ToInt32(txtCityID.Text));
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtOrderNo.Text))
            {
                OTAHotelServiceLogic.OTA_CancelHotelBookOrder(txtOrderNo.Text);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           if(string.IsNullOrEmpty(txtHotelDescID.Text))
           {
               return;
           }

           //int hotelId = 436187;
           int hotelId = Convert.ToInt32(txtHotelDescID.Text);
           List<int> hotelIds = new List<int>() { hotelId };
           var rep = OTAHotelServiceLogic.OTA_HotelDescriptiveInfo(hotelIds,true,true);

        }

        private void btnGetUserUnique_Click(object sender, EventArgs e)
        {
            OTAUserServiceLogic.OTA_UserUniqueID("addd","13465905731");
        }

        private void tuanSearch_Click(object sender, EventArgs e)
        {
            GroupProductListCallEntity callEntity = new GroupProductListCallEntity()
            {
                EndDate = DateTime.Now.AddDays(5),
                BeginDate = DateTime.Now,
                CityName = "上海"
            };
            //OTATuanServiceLogic.GroupProductList(callEntity);
            //OTATuanServiceLogic.Product_Detail();
            //OTATuanServiceLogic.Product_Get(14);
            //CtripTuanOTAService
            //OTAHotelServiceLogic.TC_GetHotelList();
            //OTAHotelServiceLogic.TC_GetHotelDetail(0);
            //OTAHotelServiceLogic.TC_GetHotelRooms();
           // OTAHotelServiceLogic.TC_GetHotelImageList(10477);
            //OTAHotelServiceLogic.TC_GetHotelTrafficInfo(10477);

            //OTAHotelServiceLogic.TC_GetHotelRoomsMulti(new GetHotelRoomsMultiCallEntity() { leaveDate = DateTime.Now.AddDays(2), comeDate = DateTime.Now.AddDays(1), HotelIdList = new List<int>() { 10477 } });
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Travelling.OpenApiEntity.Zhuna;
using Travelling.OpenApiLogic;

namespace DataSyncBox
{
    public partial class zhuanApiTestForm : Form
    {
        public zhuanApiTestForm()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //ZhunaHotelServiceLogic.GetCity();
            //ZhunaHotelServiceLogic.GetCBD("0101");
            var repdata=ZhunaHotelServiceLogic.GetLable("287");
            //ZhunaHotelServiceLogic.GetHotelChain();
            //ZhunaHotelServiceLogic.GetCityarea("0101");
            //ZhunaHotelServiceLogic.GetLableType();
            //ZhunaHotelServiceLogic.GetHotelChain();
            //ZhunaHotelServiceLogic.GetCitychain(3);
            //ZhunaHotelServiceLogic.GetSchool("0101");
            //ZhunaHotelServiceLogic.GetSubwayline("0101");
            //ZhunaHotelSearchCallEntity search = new ZhunaHotelSearchCallEntity();
            //search.cityid = "0101";
            //ZhunaHotelServiceLogic.HotelSearch(search);
            //ZhunaHotelServiceLogic.HotelPromotionSearch("0101");
            //ZhunaHotelServiceLogic.HotelRoomPlanSearch(4061, DateTime.Now.AddDays(1), DateTime.Now.AddDays(2));
            //ZhunaHotelServiceLogic.HotelInfoSearch(3939);
            //ZhunaHotelServiceLogic.GetCommentlist("0101");
            //ZhunaHotelServiceLogic.GetHotelComment(104529);
            //ZhunaHotelServiceLogic.GetQuestionlist("0101");
            //ZhunaHotelServiceLogic.GetHotelQuestion(5801);
            //ZhunaHotelServiceLogic.GetHotelPic(4061);
            //ZhunaHotelServiceLogic.GetSchool("0101");
        }
    }
}

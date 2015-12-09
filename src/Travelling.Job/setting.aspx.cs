using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Travelling.JobSchedule;
using Travelling.TravelInterface.Job;
using System.Drawing;

namespace Travelling.Job
{
    public partial class setting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void ResetJob()
        {
            Global.InitJob();
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtAdminPwd.Text))
            {
                lblMsg.Text = "请输入密码";
                lblMsg.ForeColor = Color.Red;
                return;
            }
            if(txtAdminPwd.Text.Trim()=="123456"+DateTime.Now.Minute.ToString())
            {
                ResetJob();
                lblMsg.Text = "重置任务成功";
                lblMsg.ForeColor = Color.Green;
            }
            else
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "密码错误";
            }
        }
    }
}
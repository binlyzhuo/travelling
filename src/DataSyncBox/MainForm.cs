using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Travelling.FrameWork;
using Travelling.CommonLibrary;
using Ninject;
using Travelling.TravelInterface.Repository;
using Travelling.Repository;
using DataSyncBox.Core;
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;
using Travelling.ViewModel;

namespace DataSyncBox
{
    public partial class MainForm : BaseAdminForm
    {
        private readonly IAccountBusinessLogic accountBusinessLogic;

        public MainForm()
        {
            InitializeComponent();
            DtoMapper.AutoMapper();
            LogHelper.LogConfig("data/log4net.config");
            PanGu.Segment.Init();

            var kernel = new StandardKernel(new DependencyResolver());
            accountBusinessLogic = kernel.Get<IAccountBusinessLogic>();
            logBusiness = kernel.Get<ISystemLogBusinessLogic>();
            ClientIP = IPHelper.GetLocalIP();

            txtUserName.Text = "binlyzhuo";
            txtPassword.Text = "1";

        }

        delegate void dShowForm();
        
        void ShowForm()
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new dShowForm(this.ShowForm));
            }
            else
            {
                
            }
        }

        void SetProgress()
        {
           
        }

        protected void Login(object obj,EventArgs e)
        {
            //MessageBox.Show("Hello!");

            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //bool sendResult = EmailService.SendMail("binlyzhuo@outlook.com","测试邮件发送","我不是垃圾邮件，谢谢！","");
            //Type t = typeof(MainBoard);
            //if()

            

            if(string.IsNullOrEmpty(txtUserName.Text))
            {
                lblUserNameMsg.ForeColor = Color.Red;
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                lblPwdMsg.ForeColor = Color.Red;
                return;
            }

            accountinfo = accountBusinessLogic.GetAccountInfo(txtUserName.Text,Md5.GetMd5(txtPassword.Text));
            if(accountinfo==null)
            {
                lblLoginMsg.Text = "用户名或者密码不正确";
                return;
            }

            SaveLog(LogProjectType.System,"用户登录");

            this.Hide();
            MainBoard mainBoard = new MainBoard();
            mainBoard.Show();
        }
    }
}

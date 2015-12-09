using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DataSyncBox.Core;

namespace DataSyncBox
{
    public partial class MainBoard : BaseAdminForm
    {
        
        CtripProvinceForm provinceForm = new CtripProvinceForm();

        public MainBoard()
        {
            InitializeComponent();
            string uname = accountinfo.Name;
        }

        private void ctripProvincesMenu_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            CtripProvinceForm ctripProvinceForm = new CtripProvinceForm();
            ctripProvinceForm.TopLevel = false;
            ctripProvinceForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panelContainer.Controls.Add(ctripProvinceForm);
            ctripProvinceForm.Show();
        }

        private void MainBoard_Load(object sender, EventArgs e)
        {

        }

        private void closeAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定要退出短信收发系统吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Application.ExitThread();//子窗体可以用，this.Dispose();
                Application.Exit();
            }
        }

        private void MainBoard_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult result = MessageBox.Show("确定要退出系统吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Application.ExitThread();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void sceneryInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            SceneryInfoForm sceneryForm = new SceneryInfoForm();
            sceneryForm.TopLevel = false;
            sceneryForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panelContainer.Controls.Add(sceneryForm);
            sceneryForm.Show();
        }

        private void tcSceneryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            TicketStaticInfoForm ticketStaticForm = new TicketStaticInfoForm();
            ticketStaticForm.TopLevel = false;
            ticketStaticForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panelContainer.Controls.Add(ticketStaticForm);
            ticketStaticForm.Show();
        }

        private void ctripHotelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            CtripHotelInfoForm hotelForm = new CtripHotelInfoForm();

            hotelForm.TopLevel = false;
            hotelForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panelContainer.Controls.Add(hotelForm);
            hotelForm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void hotelDataBakeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sceneryDataBakeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ctripApiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            HotelApiTestForm apiTest = new HotelApiTestForm();

            apiTest.TopLevel = false;
            apiTest.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panelContainer.Controls.Add(apiTest);
            apiTest.Show();
        }

        private void MainBoard_SizeChanged(object sender, EventArgs e)
        {
            if(this.WindowState==FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Text = "悦悦旅游网数据同步工具";
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            notifyIcon1.Text = "悦悦旅游网数据同步工具";
            this.WindowState = FormWindowState.Normal;
        }

        private void tongchengApiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            SceneryTicketTestForm apiTest = new SceneryTicketTestForm();

            apiTest.TopLevel = false;
            apiTest.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panelContainer.Controls.Add(apiTest);
            apiTest.Show();
        }

        private void hotelRoomRatePlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            hotelRoomRatePlanForm ratePlanForm = new hotelRoomRatePlanForm();

            ratePlanForm.TopLevel = false;
            ratePlanForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panelContainer.Controls.Add(ratePlanForm);
            ratePlanForm.Show();
        }

        private void importHotelDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            HotelDataImportOnlineForm importHotelDataForm = new HotelDataImportOnlineForm();

            importHotelDataForm.TopLevel = false;
            importHotelDataForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panelContainer.Controls.Add(importHotelDataForm);
            importHotelDataForm.Show();
        }

        private void hotelRoomRatePlanImportOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hotelQuerySettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            
            HotelLuceneIndexForm hotelIndexForm = new HotelLuceneIndexForm();
            hotelIndexForm.TopLevel = false;
            hotelIndexForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panelContainer.Controls.Add(hotelIndexForm);
            hotelIndexForm.Show();
        }

        private void quartzTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();

            QuartzForm quartzForm = new QuartzForm();
            quartzForm.TopLevel = false;
            quartzForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panelContainer.Controls.Add(quartzForm);
            quartzForm.Show();
        }

        private void hotelTableSplitToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void sceneryQuerySettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();

            SceneryLuceneIndexForm sceneryLuceneIndexForm = new SceneryLuceneIndexForm();
            sceneryLuceneIndexForm.TopLevel = false;
            sceneryLuceneIndexForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panelContainer.Controls.Add(sceneryLuceneIndexForm);
            sceneryLuceneIndexForm.Show();
        }

        private void splitHotelTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();

            HotelTableSplitForm hotelSplitForm = new HotelTableSplitForm();
            hotelSplitForm.TopLevel = false;
            hotelSplitForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panelContainer.Controls.Add(hotelSplitForm);
            hotelSplitForm.Show();
        }

        private void hotelCityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            tcHotelProvinceForm tcProvinceForm = new tcHotelProvinceForm();
            tcProvinceForm.TopLevel = false;
            tcProvinceForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panelContainer.Controls.Add(tcProvinceForm);
            tcProvinceForm.Show();
        }

        private void tcApiTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            tcHotelApiTestForm tcApiTestForm = new tcHotelApiTestForm();
            tcApiTestForm.TopLevel = false;
            tcApiTestForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panelContainer.Controls.Add(tcApiTestForm);
            tcApiTestForm.Show();
        }

        private void zhunaapitestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            zhuanApiTestForm zhunaApiTestForm = new zhuanApiTestForm();
            zhunaApiTestForm.TopLevel = false;
            zhunaApiTestForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panelContainer.Controls.Add(zhunaApiTestForm);
            zhunaApiTestForm.Show();
        }

        private void zhunaDataSyncMenuItem_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            zhunaApiDataSyncForm zhunaApiDataSyncForm = new zhunaApiDataSyncForm();
            zhunaApiDataSyncForm.TopLevel = false;
            zhunaApiDataSyncForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panelContainer.Controls.Add(zhunaApiDataSyncForm);
            zhunaApiDataSyncForm.Show();
        }

        /// <summary>
        /// 酒店数据整合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hotelDataComformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelContainer.Controls.Clear();
            HotelDataForm hotelDataComformForm = new HotelDataForm();
            hotelDataComformForm.TopLevel = false;
            hotelDataComformForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panelContainer.Controls.Add(hotelDataComformForm);
            hotelDataComformForm.Show();
        }

    }
}

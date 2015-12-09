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
using Travelling.Domain;
using Travelling.Domain.Scenery;
using Travelling.OpenApiLogic;
using Travelling.TravelInterface.Repository;

namespace DataSyncBox
{
    public partial class SceneryInfoForm : Form
    {
        private readonly ISceneryTicketInfoBusinessLogic ticketInfoBusiness;
        private readonly ISceneryTicketDataSyncBusinessLogic ticketInfoDataSyncBusiness;


        public SceneryInfoForm()
        {

            InitializeComponent();
            lblMsg.Width = 200;
            var kernel = new StandardKernel(new TicketInjectDataProvider());
            ticketInfoBusiness = kernel.Get<ISceneryTicketInfoBusinessLogic>();
            ticketInfoDataSyncBusiness = kernel.Get<ISceneryTicketDataSyncBusinessLogic>();

            CheckSyncState();
        }

        /// <summary>
        /// 检查初始化数据状态
        /// </summary>
        private void CheckSyncState()
        {
            int sceneryCitySyncCount = ticketInfoDataSyncBusiness.GetSceneryCitySyncRecordCount(null);
            if(sceneryCitySyncCount==0)
            {
                btnInitSyncRecord.Enabled = true;
                btnSyncScenerySearchInfo.Enabled = false;
            }
            sceneryCitySyncCount = ticketInfoDataSyncBusiness.GetSceneryCitySyncRecordCount(false);
            if(sceneryCitySyncCount==0)
            {
                //btnSceneryDetail.Enabled = false;
                
                lblMsg.Text = "请先初始化景区城市信息";
            }

        }

        private void btnSyncScenery_Click(object sender, EventArgs e)
        {
            if(ckIsRepeat.Checked)
            {
                if (MessageBox.Show("确认清空之前同步的景区信息？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnInitSyncRecord.Enabled = false;
                    btnSyncScenerySearchInfo.Enabled = false;

                    ticketInfoDataSyncBusiness.InitSceneryInfoSyncRecord();
                }
            }

            CheckForIllegalCrossThreadCalls = false;
            lblMsg.Text = "程序启动中，请不要关闭！";

            btnSyncScenerySearchInfo.Enabled = false;
            Thread myThread = new Thread(SceneryInfoDataSync);
            myThread.IsBackground = true;
            myThread.Start();

        }

        /// <summary>
        /// 景区查询信息同步
        /// </summary>
        private void SceneryInfoDataSync()
        {
            ticketInfoDataSyncBusiness.SceneryInfoSync(RecordSyncProgress);
            lblMsg.Text = "同步完成！";
        }

        /// <summary>
        /// 同步进度条
        /// </summary>
        /// <param name="msg"></param>
        void RecordSyncProgress(string msg)
        {
            progressBar1.Value = 0;

            progressBar1.Maximum = 100;
            for (int i = 0; i < 100; i++)
            {
                progressBar1.Value = i;
                Thread.Sleep(5);
            }

            lblMsg.Text = msg;
        }

        /// <summary>
        /// 景区详细信息同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSceneryDetail_Click(object sender, EventArgs e)
        {
            if(ckIsRepeat.Checked)
            {
                if (MessageBox.Show("确认清空之前同步的景区详细信息？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    btnSceneryDetail.Enabled = false;
                    ticketInfoDataSyncBusiness.InitSceneryDetailInfoSyncRecord();
                }
            }
            
            
            CheckForIllegalCrossThreadCalls = false;
            lblMsg.Text = "程序启动中，请不要关闭！";

            btnSyncScenerySearchInfo.Enabled = false;
            Thread myThread = new Thread(SceneryDetailSync);
            myThread.IsBackground = true;
            myThread.Start();
        }

        /// <summary>
        /// 景区详细信息同步
        /// </summary>
        private void SceneryDetailSync()
        {
            ticketInfoDataSyncBusiness.SceneryInfoDetailSync(RecordSyncProgress);
        }

        /// <summary>
        /// 景区门票价格同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSceneryTicketPriceSync_Click(object sender, EventArgs e)
        {
            bool isInit = false;
            if(ckIsRepeat.Checked)
            {
                if (MessageBox.Show("确认清空之前同步的景区价格信息？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    isInit = true;
                    ticketInfoDataSyncBusiness.InitSceneryTicketPriceSyncData();
                }
            }
            

            btnSceneryTicketPriceSync.Enabled = false;
            btnSceneryDetail.Enabled = false;
            CheckForIllegalCrossThreadCalls = false;
            lblMsg.Text = "程序启动中，请不要关闭！";

            btnSyncScenerySearchInfo.Enabled = false;
            Thread myThread = new Thread(SceneryTicketPriceSync);
            myThread.IsBackground = true;
            myThread.Start();
        }

        /// <summary>
        /// 同步景区门票价格
        /// </summary>
        private void SceneryTicketPriceSync()
        {
            try
            {
                ticketInfoDataSyncBusiness.SceneryTicketPriceSync(RecordSyncProgress);
            }
            catch(Exception ex)
            {
                lblMsg.Text = "报错了，重启中....";
                Thread.Sleep(2000);
                ticketInfoDataSyncBusiness.SceneryTicketPriceSync(RecordSyncProgress);
            }
        }

        /// <summary>
        /// 同步景区查询信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInitSyncRecord_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认清空之前同步的景区城市信息？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ticketInfoDataSyncBusiness.InitSceneryCitySyncRecord();
                lblMsg.Text = "数据初始化完成";
            }
        }

        /// <summary>
        /// 同步景区图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSyncSceneryImg_Click(object sender, EventArgs e)
        {
            if(ckIsRepeat.Checked)
            {
                if (MessageBox.Show("确认清空之前同步的景区图片信息？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    ticketInfoDataSyncBusiness.InitSceneryImgsSyncDate();
                }
            }

            btnSceneryTicketPriceSync.Enabled = false;
            btnSceneryDetail.Enabled = false;
            CheckForIllegalCrossThreadCalls = false;
            lblMsg.Text = "程序启动中，请不要关闭！";

            btnSyncScenerySearchInfo.Enabled = false;
            btnSyncSceneryImg.Enabled = false;
            Thread myThread = new Thread(SceneryImgSyncAction);
            myThread.IsBackground = true;
            myThread.Start();

        }

        /// <summary>
        /// 同步景区图片信息
        /// </summary>
        private void SceneryImgSyncAction()
        {
            try
            {
                ticketInfoDataSyncBusiness.SceneryImgSyncRecord(RecordSyncProgress);
            }
            catch(Exception ex)
            {
                lblMsg.Text = "出错了，重启中....";
                Thread.Sleep(10);
                ticketInfoDataSyncBusiness.SceneryImgSyncRecord(RecordSyncProgress);
            }
        }
    }
}

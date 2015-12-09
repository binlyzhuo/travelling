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
using Ninject;
using Travelling.Domain;
using Travelling.OpenApiEntity.Ctrip.Hotel;
using Travelling.OpenApiLogic;
using Travelling.OpenApiEntity.Ctrip.Hotel.Module;
using Travelling.FrameWork;
using Travelling.CommonLibrary;
using Travelling.ViewModel;
using Travelling.Domain.HotelSyncRecord;
using Travelling.TravelInterface.Data.HotelSyncRecord;
using DataSyncBox.Core;

namespace DataSyncBox
{
    public partial class CtripHotelInfoForm :Form
    {
        // 同步业务处理
        private readonly IHotelDataSyncBusinssLogic hotelDataSyncBusiness;
        private readonly Thread[] threads = new Thread[10];

        public delegate void MethodCaller(bool isClear);

        public CtripHotelInfoForm()
        {
            InitializeComponent();
            var kernel = new StandardKernel(new DependencyResolver());
            hotelDataSyncBusiness = kernel.Get<IHotelDataSyncBusinssLogic>();
            CheckState();
            CheckForIllegalCrossThreadCalls = false;
            lblMsg.Width = 300;
        }

        public delegate void dSetProgress(int total, int current);
        

        /// <summary>
        /// 检查同步数据
        /// </summary>
        private void CheckState()
        {
            var hotelRoomPriceJobDto = hotelDataSyncBusiness.HotelRoomRateJobSchedulerGetRecordToExecute();
            if (hotelRoomPriceJobDto!=null)
            {
                dateStart.Value = hotelRoomPriceJobDto.StartDate;
                dateEnd.Value = hotelRoomPriceJobDto.EndDate;
            }
            
        }

        /// <summary>
        /// 初始化酒店城市同步信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("确认要操作？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                btnInit.Enabled = false;
                btnInit.Hide();
                ctriphotelSyncBtn.Enabled = true;
                MessageBox.Show("数据初始化完成");
            }

        }

        /// <summary>
        /// 酒店信息同步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ctriphotelSyncBtn_Click(object sender, EventArgs e)
        {
            bool isInit = false;
            if(ckHotelInfoClearAll.Checked)
            {
                if (MessageBox.Show("确认清空之前同步的酒店信息？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //hotelDataSyncBusiness.InitHotelSyncInfoData();
                    isInit = true;
                }
            }
            CheckForIllegalCrossThreadCalls = false;
            ctriphotelSyncBtn.Enabled = false;
            ParameterizedThreadStart partStart = new ParameterizedThreadStart(ImportHotelSyncInfos);
            object isClearObj = isInit;
            Thread myThread = new Thread(partStart);

            myThread.IsBackground = true;
            myThread.Start(isClearObj);
        }

        /// <summary>
        /// 酒店查询信息同步
        /// </summary>
        private void ImportHotelSyncInfos(object isInit)
        {
            //int logId=SaveLog(LogProjectType.Hotel, "同步酒店信息HotelInfo");
            bool isInitData = Convert.ToBoolean(isInit);
            hotelDataSyncBusiness.ImportHotelSyncInfos(SetHotelRecordSyncProgress, isInitData);
            //logBusiness.UpdateLogEndDate(logId);
        }

        
        void SetHotelRecordSyncProgress(string msg)
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

        void SetProgress(int total, int current)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new dSetProgress(this.SetProgress),
                        new object[] { total, current });
                }
                catch { }
            }
            else
            {
                this.progressBar1.Maximum = total;
                this.progressBar1.Value = current;

                //YQ Test
                //达到最大值后退出
                if (this.progressBar1.Value == this.progressBar1.Maximum)
                {
                    //this.DialogResult = DialogResult.Cancel;
                }
            }
        }

        private void hotelDescriptiveBtn_Click_1(object sender, EventArgs e)
        {
            hotelDescriptiveBtn.Enabled = false;
            bool isInit = false;
            if(ckRepeatSyncHotelDescription.Checked)
            {
                if (MessageBox.Show("确认清空之前同步的酒店静态信息？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    isInit = true;
                }
            }

            CheckForIllegalCrossThreadCalls = false;
            ctriphotelSyncBtn.Enabled = false;
            ParameterizedThreadStart partStart = new ParameterizedThreadStart(ImportHotelDescriptions);
            Thread myThread = new Thread(partStart);
            threads[0] = myThread;
            myThread.IsBackground = true;
            myThread.Start(isInit);

            
        }

        /// <summary>
        /// 同步酒店详细信息
        /// </summary>
        private void ImportHotelDescriptions(object isInit)
        {
            //int logid = SaveLog(LogProjectType.Hotel, "同步酒店详细信息");
            bool isInitData = Convert.ToBoolean(isInit);
            hotelDataSyncBusiness.ImportHotelDescriptionSyncInfos(SetHotelDescriptionSyncProgress,isInitData);
            //logBusiness.UpdateLogEndDate(logid);
        }

        void SetHotelDescriptionSyncProgress(string msg)
        {
            prgHotelDescription.Value = 0;
            prgHotelDescription.Maximum = 100;
            for (int i = 0; i < 100; i++)
            {
                prgHotelDescription.Value = i;
                //Thread.Sleep(1);
            }

            lblHotelDescription.Text = msg;
        }

        private void btnImportHotelRatePlan_Click_1(object sender, EventArgs e)
        {
            bool isClear = false;
            if(ckRoomRatePlanRepeat.Checked)
            {
                if (MessageBox.Show("确认清空之前同步的酒店价格计划信息？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    isClear = true;
                    
                }
            }
            btnImportHotelRatePlan.Enabled = false;
            dateStart.Enabled = false;
            dateEnd.Enabled = false;
            CheckForIllegalCrossThreadCalls = false;
            ctriphotelSyncBtn.Enabled = false;
            ParameterizedThreadStart partStart = new ParameterizedThreadStart(ImportHotelRoomPlanSync);
            object isClearObj = isClear;
            Thread myThread = new Thread(partStart);
            myThread.IsBackground = true;
            myThread.Start(isClearObj);

        }

        /// <summary>
        /// 同步酒店价格计划
        /// </summary>
        private void ImportHotelRoomPlanSync(object isClearObj)
        {
            
            //int logId=SaveLog(LogProjectType.Hotel,"酒店价格信息同步");
            bool isClear = Convert.ToBoolean(isClearObj);
            hotelDataSyncBusiness.HotelSyncRoomRate(SetHotelRoomRatePlanSyncProgress, isClear);
            //logBusiness.UpdateLogEndDate(logId);
        }

        void SetHotelRoomRatePlanSyncProgress(string msg)
        {

            pgRoomRatePlan.Value = 0;
            pgRoomRatePlan.Maximum = 100;
            for (int i = 0; i < 100; i++)
            {
                pgRoomRatePlan.Value = i;
                Thread.Sleep(3);
            }

            lblRoomRatePlan.Text = msg;
        }

        private void btnStopHotelDescriptionSync_Click(object sender, EventArgs e)
        {
            try
            {
                threads[0].Abort();
            }
            catch(Exception ex)
            {
                LogHelper.Error(ex);
            }
        }

        /// <summary>
        /// 酒店最低价格获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHotelPrices_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认清空之前同步的酒店价格信息？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                lblSyncHotelPrice.Text = "开始同步";
                btnHotelPrices.Enabled = false;
                
                lblSyncHotelPrice.Text = "同步完成";
                btnHotelPrices.Enabled = true;

                CheckForIllegalCrossThreadCalls = false;
                ctriphotelSyncBtn.Enabled = false;
                Thread myThread = new Thread(HotelLowestPriceGet);
                myThread.IsBackground = true;
                myThread.Start();
            }
        }

        /// <summary>
        /// 获取酒店最低价格
        /// </summary>
        void HotelLowestPriceGet()
        {
            hotelDataSyncBusiness.HotelLowestPriceGet(SetHotelLowestPriceProgress);
        }

        void SetHotelLowestPriceProgress(string msg)
        {

            pgHotelLowestPriceGet.Value = 0;
            pgHotelLowestPriceGet.Maximum = 100;
            for (int i = 0; i < 100; i++)
            {
                pgHotelLowestPriceGet.Value = i;
                Thread.Sleep(1);
            }
            lblSyncHotelPrice.Text = msg;
        }

        private void btnStopSyncHotelInfoRecord_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                LogHelper.Error(ex);
            }
        }

        private void btnSettingCodeType_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认清空之前设置的区域类型？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                btnSettingCodeType.Enabled = false;
                //CityAreaInfoTypeCodeSetting();
                CheckForIllegalCrossThreadCalls = false;
                ctriphotelSyncBtn.Enabled = false;
                Thread myThread = new Thread(CityAreaInfoTypeCodeSetting);
                myThread.IsBackground = true;
                myThread.Start();
            }
        }

        private void CityAreaInfoTypeCodeSetting()
        {
            hotelDataSyncBusiness.CityAreaInfoSettingTypeCode(SetCityAreaTypeCodeProgress);
        }

        /// <summary>
        /// 城市区域同步进度
        /// </summary>
        /// <param name="msg"></param>
        void SetCityAreaTypeCodeProgress(string msg)
        {
            pgCityAreaTypeCode.Value = 0;
            pgCityAreaTypeCode.Maximum = 100;
            for (int i = 0; i < 100; i++)
            {
                pgCityAreaTypeCode.Value = i;
                Thread.Sleep(2);
            }

            lblAreaMsg.Text = msg;
        }

        private void btnSyncAreaOnline_Click(object sender, EventArgs e)
        {
           
        }

        
    }
}

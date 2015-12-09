using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Travelling.OpenApiLogic;
using Ninject;
using DataSyncBox.Core;
using Travelling.TravelInterface.Repository;
using Travelling.Domain.Zhuna_Hotel;
using Travelling.FrameWork;
using System.Threading;
using Travelling.ViewModel.Dto.Hotel;

namespace DataSyncBox
{
    public partial class zhunaApiDataSyncForm : Form
    {
        private readonly IZhunaHotelSyncBusinessLogic zhunaDataSyncLogic;
        private readonly IZhunaHotelBusinessLogic zhuanHotelBusinessLogic;
        private readonly IHotelCityBusinessLogic hotelCityBusinessLogic;
        public zhunaApiDataSyncForm()
        {
            InitializeComponent();
            var kernel = new StandardKernel(new ZhunaNInjectBusinessLogic());
            var kernel2 = new StandardKernel(new DependencyResolver());

            zhunaDataSyncLogic = kernel.Get<IZhunaHotelSyncBusinessLogic>();
            hotelCityBusinessLogic = kernel2.Get<IHotelCityBusinessLogic>();
            zhuanHotelBusinessLogic = kernel.Get<IZhunaHotelBusinessLogic>();
        }

        private void btnImportZhunaCity_Click(object sender, EventArgs e)
        {
            var repdata=ZhunaHotelServiceLogic.GetCity();
            List<Zhuna_CityInfo> items = new List<Zhuna_CityInfo>();
            Zhuna_CityInfo cityinfo;
            foreach(var p in repdata.reqdata)
            {
                cityinfo = new Zhuna_CityInfo();
                cityinfo.cid = p.cid;
                cityinfo.abcd = p.abcd;
                cityinfo.areaid = p.areaid;
                cityinfo.baidu_lat = p.baidu_lat??"";
                cityinfo.baidu_lng = p.baidu_lng??"";
                cityinfo.cName = p.cname;
                cityinfo.hotelNum = p.hotelNum;
                cityinfo.pid = p.pid;
                cityinfo.pinyin = p.pinyin;
                cityinfo.pName = p.pname;
                cityinfo.suoxie = p.suoxie;
                items.Add(cityinfo);
            }

            zhunaDataSyncLogic.ImportZhunaCity(items);
            lblMsg.Text = "同步完成";
        }

        private void btnImportHotelChains_Click(object sender, EventArgs e)
        {
            var repdata = ZhunaHotelServiceLogic.GetHotelChain();
            List<Zhuna_HotelChain> items = new List<Zhuna_HotelChain>();
            Zhuna_HotelChain chain;
            foreach(var p in repdata.reqdata)
            {
                chain = new Zhuna_HotelChain();
                chain.adddate = DateTime.Now;
                chain.hotelnum = p.hotelnum;
                chain.id = p.id;
                chain.jibie = p.jibie.ToInt32();
                chain.liansuo = p.liansuo;
                chain.ls = p.ls;
                chain.lsid = p.lsid;
                chain.lsname = p.lsname;
                chain.tupian = p.tupian;
                items.Add(chain);
            }

            zhunaDataSyncLogic.ImportZhunaChains(items);
            lblMsg.Text = "同步完成";
        }

        private void btnImportHotelInfo_Click(object sender, EventArgs e)
        {
            //var repdata = ZhunaHotelServiceLogic.HotelSearch("0101");
            bool isDelete = false;
            if(isRepeat.Checked)
            {
                //isDelete = true;
                if (MessageBox.Show("确认清空之前同步的酒店信息？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //hotelDataSyncBusiness.InitHotelSyncInfoData();
                    isDelete = true;
                }
            }
            //zhunaDataSyncLogic.ImportHotelInfo(true);
            //lblMsg.Text = "同步完成";

            CheckForIllegalCrossThreadCalls = false;
            
            ParameterizedThreadStart partStart = new ParameterizedThreadStart(ImportHotelSyncInfos);
            object isClearObj = isDelete;
            Thread myThread = new Thread(partStart);

            myThread.IsBackground = true;
            myThread.Start(isClearObj);
        }

        private void setProgress()
        {

        }

        /// <summary>
        /// 酒店查询信息同步
        /// </summary>
        private void ImportHotelSyncInfos(object isInit)
        {
            bool isInitData = Convert.ToBoolean(isInit);
            zhunaDataSyncLogic.ImportHotelInfo(isInitData,SetHotelRecordSyncProgress);
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

        private void btnImportZhunaCityArea_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认清空之前同步的行政区域信息？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                lblMsg.Text = "开始同步";


                lblMsg.Text = "同步完成";
                btnImportZhunaCityArea.Enabled = true;

                CheckForIllegalCrossThreadCalls = false;

                Thread myThread = new Thread(ImportZhunaCityAreas);
                myThread.IsBackground = true;
                myThread.Start();
            }
        }

        private void ImportZhunaCityAreas()
        {
            zhunaDataSyncLogic.ImportZhunaCityAreaInfo(SetHotelRecordSyncProgress);
        }

        private void syncCtripCityId_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "开始同步";
            var ctripCityinfos = hotelCityBusinessLogic.HotelCityDetailInfosGet();
            var zhunaCityinfos = zhuanHotelBusinessLogic.ZhunaCityInfosGet();
            
            List<HotelCityDetailInfo> cityinfos;
            foreach(var city in zhunaCityinfos)
            {
                try
                {
                    cityinfos = ctripCityinfos.Where(u => u.CityName == city.cName).ToList();
                    if (cityinfos != null && cityinfos.Count > 0)
                    {
                        city.ctripcityid = cityinfos[0].CityID;
                    }
                    else
                    {
                        cityinfos = ctripCityinfos.Where(u => city.cName.StartsWith(u.CityName)).ToList();
                        if (cityinfos != null && cityinfos.Count > 0)
                        {
                            city.ctripcityid = cityinfos[0].CityID;
                        }

                    }
                    if (cityinfos != null && cityinfos.Count>0)
                    {
                        zhuanHotelBusinessLogic.UpdateCityIdWithCtrip(city);
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }

                
                
            }

            

            lblMsg.Text = "城市信息同步完成";
        }

        private void syncCtripHotelBrand_Click(object sender, EventArgs e)
        {
            var ctripHotelBrands = hotelCityBusinessLogic.HotelBrandDetailInfoGetAll();
            var zhunaHotelChains = zhuanHotelBusinessLogic.ZhunaHotelChainsGet();

           
        }

        private void btnImportCityLable_Click(object sender, EventArgs e)
        {
            bool isDelete = false;
            if (isRepeat.Checked)
            {
                if (MessageBox.Show("确认清空之前同步的酒店信息？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    isDelete = true;
                }
            }
            
            CheckForIllegalCrossThreadCalls = false;

            ParameterizedThreadStart partStart = new ParameterizedThreadStart(ImportCityLables);
            object isClearObj = isDelete;
            Thread myThread = new Thread(partStart);

            myThread.IsBackground = true;
            myThread.Start(isClearObj);
        }

        private void ImportCityLables(object isInit)
        {
            bool isInitData = Convert.ToBoolean(isInit);
            zhunaDataSyncLogic.ImportCityLables(isInitData, SetHotelRecordSyncProgress);
        }

        private void btnSchoolSync_Click(object sender, EventArgs e)
        {
            bool isDelete = false;
            if (isRepeat.Checked)
            {
                if (MessageBox.Show("确认清空之前同步的学校信息？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    isDelete = true;
                }
            }

            CheckForIllegalCrossThreadCalls = false;

            ParameterizedThreadStart partStart = new ParameterizedThreadStart(ImportSchools);
            object isClearObj = isDelete;
            Thread myThread = new Thread(partStart);

            myThread.IsBackground = true;
            myThread.Start(isClearObj);
        }


        private void ImportSchools(object isInit)
        {
            bool isInitData = Convert.ToBoolean(isInit);
            zhunaDataSyncLogic.ImportSchoolInfos(isInitData, SetHotelRecordSyncProgress);
        }

        private void btnHotelRefPoint_Click(object sender, EventArgs e)
        {
            bool isDelete = false;
            if (isRepeat.Checked)
            {
                if (MessageBox.Show("确认清空之前同步的酒店周边信息？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    isDelete = true;
                }
            }

            CheckForIllegalCrossThreadCalls = false;

            ParameterizedThreadStart partStart = new ParameterizedThreadStart(ImportHotelRefPoints);
            object isClearObj = isDelete;
            Thread myThread = new Thread(partStart);

            myThread.IsBackground = true;
            myThread.Start(isClearObj);
        }

        private void ImportHotelRefPoints(object isInit)
        {
            bool isInitData = Convert.ToBoolean(isInit);
            zhunaDataSyncLogic.ImportHotelRefpoints(isInitData, SetHotelRecordSyncProgress);
        }

        private void btnCBDSync_Click(object sender, EventArgs e)
        {
            bool isDelete = false;
            if (isRepeat.Checked)
            {
                if (MessageBox.Show("确认清空之前同步的商圈信息？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    isDelete = true;
                }
            }

            CheckForIllegalCrossThreadCalls = false;
            ParameterizedThreadStart partStart = new ParameterizedThreadStart(ImportCityCBD);
            object isClearObj = isDelete;
            Thread myThread = new Thread(partStart);

            myThread.IsBackground = true;
            myThread.Start(isClearObj);
        }

        private void ImportCityCBD(object isInit)
        {
            bool isInitData = Convert.ToBoolean(isInit);
            zhunaDataSyncLogic.ImportCityCBD(isInitData, SetHotelRecordSyncProgress);
        }

        private void btnCityLableInfoSync_Click(object sender, EventArgs e)
        {
            bool isDelete = false;
            if (isRepeat.Checked)
            {
                if (MessageBox.Show("确认清空之前同步的酒店信息？", "提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    isDelete = true;
                }
            }

            CheckForIllegalCrossThreadCalls = false;

            ParameterizedThreadStart partStart = new ParameterizedThreadStart(ImportCityLableInfos);
            object isClearObj = isDelete;
            Thread myThread = new Thread(partStart);

            myThread.IsBackground = true;
            myThread.Start(isClearObj);
        }

        private void ImportCityLableInfos(object isInit)
        {
            bool isInitData = Convert.ToBoolean(isInit);
            zhunaDataSyncLogic.ImportCityLableInfos(isInitData, SetHotelRecordSyncProgress);
        }
    }
}

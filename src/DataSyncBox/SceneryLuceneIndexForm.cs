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
using Travelling.Lucene;
using Travelling.TravelInterface.Repository;
using Travelling.ViewModel.Travel;

namespace DataSyncBox
{
    public partial class SceneryLuceneIndexForm : BaseAdminForm
    {
        private readonly ISceneryTicketInfoBusinessLogic ticketBusinessLogic;
        public SceneryLuceneIndexForm()
        {
            var kernel = new StandardKernel(new DependencyResolver());
            ticketBusinessLogic = kernel.Get<ISceneryTicketInfoBusinessLogic>();
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(ckRepeatCreate.Checked)
            {
                SceneryTicketSearchLucene.DeleteSceneryLuceneIndex();
                ticketBusinessLogic.InitSceneryInfoLuceneState();
            }

            CheckForIllegalCrossThreadCalls = false;
            btnCreate.Enabled = false;
            Thread myThread = new Thread(HotelDescriptionIndexCreate);
            myThread.IsBackground = true;
            myThread.Start();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SceneryTicketSearchLucene sceneryLucene = new SceneryTicketSearchLucene();
            SceneryQueryInfo query = new SceneryQueryInfo();
            query.PageIndex = 1;
            query.PageSize = 20;
            query.ProvinceId = 2;

            int totalRecords=0;

            sceneryLucene.SceneryLuceneIndexSearch(query, out totalRecords);
        }

        void SetSceneryInfoLuceneIndexProgress(string msg)
        {
            
            pgCreate.Value = 0;
            pgCreate.Maximum = 100;
            for (int i = 0; i < 100; i++)
            {
                pgCreate.Value = i;
                Thread.Sleep(1);
            }


            lblMsg.Text = msg;
        }

        private void HotelDescriptionIndexCreate()
        {
            
            ticketBusinessLogic.SceneryInfoLuceneIndexCreate(SetSceneryInfoLuceneIndexProgress);
        }
    }
}

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
using Travelling.Domain.HotelSyncRecord;
using Travelling.TravelInterface.Repository;

namespace DataSyncBox
{
    public partial class hotelRoomRatePlanForm : BaseAdminForm
    {
        private DateTimePicker dateStartTimePicker = new DateTimePicker();
        private DateTimePicker dateEndTimePicker = new DateTimePicker();
        private Rectangle startDateRectangle;
        

        private readonly IHotelDataSyncBusinssLogic hotelDataSyncBusiness;

        BindingSource bingSource = new BindingSource();

        public hotelRoomRatePlanForm()
        {
            InitializeComponent();
            groupBox1.Text = "酒店价格计划同步记录";

            var kernel = new StandardKernel(new DependencyResolver());
            hotelDataSyncBusiness = kernel.Get<IHotelDataSyncBusinssLogic>();

            DataBind();
            
        }

        private void DataBind()
        {
            //bingSource.DataSource = hotelDataSyncBusiness.GetRoomRatePlanSyncJobLog();
            //this.bindingNavigator1.BindingSource = bingSource;
            //gvSyncLog.AutoGenerateColumns = false;
            //gvSyncLog.DataSource = bingSource;
        }

        private void btnAddSyncLog_Click(object sender, EventArgs e)
        {

        }

        private void hotelRoomRatePlanForm_Load(object sender, EventArgs e)
        {
            gvSyncLog.Controls.Add(dateStartTimePicker);
            dateStartTimePicker.Visible = false;
            dateStartTimePicker.Format = DateTimePickerFormat.Custom;
            dateStartTimePicker.CustomFormat = "yyyy-MM-dd";
            this.gvSyncLog.AutoGenerateColumns = false;
            dateStartTimePicker.TextChanged += new EventHandler(dateStartTimePicker_TextChanged);
        }

        private void dateStartTimePicker_TextChanged(object sender, EventArgs e)
        {
            gvSyncLog.CurrentCell.Value = dateStartTimePicker.Text;
        }

        private void dateEndTimePicker_TextChanged(object sender, EventArgs e)
        {
            gvSyncLog.CurrentCell.Value = dateEndTimePicker.Text;
        }

        private void gvSyncLog_CurrentCellChanged(object sender, EventArgs e)
        {
            
        }

        private void gvSyncLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void gvSyncLog_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewTextBoxCell starttime = ((DataGridViewTextBoxCell)gvSyncLog.Rows[e.RowIndex].Cells["startDate"]);
                if (e.ColumnIndex == 0)
                {
                    startDateRectangle = gvSyncLog.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    //得到所在单元格位置和大小
                    dateStartTimePicker.Size = new Size(startDateRectangle.Width, startDateRectangle.Height);
                    //把单元格大小赋给时间控件
                    dateStartTimePicker.Location = new Point(startDateRectangle.X, startDateRectangle.Y); //把单元格位置赋给时间控件
                    dateStartTimePicker.Visible = true;  //可以显示控件了
                    starttime.Value = DateTime.Now;
                }
                else
                {
                    dateStartTimePicker.Visible = false;
                }

                ///////////////////////////////////
                DataGridViewTextBoxCell endtime = ((DataGridViewTextBoxCell)gvSyncLog.Rows[e.RowIndex].Cells["endDate"]);
                if (e.ColumnIndex == 1)
                {
                    startDateRectangle = gvSyncLog.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    //得到所在单元格位置和大小
                    dateStartTimePicker.Size = new Size(startDateRectangle.Width, startDateRectangle.Height);
                    //把单元格大小赋给时间控件
                    dateStartTimePicker.Location = new Point(startDateRectangle.X, startDateRectangle.Y); //把单元格位置赋给时间控件
                    dateStartTimePicker.Visible = true;  //可以显示控件了
                    endtime.Value = DateTime.Now;
                }
                else
                {
                    dateStartTimePicker.Visible = false;
                }



            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            RoomRatePlanSyncLogEditForm editForm = new RoomRatePlanSyncLogEditForm();
            editForm.ShowDialog();
            DataBind();
        }

        private void gvSyncLog_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (dgv != null)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, dgv.RowHeadersWidth - 4, e.RowBounds.Height);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgv.RowHeadersDefaultCellStyle.Font, rect, dgv.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            int k = this.gvSyncLog.SelectedRows.Count;

            if (this.gvSyncLog.SelectedRows.Count>0)
            {
                MessageBox.Show("dele!!!");
            }
        }
    }
}

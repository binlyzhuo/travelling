namespace DataSyncBox
{
    partial class CtripHotelInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.pgHotelLowestPriceGet = new System.Windows.Forms.ProgressBar();
            this.lblSyncHotelPrice = new System.Windows.Forms.Label();
            this.btnHotelPrices = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pgRoomRatePlan = new System.Windows.Forms.ProgressBar();
            this.lblRoomRatePlan = new System.Windows.Forms.Label();
            this.ckRoomRatePlanRepeat = new System.Windows.Forms.CheckBox();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.btnImportHotelRatePlan = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnStopHotelDescriptionSync = new System.Windows.Forms.Button();
            this.lblHotelDescription = new System.Windows.Forms.Label();
            this.prgHotelDescription = new System.Windows.Forms.ProgressBar();
            this.ckRepeatSyncHotelDescription = new System.Windows.Forms.CheckBox();
            this.hotelDescriptiveBtn = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnStopSyncHotelInfoRecord = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.ctriphotelSyncBtn = new System.Windows.Forms.Button();
            this.ckHotelInfoClearAll = new System.Windows.Forms.CheckBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblAreaMsg = new System.Windows.Forms.Label();
            this.pgCityAreaTypeCode = new System.Windows.Forms.ProgressBar();
            this.btnSettingCodeType = new System.Windows.Forms.Button();
            this.tabPage5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.pgHotelLowestPriceGet);
            this.tabPage5.Controls.Add(this.lblSyncHotelPrice);
            this.tabPage5.Controls.Add(this.btnHotelPrices);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(598, 241);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "酒店最低价格";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // pgHotelLowestPriceGet
            // 
            this.pgHotelLowestPriceGet.Location = new System.Drawing.Point(20, 91);
            this.pgHotelLowestPriceGet.Name = "pgHotelLowestPriceGet";
            this.pgHotelLowestPriceGet.Size = new System.Drawing.Size(300, 23);
            this.pgHotelLowestPriceGet.TabIndex = 11;
            // 
            // lblSyncHotelPrice
            // 
            this.lblSyncHotelPrice.AutoSize = true;
            this.lblSyncHotelPrice.Location = new System.Drawing.Point(181, 47);
            this.lblSyncHotelPrice.Name = "lblSyncHotelPrice";
            this.lblSyncHotelPrice.Size = new System.Drawing.Size(47, 12);
            this.lblSyncHotelPrice.TabIndex = 10;
            this.lblSyncHotelPrice.Text = " 待同步";
            // 
            // btnHotelPrices
            // 
            this.btnHotelPrices.Location = new System.Drawing.Point(20, 42);
            this.btnHotelPrices.Name = "btnHotelPrices";
            this.btnHotelPrices.Size = new System.Drawing.Size(125, 23);
            this.btnHotelPrices.TabIndex = 9;
            this.btnHotelPrices.Text = "酒店最低价格导入";
            this.btnHotelPrices.UseVisualStyleBackColor = true;
            this.btnHotelPrices.Click += new System.EventHandler(this.btnHotelPrices_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pgRoomRatePlan);
            this.tabPage4.Controls.Add(this.lblRoomRatePlan);
            this.tabPage4.Controls.Add(this.ckRoomRatePlanRepeat);
            this.tabPage4.Controls.Add(this.lblEndDate);
            this.tabPage4.Controls.Add(this.lblStartDate);
            this.tabPage4.Controls.Add(this.dateEnd);
            this.tabPage4.Controls.Add(this.dateStart);
            this.tabPage4.Controls.Add(this.btnImportHotelRatePlan);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(598, 241);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "酒店价格计划同步";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pgRoomRatePlan
            // 
            this.pgRoomRatePlan.Location = new System.Drawing.Point(49, 148);
            this.pgRoomRatePlan.Name = "pgRoomRatePlan";
            this.pgRoomRatePlan.Size = new System.Drawing.Size(364, 23);
            this.pgRoomRatePlan.TabIndex = 18;
            // 
            // lblRoomRatePlan
            // 
            this.lblRoomRatePlan.AutoSize = true;
            this.lblRoomRatePlan.Location = new System.Drawing.Point(51, 187);
            this.lblRoomRatePlan.Name = "lblRoomRatePlan";
            this.lblRoomRatePlan.Size = new System.Drawing.Size(41, 12);
            this.lblRoomRatePlan.TabIndex = 17;
            this.lblRoomRatePlan.Text = "待执行";
            // 
            // ckRoomRatePlanRepeat
            // 
            this.ckRoomRatePlanRepeat.AutoSize = true;
            this.ckRoomRatePlanRepeat.Location = new System.Drawing.Point(51, 96);
            this.ckRoomRatePlanRepeat.Name = "ckRoomRatePlanRepeat";
            this.ckRoomRatePlanRepeat.Size = new System.Drawing.Size(120, 16);
            this.ckRoomRatePlanRepeat.TabIndex = 16;
            this.ckRoomRatePlanRepeat.Text = "清空之前同步记录";
            this.ckRoomRatePlanRepeat.UseVisualStyleBackColor = true;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(49, 58);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(53, 12);
            this.lblEndDate.TabIndex = 15;
            this.lblEndDate.Text = "截至日期";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(47, 29);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(53, 12);
            this.lblStartDate.TabIndex = 14;
            this.lblStartDate.Text = "开始日期";
            // 
            // dateEnd
            // 
            this.dateEnd.Location = new System.Drawing.Point(128, 52);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(200, 21);
            this.dateEnd.TabIndex = 13;
            // 
            // dateStart
            // 
            this.dateStart.Location = new System.Drawing.Point(128, 20);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(200, 21);
            this.dateStart.TabIndex = 12;
            // 
            // btnImportHotelRatePlan
            // 
            this.btnImportHotelRatePlan.Location = new System.Drawing.Point(51, 119);
            this.btnImportHotelRatePlan.Name = "btnImportHotelRatePlan";
            this.btnImportHotelRatePlan.Size = new System.Drawing.Size(125, 23);
            this.btnImportHotelRatePlan.TabIndex = 11;
            this.btnImportHotelRatePlan.Text = "导入酒店价格计划";
            this.btnImportHotelRatePlan.UseVisualStyleBackColor = true;
            this.btnImportHotelRatePlan.Click += new System.EventHandler(this.btnImportHotelRatePlan_Click_1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnStopHotelDescriptionSync);
            this.tabPage2.Controls.Add(this.lblHotelDescription);
            this.tabPage2.Controls.Add(this.prgHotelDescription);
            this.tabPage2.Controls.Add(this.ckRepeatSyncHotelDescription);
            this.tabPage2.Controls.Add(this.hotelDescriptiveBtn);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(598, 241);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "酒店信息同步";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnStopHotelDescriptionSync
            // 
            this.btnStopHotelDescriptionSync.Location = new System.Drawing.Point(163, 41);
            this.btnStopHotelDescriptionSync.Name = "btnStopHotelDescriptionSync";
            this.btnStopHotelDescriptionSync.Size = new System.Drawing.Size(101, 23);
            this.btnStopHotelDescriptionSync.TabIndex = 8;
            this.btnStopHotelDescriptionSync.Text = "停止同步";
            this.btnStopHotelDescriptionSync.UseVisualStyleBackColor = true;
            this.btnStopHotelDescriptionSync.Click += new System.EventHandler(this.btnStopHotelDescriptionSync_Click);
            // 
            // lblHotelDescription
            // 
            this.lblHotelDescription.AutoSize = true;
            this.lblHotelDescription.Location = new System.Drawing.Point(18, 132);
            this.lblHotelDescription.Name = "lblHotelDescription";
            this.lblHotelDescription.Size = new System.Drawing.Size(41, 12);
            this.lblHotelDescription.TabIndex = 7;
            this.lblHotelDescription.Text = "待同步";
            // 
            // prgHotelDescription
            // 
            this.prgHotelDescription.Location = new System.Drawing.Point(18, 88);
            this.prgHotelDescription.Name = "prgHotelDescription";
            this.prgHotelDescription.Size = new System.Drawing.Size(357, 23);
            this.prgHotelDescription.TabIndex = 6;
            // 
            // ckRepeatSyncHotelDescription
            // 
            this.ckRepeatSyncHotelDescription.AutoSize = true;
            this.ckRepeatSyncHotelDescription.Location = new System.Drawing.Point(18, 19);
            this.ckRepeatSyncHotelDescription.Name = "ckRepeatSyncHotelDescription";
            this.ckRepeatSyncHotelDescription.Size = new System.Drawing.Size(144, 16);
            this.ckRepeatSyncHotelDescription.TabIndex = 5;
            this.ckRepeatSyncHotelDescription.Text = "重新同步酒店静态信息";
            this.ckRepeatSyncHotelDescription.UseVisualStyleBackColor = true;
            // 
            // hotelDescriptiveBtn
            // 
            this.hotelDescriptiveBtn.Location = new System.Drawing.Point(18, 41);
            this.hotelDescriptiveBtn.Name = "hotelDescriptiveBtn";
            this.hotelDescriptiveBtn.Size = new System.Drawing.Size(125, 23);
            this.hotelDescriptiveBtn.TabIndex = 4;
            this.hotelDescriptiveBtn.Text = "酒店静态数据同步";
            this.hotelDescriptiveBtn.UseVisualStyleBackColor = true;
            this.hotelDescriptiveBtn.Click += new System.EventHandler(this.hotelDescriptiveBtn_Click_1);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnStopSyncHotelInfoRecord);
            this.tabPage1.Controls.Add(this.btnInit);
            this.tabPage1.Controls.Add(this.ctriphotelSyncBtn);
            this.tabPage1.Controls.Add(this.ckHotelInfoClearAll);
            this.tabPage1.Controls.Add(this.lblMsg);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(598, 241);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "酒店记录查询";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnStopSyncHotelInfoRecord
            // 
            this.btnStopSyncHotelInfoRecord.Location = new System.Drawing.Point(163, 80);
            this.btnStopSyncHotelInfoRecord.Name = "btnStopSyncHotelInfoRecord";
            this.btnStopSyncHotelInfoRecord.Size = new System.Drawing.Size(111, 23);
            this.btnStopSyncHotelInfoRecord.TabIndex = 11;
            this.btnStopSyncHotelInfoRecord.Text = "停止同步";
            this.btnStopSyncHotelInfoRecord.UseVisualStyleBackColor = true;
            this.btnStopSyncHotelInfoRecord.Click += new System.EventHandler(this.btnStopSyncHotelInfoRecord_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(22, 16);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(132, 23);
            this.btnInit.TabIndex = 10;
            this.btnInit.Text = "初始化数据";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctriphotelSyncBtn
            // 
            this.ctriphotelSyncBtn.Location = new System.Drawing.Point(22, 81);
            this.ctriphotelSyncBtn.Name = "ctriphotelSyncBtn";
            this.ctriphotelSyncBtn.Size = new System.Drawing.Size(125, 23);
            this.ctriphotelSyncBtn.TabIndex = 0;
            this.ctriphotelSyncBtn.Text = "酒店数据同步";
            this.ctriphotelSyncBtn.UseVisualStyleBackColor = true;
            this.ctriphotelSyncBtn.Click += new System.EventHandler(this.ctriphotelSyncBtn_Click);
            // 
            // ckHotelInfoClearAll
            // 
            this.ckHotelInfoClearAll.AutoSize = true;
            this.ckHotelInfoClearAll.Location = new System.Drawing.Point(22, 59);
            this.ckHotelInfoClearAll.Name = "ckHotelInfoClearAll";
            this.ckHotelInfoClearAll.Size = new System.Drawing.Size(120, 16);
            this.ckHotelInfoClearAll.TabIndex = 9;
            this.ckHotelInfoClearAll.Text = "清空之前同步信息";
            this.ckHotelInfoClearAll.UseVisualStyleBackColor = true;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(20, 170);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(53, 12);
            this.lblMsg.TabIndex = 2;
            this.lblMsg.Text = "开始运行";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(22, 134);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(397, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(606, 267);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblAreaMsg);
            this.tabPage3.Controls.Add(this.pgCityAreaTypeCode);
            this.tabPage3.Controls.Add(this.btnSettingCodeType);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(598, 241);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Text = "城市热点";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblAreaMsg
            // 
            this.lblAreaMsg.AutoSize = true;
            this.lblAreaMsg.Location = new System.Drawing.Point(20, 141);
            this.lblAreaMsg.Name = "lblAreaMsg";
            this.lblAreaMsg.Size = new System.Drawing.Size(41, 12);
            this.lblAreaMsg.TabIndex = 2;
            this.lblAreaMsg.Text = "待同步";
            // 
            // pgCityAreaTypeCode
            // 
            this.pgCityAreaTypeCode.Location = new System.Drawing.Point(22, 96);
            this.pgCityAreaTypeCode.Name = "pgCityAreaTypeCode";
            this.pgCityAreaTypeCode.Size = new System.Drawing.Size(387, 23);
            this.pgCityAreaTypeCode.TabIndex = 1;
            // 
            // btnSettingCodeType
            // 
            this.btnSettingCodeType.Location = new System.Drawing.Point(22, 51);
            this.btnSettingCodeType.Name = "btnSettingCodeType";
            this.btnSettingCodeType.Size = new System.Drawing.Size(120, 23);
            this.btnSettingCodeType.TabIndex = 0;
            this.btnSettingCodeType.Text = "设置区域类型";
            this.btnSettingCodeType.UseVisualStyleBackColor = true;
            this.btnSettingCodeType.Click += new System.EventHandler(this.btnSettingCodeType_Click);
            // 
            // CtripHotelInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 291);
            this.Controls.Add(this.tabControl1);
            this.Name = "CtripHotelInfoForm";
            this.Text = "CtripHotelInfoSync";
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btnHotelPrices;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnImportHotelRatePlan;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button hotelDescriptiveBtn;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button ctriphotelSyncBtn;
        private System.Windows.Forms.CheckBox ckHotelInfoClearAll;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Label lblHotelDescription;
        private System.Windows.Forms.ProgressBar prgHotelDescription;
        private System.Windows.Forms.CheckBox ckRepeatSyncHotelDescription;
        private System.Windows.Forms.CheckBox ckRoomRatePlanRepeat;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.ProgressBar pgRoomRatePlan;
        private System.Windows.Forms.Label lblRoomRatePlan;
        private System.Windows.Forms.Label lblSyncHotelPrice;
        private System.Windows.Forms.Button btnStopHotelDescriptionSync;
        private System.Windows.Forms.Button btnStopSyncHotelInfoRecord;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnSettingCodeType;
        private System.Windows.Forms.Label lblAreaMsg;
        private System.Windows.Forms.ProgressBar pgCityAreaTypeCode;
        private System.Windows.Forms.ProgressBar pgHotelLowestPriceGet;

    }
}
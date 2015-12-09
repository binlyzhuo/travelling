namespace DataSyncBox
{
    partial class zhunaApiDataSyncForm
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
            this.btnImportZhunaCity = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCBDSync = new System.Windows.Forms.Button();
            this.btnHotelRefPoint = new System.Windows.Forms.Button();
            this.btnSchoolSync = new System.Windows.Forms.Button();
            this.btnImportCityLable = new System.Windows.Forms.Button();
            this.syncCtripHotelBrand = new System.Windows.Forms.Button();
            this.syncCtripCityId = new System.Windows.Forms.Button();
            this.btnImportZhunaCityArea = new System.Windows.Forms.Button();
            this.isRepeat = new System.Windows.Forms.CheckBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnImportHotelInfo = new System.Windows.Forms.Button();
            this.btnImportHotelChains = new System.Windows.Forms.Button();
            this.btnCityLableInfoSync = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImportZhunaCity
            // 
            this.btnImportZhunaCity.Location = new System.Drawing.Point(17, 20);
            this.btnImportZhunaCity.Name = "btnImportZhunaCity";
            this.btnImportZhunaCity.Size = new System.Drawing.Size(103, 29);
            this.btnImportZhunaCity.TabIndex = 0;
            this.btnImportZhunaCity.Text = "导入城市信息";
            this.btnImportZhunaCity.UseVisualStyleBackColor = true;
            this.btnImportZhunaCity.Click += new System.EventHandler(this.btnImportZhunaCity_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCityLableInfoSync);
            this.groupBox1.Controls.Add(this.btnCBDSync);
            this.groupBox1.Controls.Add(this.btnHotelRefPoint);
            this.groupBox1.Controls.Add(this.btnSchoolSync);
            this.groupBox1.Controls.Add(this.btnImportCityLable);
            this.groupBox1.Controls.Add(this.syncCtripHotelBrand);
            this.groupBox1.Controls.Add(this.syncCtripCityId);
            this.groupBox1.Controls.Add(this.btnImportZhunaCityArea);
            this.groupBox1.Controls.Add(this.isRepeat);
            this.groupBox1.Controls.Add(this.lblMsg);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.btnImportHotelInfo);
            this.groupBox1.Controls.Add(this.btnImportHotelChains);
            this.groupBox1.Controls.Add(this.btnImportZhunaCity);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 266);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "住哪数据同步";
            // 
            // btnCBDSync
            // 
            this.btnCBDSync.Location = new System.Drawing.Point(387, 92);
            this.btnCBDSync.Name = "btnCBDSync";
            this.btnCBDSync.Size = new System.Drawing.Size(103, 31);
            this.btnCBDSync.TabIndex = 13;
            this.btnCBDSync.Text = "商圈同步";
            this.btnCBDSync.UseVisualStyleBackColor = true;
            this.btnCBDSync.Click += new System.EventHandler(this.btnCBDSync_Click);
            // 
            // btnHotelRefPoint
            // 
            this.btnHotelRefPoint.Location = new System.Drawing.Point(264, 92);
            this.btnHotelRefPoint.Name = "btnHotelRefPoint";
            this.btnHotelRefPoint.Size = new System.Drawing.Size(114, 31);
            this.btnHotelRefPoint.TabIndex = 12;
            this.btnHotelRefPoint.Text = "酒店周边区域";
            this.btnHotelRefPoint.UseVisualStyleBackColor = true;
            this.btnHotelRefPoint.Click += new System.EventHandler(this.btnHotelRefPoint_Click);
            // 
            // btnSchoolSync
            // 
            this.btnSchoolSync.Location = new System.Drawing.Point(143, 92);
            this.btnSchoolSync.Name = "btnSchoolSync";
            this.btnSchoolSync.Size = new System.Drawing.Size(101, 32);
            this.btnSchoolSync.TabIndex = 11;
            this.btnSchoolSync.Text = "学校数据同步";
            this.btnSchoolSync.UseVisualStyleBackColor = true;
            this.btnSchoolSync.Click += new System.EventHandler(this.btnSchoolSync_Click);
            // 
            // btnImportCityLable
            // 
            this.btnImportCityLable.Location = new System.Drawing.Point(387, 58);
            this.btnImportCityLable.Name = "btnImportCityLable";
            this.btnImportCityLable.Size = new System.Drawing.Size(103, 26);
            this.btnImportCityLable.TabIndex = 10;
            this.btnImportCityLable.Text = "导入城市地标";
            this.btnImportCityLable.UseVisualStyleBackColor = true;
            this.btnImportCityLable.Click += new System.EventHandler(this.btnImportCityLable_Click);
            // 
            // syncCtripHotelBrand
            // 
            this.syncCtripHotelBrand.Location = new System.Drawing.Point(264, 58);
            this.syncCtripHotelBrand.Name = "syncCtripHotelBrand";
            this.syncCtripHotelBrand.Size = new System.Drawing.Size(114, 26);
            this.syncCtripHotelBrand.TabIndex = 9;
            this.syncCtripHotelBrand.Text = "同步携程品牌信息";
            this.syncCtripHotelBrand.UseVisualStyleBackColor = true;
            this.syncCtripHotelBrand.Click += new System.EventHandler(this.syncCtripHotelBrand_Click);
            // 
            // syncCtripCityId
            // 
            this.syncCtripCityId.Location = new System.Drawing.Point(380, 21);
            this.syncCtripCityId.Name = "syncCtripCityId";
            this.syncCtripCityId.Size = new System.Drawing.Size(110, 28);
            this.syncCtripCityId.TabIndex = 8;
            this.syncCtripCityId.Text = "同步携程城市信息";
            this.syncCtripCityId.UseVisualStyleBackColor = true;
            this.syncCtripCityId.Click += new System.EventHandler(this.syncCtripCityId_Click);
            // 
            // btnImportZhunaCityArea
            // 
            this.btnImportZhunaCityArea.Location = new System.Drawing.Point(264, 20);
            this.btnImportZhunaCityArea.Name = "btnImportZhunaCityArea";
            this.btnImportZhunaCityArea.Size = new System.Drawing.Size(110, 28);
            this.btnImportZhunaCityArea.TabIndex = 7;
            this.btnImportZhunaCityArea.Text = "导入行政区域";
            this.btnImportZhunaCityArea.UseVisualStyleBackColor = true;
            this.btnImportZhunaCityArea.Click += new System.EventHandler(this.btnImportZhunaCityArea_Click);
            // 
            // isRepeat
            // 
            this.isRepeat.AutoSize = true;
            this.isRepeat.Location = new System.Drawing.Point(17, 70);
            this.isRepeat.Name = "isRepeat";
            this.isRepeat.Size = new System.Drawing.Size(72, 16);
            this.isRepeat.TabIndex = 6;
            this.isRepeat.Text = "删除所有";
            this.isRepeat.UseVisualStyleBackColor = true;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(15, 212);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(41, 12);
            this.lblMsg.TabIndex = 5;
            this.lblMsg.Text = "lblMsg";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(17, 176);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(473, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // btnImportHotelInfo
            // 
            this.btnImportHotelInfo.Location = new System.Drawing.Point(143, 58);
            this.btnImportHotelInfo.Name = "btnImportHotelInfo";
            this.btnImportHotelInfo.Size = new System.Drawing.Size(101, 28);
            this.btnImportHotelInfo.TabIndex = 3;
            this.btnImportHotelInfo.Text = "导入酒店信息";
            this.btnImportHotelInfo.UseVisualStyleBackColor = true;
            this.btnImportHotelInfo.Click += new System.EventHandler(this.btnImportHotelInfo_Click);
            // 
            // btnImportHotelChains
            // 
            this.btnImportHotelChains.Location = new System.Drawing.Point(143, 20);
            this.btnImportHotelChains.Name = "btnImportHotelChains";
            this.btnImportHotelChains.Size = new System.Drawing.Size(97, 28);
            this.btnImportHotelChains.TabIndex = 2;
            this.btnImportHotelChains.Text = "导入酒店品牌";
            this.btnImportHotelChains.UseVisualStyleBackColor = true;
            this.btnImportHotelChains.Click += new System.EventHandler(this.btnImportHotelChains_Click);
            // 
            // btnCityLableInfoSync
            // 
            this.btnCityLableInfoSync.Location = new System.Drawing.Point(143, 131);
            this.btnCityLableInfoSync.Name = "btnCityLableInfoSync";
            this.btnCityLableInfoSync.Size = new System.Drawing.Size(101, 30);
            this.btnCityLableInfoSync.TabIndex = 14;
            this.btnCityLableInfoSync.Text = "城市地标同步";
            this.btnCityLableInfoSync.UseVisualStyleBackColor = true;
            this.btnCityLableInfoSync.Click += new System.EventHandler(this.btnCityLableInfoSync_Click);
            // 
            // zhunaApiDataSyncForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 300);
            this.Controls.Add(this.groupBox1);
            this.Name = "zhunaApiDataSyncForm";
            this.Text = "zhunaApiDataSyncForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImportZhunaCity;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnImportHotelChains;
        private System.Windows.Forms.Button btnImportHotelInfo;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.CheckBox isRepeat;
        private System.Windows.Forms.Button btnImportZhunaCityArea;
        private System.Windows.Forms.Button syncCtripCityId;
        private System.Windows.Forms.Button syncCtripHotelBrand;
        private System.Windows.Forms.Button btnImportCityLable;
        private System.Windows.Forms.Button btnSchoolSync;
        private System.Windows.Forms.Button btnHotelRefPoint;
        private System.Windows.Forms.Button btnCBDSync;
        private System.Windows.Forms.Button btnCityLableInfoSync;
    }
}
namespace DataSyncBox
{
    partial class HotelDataImportOnlineForm
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
            this.importHotelOnlineGP = new System.Windows.Forms.GroupBox();
            this.btnImportHotelMinPrice = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.ImportprogressBar = new System.Windows.Forms.ProgressBar();
            this.btnImportHotelRoomRatePlan = new System.Windows.Forms.Button();
            this.btnImportHotelDescription = new System.Windows.Forms.Button();
            this.btnSyncCityHotelCount = new System.Windows.Forms.Button();
            this.importHotelOnlineGP.SuspendLayout();
            this.SuspendLayout();
            // 
            // importHotelOnlineGP
            // 
            this.importHotelOnlineGP.BackColor = System.Drawing.SystemColors.Control;
            this.importHotelOnlineGP.Controls.Add(this.btnSyncCityHotelCount);
            this.importHotelOnlineGP.Controls.Add(this.btnImportHotelMinPrice);
            this.importHotelOnlineGP.Controls.Add(this.lblMsg);
            this.importHotelOnlineGP.Controls.Add(this.ImportprogressBar);
            this.importHotelOnlineGP.Controls.Add(this.btnImportHotelRoomRatePlan);
            this.importHotelOnlineGP.Controls.Add(this.btnImportHotelDescription);
            this.importHotelOnlineGP.Location = new System.Drawing.Point(13, 13);
            this.importHotelOnlineGP.Name = "importHotelOnlineGP";
            this.importHotelOnlineGP.Size = new System.Drawing.Size(618, 326);
            this.importHotelOnlineGP.TabIndex = 0;
            this.importHotelOnlineGP.TabStop = false;
            this.importHotelOnlineGP.Text = "酒店数据导入";
            // 
            // btnImportHotelMinPrice
            // 
            this.btnImportHotelMinPrice.Location = new System.Drawing.Point(178, 35);
            this.btnImportHotelMinPrice.Name = "btnImportHotelMinPrice";
            this.btnImportHotelMinPrice.Size = new System.Drawing.Size(153, 23);
            this.btnImportHotelMinPrice.TabIndex = 10;
            this.btnImportHotelMinPrice.Text = "导入酒店最低价格信息";
            this.btnImportHotelMinPrice.UseVisualStyleBackColor = true;
            this.btnImportHotelMinPrice.Click += new System.EventHandler(this.btnImportHotelMinPrice_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(4, 182);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(41, 12);
            this.lblMsg.TabIndex = 5;
            this.lblMsg.Text = "待同步";
            // 
            // ImportprogressBar
            // 
            this.ImportprogressBar.Location = new System.Drawing.Point(6, 133);
            this.ImportprogressBar.Name = "ImportprogressBar";
            this.ImportprogressBar.Size = new System.Drawing.Size(428, 23);
            this.ImportprogressBar.TabIndex = 4;
            // 
            // btnImportHotelRoomRatePlan
            // 
            this.btnImportHotelRoomRatePlan.Location = new System.Drawing.Point(6, 78);
            this.btnImportHotelRoomRatePlan.Name = "btnImportHotelRoomRatePlan";
            this.btnImportHotelRoomRatePlan.Size = new System.Drawing.Size(126, 23);
            this.btnImportHotelRoomRatePlan.TabIndex = 2;
            this.btnImportHotelRoomRatePlan.Text = "导入酒店价格计划";
            this.btnImportHotelRoomRatePlan.UseVisualStyleBackColor = true;
            this.btnImportHotelRoomRatePlan.Click += new System.EventHandler(this.btnImportHotelRoomRatePlan_Click);
            // 
            // btnImportHotelDescription
            // 
            this.btnImportHotelDescription.Location = new System.Drawing.Point(6, 35);
            this.btnImportHotelDescription.Name = "btnImportHotelDescription";
            this.btnImportHotelDescription.Size = new System.Drawing.Size(127, 23);
            this.btnImportHotelDescription.TabIndex = 0;
            this.btnImportHotelDescription.Text = "导入酒店静态信息";
            this.btnImportHotelDescription.UseVisualStyleBackColor = true;
            this.btnImportHotelDescription.Click += new System.EventHandler(this.btnImportHotelDescription_Click);
            // 
            // btnSyncCityHotelCount
            // 
            this.btnSyncCityHotelCount.Location = new System.Drawing.Point(178, 78);
            this.btnSyncCityHotelCount.Name = "btnSyncCityHotelCount";
            this.btnSyncCityHotelCount.Size = new System.Drawing.Size(153, 23);
            this.btnSyncCityHotelCount.TabIndex = 11;
            this.btnSyncCityHotelCount.Text = "导入城市酒店查询信息";
            this.btnSyncCityHotelCount.UseVisualStyleBackColor = true;
            this.btnSyncCityHotelCount.Click += new System.EventHandler(this.btnSyncCityHotelCount_Click);
            // 
            // HotelDataImportOnlineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 351);
            this.Controls.Add(this.importHotelOnlineGP);
            this.Name = "HotelDataImportOnlineForm";
            this.Text = "HotelDataImportOnlineForm";
            this.importHotelOnlineGP.ResumeLayout(false);
            this.importHotelOnlineGP.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox importHotelOnlineGP;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.ProgressBar ImportprogressBar;
        private System.Windows.Forms.Button btnImportHotelRoomRatePlan;
        private System.Windows.Forms.Button btnImportHotelDescription;
        private System.Windows.Forms.Button btnImportHotelMinPrice;
        private System.Windows.Forms.Button btnSyncCityHotelCount;

    }
}
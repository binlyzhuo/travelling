namespace DataSyncBox
{
    partial class HotelDataForm
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
            this.hotelDataConfirmGBox = new System.Windows.Forms.GroupBox();
            this.btnSettingCitydate = new System.Windows.Forms.Button();
            this.settingLocationData = new System.Windows.Forms.Button();
            this.settingBrandData = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.hotelDataConfirmGBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // hotelDataConfirmGBox
            // 
            this.hotelDataConfirmGBox.Controls.Add(this.lblMsg);
            this.hotelDataConfirmGBox.Controls.Add(this.settingBrandData);
            this.hotelDataConfirmGBox.Controls.Add(this.settingLocationData);
            this.hotelDataConfirmGBox.Controls.Add(this.btnSettingCitydate);
            this.hotelDataConfirmGBox.Location = new System.Drawing.Point(13, 13);
            this.hotelDataConfirmGBox.Name = "hotelDataConfirmGBox";
            this.hotelDataConfirmGBox.Size = new System.Drawing.Size(465, 271);
            this.hotelDataConfirmGBox.TabIndex = 0;
            this.hotelDataConfirmGBox.TabStop = false;
            this.hotelDataConfirmGBox.Text = "酒店数据整合";
            // 
            // btnSettingCitydate
            // 
            this.btnSettingCitydate.Location = new System.Drawing.Point(6, 20);
            this.btnSettingCitydate.Name = "btnSettingCitydate";
            this.btnSettingCitydate.Size = new System.Drawing.Size(123, 23);
            this.btnSettingCitydate.TabIndex = 0;
            this.btnSettingCitydate.Text = "整合城市数据";
            this.btnSettingCitydate.UseVisualStyleBackColor = true;
            // 
            // settingLocationData
            // 
            this.settingLocationData.Location = new System.Drawing.Point(148, 20);
            this.settingLocationData.Name = "settingLocationData";
            this.settingLocationData.Size = new System.Drawing.Size(123, 23);
            this.settingLocationData.TabIndex = 1;
            this.settingLocationData.Text = "整合行政区域数据";
            this.settingLocationData.UseVisualStyleBackColor = true;
            this.settingLocationData.Click += new System.EventHandler(this.settingLocationData_Click);
            // 
            // settingBrandData
            // 
            this.settingBrandData.Location = new System.Drawing.Point(291, 19);
            this.settingBrandData.Name = "settingBrandData";
            this.settingBrandData.Size = new System.Drawing.Size(111, 23);
            this.settingBrandData.TabIndex = 2;
            this.settingBrandData.Text = "设置酒店品牌数据";
            this.settingBrandData.UseVisualStyleBackColor = true;
            this.settingBrandData.Click += new System.EventHandler(this.settingBrandData_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(6, 59);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(41, 12);
            this.lblMsg.TabIndex = 3;
            this.lblMsg.Text = "未执行";
            // 
            // HotelDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 296);
            this.Controls.Add(this.hotelDataConfirmGBox);
            this.Name = "HotelDataForm";
            this.Text = "HotelDataForm";
            this.hotelDataConfirmGBox.ResumeLayout(false);
            this.hotelDataConfirmGBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox hotelDataConfirmGBox;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button settingBrandData;
        private System.Windows.Forms.Button settingLocationData;
        private System.Windows.Forms.Button btnSettingCitydate;
    }
}
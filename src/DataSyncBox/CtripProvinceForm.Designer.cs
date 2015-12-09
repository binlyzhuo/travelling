namespace DataSyncBox
{
    partial class CtripProvinceForm
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
            this.btnSyncProvince = new System.Windows.Forms.Button();
            this.btnHotelBrand = new System.Windows.Forms.Button();
            this.gbCitySync = new System.Windows.Forms.GroupBox();
            this.lblCityMsg = new System.Windows.Forms.Label();
            this.gbHotelBrand = new System.Windows.Forms.GroupBox();
            this.lblThemeMsg = new System.Windows.Forms.Label();
            this.gbCitySync.SuspendLayout();
            this.gbHotelBrand.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSyncProvince
            // 
            this.btnSyncProvince.Location = new System.Drawing.Point(6, 36);
            this.btnSyncProvince.Name = "btnSyncProvince";
            this.btnSyncProvince.Size = new System.Drawing.Size(101, 23);
            this.btnSyncProvince.TabIndex = 0;
            this.btnSyncProvince.Text = "同步携程数据";
            this.btnSyncProvince.UseVisualStyleBackColor = true;
            this.btnSyncProvince.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnHotelBrand
            // 
            this.btnHotelBrand.Location = new System.Drawing.Point(6, 36);
            this.btnHotelBrand.Name = "btnHotelBrand";
            this.btnHotelBrand.Size = new System.Drawing.Size(109, 23);
            this.btnHotelBrand.TabIndex = 3;
            this.btnHotelBrand.Text = "酒店品牌数据";
            this.btnHotelBrand.UseVisualStyleBackColor = true;
            this.btnHotelBrand.Click += new System.EventHandler(this.btnHotelBrand_Click);
            // 
            // gbCitySync
            // 
            this.gbCitySync.Controls.Add(this.lblCityMsg);
            this.gbCitySync.Controls.Add(this.btnSyncProvince);
            this.gbCitySync.Location = new System.Drawing.Point(13, 42);
            this.gbCitySync.Name = "gbCitySync";
            this.gbCitySync.Size = new System.Drawing.Size(200, 117);
            this.gbCitySync.TabIndex = 4;
            this.gbCitySync.TabStop = false;
            this.gbCitySync.Text = "酒店城市信息";
            // 
            // lblCityMsg
            // 
            this.lblCityMsg.AutoSize = true;
            this.lblCityMsg.Location = new System.Drawing.Point(6, 77);
            this.lblCityMsg.Name = "lblCityMsg";
            this.lblCityMsg.Size = new System.Drawing.Size(41, 12);
            this.lblCityMsg.TabIndex = 2;
            this.lblCityMsg.Text = "未执行";
            // 
            // gbHotelBrand
            // 
            this.gbHotelBrand.Controls.Add(this.lblThemeMsg);
            this.gbHotelBrand.Controls.Add(this.btnHotelBrand);
            this.gbHotelBrand.Location = new System.Drawing.Point(230, 42);
            this.gbHotelBrand.Name = "gbHotelBrand";
            this.gbHotelBrand.Size = new System.Drawing.Size(200, 117);
            this.gbHotelBrand.TabIndex = 5;
            this.gbHotelBrand.TabStop = false;
            this.gbHotelBrand.Text = "酒店品牌";
            // 
            // lblThemeMsg
            // 
            this.lblThemeMsg.AutoSize = true;
            this.lblThemeMsg.Location = new System.Drawing.Point(7, 77);
            this.lblThemeMsg.Name = "lblThemeMsg";
            this.lblThemeMsg.Size = new System.Drawing.Size(41, 12);
            this.lblThemeMsg.TabIndex = 5;
            this.lblThemeMsg.Text = "未执行";
            // 
            // CtripProvinceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 261);
            this.Controls.Add(this.gbHotelBrand);
            this.Controls.Add(this.gbCitySync);
            this.Name = "CtripProvinceForm";
            this.Text = "CtripProvinceForm";
            this.gbCitySync.ResumeLayout(false);
            this.gbCitySync.PerformLayout();
            this.gbHotelBrand.ResumeLayout(false);
            this.gbHotelBrand.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSyncProvince;
        private System.Windows.Forms.Button btnHotelBrand;
        private System.Windows.Forms.GroupBox gbCitySync;
        private System.Windows.Forms.Label lblCityMsg;
        private System.Windows.Forms.GroupBox gbHotelBrand;
        private System.Windows.Forms.Label lblThemeMsg;
    }
}
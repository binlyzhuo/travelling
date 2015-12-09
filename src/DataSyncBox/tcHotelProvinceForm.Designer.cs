namespace DataSyncBox
{
    partial class tcHotelProvinceForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnImportProvince = new System.Windows.Forms.Button();
            this.btnImportHotelList = new System.Windows.Forms.Button();
            this.btnImportHotelBrand = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnImportHotelBrand);
            this.groupBox1.Controls.Add(this.btnImportHotelList);
            this.groupBox1.Controls.Add(this.lblMsg);
            this.groupBox1.Controls.Add(this.btnImportProvince);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "同程酒店静态资源";
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(6, 157);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(41, 12);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "待处理";
            // 
            // btnImportProvince
            // 
            this.btnImportProvince.Location = new System.Drawing.Point(6, 42);
            this.btnImportProvince.Name = "btnImportProvince";
            this.btnImportProvince.Size = new System.Drawing.Size(162, 23);
            this.btnImportProvince.TabIndex = 0;
            this.btnImportProvince.Text = "导入省份信息";
            this.btnImportProvince.UseVisualStyleBackColor = true;
            this.btnImportProvince.Click += new System.EventHandler(this.btnImportProvince_Click);
            // 
            // btnImportHotelList
            // 
            this.btnImportHotelList.Location = new System.Drawing.Point(6, 83);
            this.btnImportHotelList.Name = "btnImportHotelList";
            this.btnImportHotelList.Size = new System.Drawing.Size(162, 23);
            this.btnImportHotelList.TabIndex = 2;
            this.btnImportHotelList.Text = "导入酒店信息";
            this.btnImportHotelList.UseVisualStyleBackColor = true;
            this.btnImportHotelList.Click += new System.EventHandler(this.btnImportHotelList_Click);
            // 
            // btnImportHotelBrand
            // 
            this.btnImportHotelBrand.Location = new System.Drawing.Point(8, 124);
            this.btnImportHotelBrand.Name = "btnImportHotelBrand";
            this.btnImportHotelBrand.Size = new System.Drawing.Size(160, 23);
            this.btnImportHotelBrand.TabIndex = 3;
            this.btnImportHotelBrand.Text = "导入酒店品牌信息";
            this.btnImportHotelBrand.UseVisualStyleBackColor = true;
            this.btnImportHotelBrand.Click += new System.EventHandler(this.btnImportHotelBrand_Click);
            // 
            // tcHotelProvinceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 261);
            this.Controls.Add(this.groupBox1);
            this.Name = "tcHotelProvinceForm";
            this.Text = "tcHotelProvinceForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnImportProvince;
        private System.Windows.Forms.Button btnImportHotelList;
        private System.Windows.Forms.Button btnImportHotelBrand;

    }
}
namespace DataSyncBox
{
    partial class HotelTableSplitForm
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblHotelMsg = new System.Windows.Forms.Label();
            this.pgHotelRoomRateTables = new System.Windows.Forms.ProgressBar();
            this.btnCreateCityHotelPrice = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblSyncMsg = new System.Windows.Forms.Label();
            this.pgSyncDatabase = new System.Windows.Forms.ProgressBar();
            this.btnSplitSyncDatabase = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblHotelMsg);
            this.tabPage2.Controls.Add(this.pgHotelRoomRateTables);
            this.tabPage2.Controls.Add(this.btnCreateCityHotelPrice);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(484, 273);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "酒店正式库价格计划表拆分";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblHotelMsg
            // 
            this.lblHotelMsg.AutoSize = true;
            this.lblHotelMsg.Location = new System.Drawing.Point(196, 52);
            this.lblHotelMsg.Name = "lblHotelMsg";
            this.lblHotelMsg.Size = new System.Drawing.Size(41, 12);
            this.lblHotelMsg.TabIndex = 7;
            this.lblHotelMsg.Text = "待拆分";
            // 
            // pgHotelRoomRateTables
            // 
            this.pgHotelRoomRateTables.Location = new System.Drawing.Point(31, 90);
            this.pgHotelRoomRateTables.Name = "pgHotelRoomRateTables";
            this.pgHotelRoomRateTables.Size = new System.Drawing.Size(340, 23);
            this.pgHotelRoomRateTables.TabIndex = 6;
            // 
            // btnCreateCityHotelPrice
            // 
            this.btnCreateCityHotelPrice.Location = new System.Drawing.Point(31, 47);
            this.btnCreateCityHotelPrice.Name = "btnCreateCityHotelPrice";
            this.btnCreateCityHotelPrice.Size = new System.Drawing.Size(159, 23);
            this.btnCreateCityHotelPrice.TabIndex = 1;
            this.btnCreateCityHotelPrice.Text = "开始创建酒店价格表";
            this.btnCreateCityHotelPrice.UseVisualStyleBackColor = true;
            this.btnCreateCityHotelPrice.Click += new System.EventHandler(this.btnCreateCityHotelPrice_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblSyncMsg);
            this.tabPage1.Controls.Add(this.pgSyncDatabase);
            this.tabPage1.Controls.Add(this.btnSplitSyncDatabase);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(484, 273);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "同步库价格计划表拆分";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblSyncMsg
            // 
            this.lblSyncMsg.AutoSize = true;
            this.lblSyncMsg.Location = new System.Drawing.Point(151, 45);
            this.lblSyncMsg.Name = "lblSyncMsg";
            this.lblSyncMsg.Size = new System.Drawing.Size(41, 12);
            this.lblSyncMsg.TabIndex = 3;
            this.lblSyncMsg.Text = "待创建";
            // 
            // pgSyncDatabase
            // 
            this.pgSyncDatabase.Location = new System.Drawing.Point(17, 95);
            this.pgSyncDatabase.Name = "pgSyncDatabase";
            this.pgSyncDatabase.Size = new System.Drawing.Size(420, 23);
            this.pgSyncDatabase.TabIndex = 2;
            // 
            // btnSplitSyncDatabase
            // 
            this.btnSplitSyncDatabase.Location = new System.Drawing.Point(17, 40);
            this.btnSplitSyncDatabase.Name = "btnSplitSyncDatabase";
            this.btnSplitSyncDatabase.Size = new System.Drawing.Size(128, 23);
            this.btnSplitSyncDatabase.TabIndex = 0;
            this.btnSplitSyncDatabase.Text = "创建";
            this.btnSplitSyncDatabase.UseVisualStyleBackColor = true;
            this.btnSplitSyncDatabase.Click += new System.EventHandler(this.btnSplitSyncDatabase_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(14, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(492, 299);
            this.tabControl1.TabIndex = 5;
            // 
            // HotelTableSplitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 305);
            this.Controls.Add(this.tabControl1);
            this.Name = "HotelTableSplitForm";
            this.Text = "HotelTableSplitForm";
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ProgressBar pgHotelRoomRateTables;
        private System.Windows.Forms.Button btnCreateCityHotelPrice;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ProgressBar pgSyncDatabase;
        private System.Windows.Forms.Button btnSplitSyncDatabase;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label lblSyncMsg;
        private System.Windows.Forms.Label lblHotelMsg;

    }
}
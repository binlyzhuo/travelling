namespace DataSyncBox
{
    partial class SceneryInfoForm
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
            this.gpSceneryInfoSync = new System.Windows.Forms.GroupBox();
            this.btnSyncSceneryImg = new System.Windows.Forms.Button();
            this.btnInitSyncRecord = new System.Windows.Forms.Button();
            this.ckIsRepeat = new System.Windows.Forms.CheckBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnSceneryDetail = new System.Windows.Forms.Button();
            this.btnSceneryTicketPriceSync = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnSyncScenerySearchInfo = new System.Windows.Forms.Button();
            this.gpSceneryInfoSync.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpSceneryInfoSync
            // 
            this.gpSceneryInfoSync.Controls.Add(this.btnSyncSceneryImg);
            this.gpSceneryInfoSync.Controls.Add(this.btnInitSyncRecord);
            this.gpSceneryInfoSync.Controls.Add(this.ckIsRepeat);
            this.gpSceneryInfoSync.Controls.Add(this.lblMsg);
            this.gpSceneryInfoSync.Controls.Add(this.btnSceneryDetail);
            this.gpSceneryInfoSync.Controls.Add(this.btnSceneryTicketPriceSync);
            this.gpSceneryInfoSync.Controls.Add(this.progressBar1);
            this.gpSceneryInfoSync.Controls.Add(this.btnSyncScenerySearchInfo);
            this.gpSceneryInfoSync.Location = new System.Drawing.Point(12, 12);
            this.gpSceneryInfoSync.Name = "gpSceneryInfoSync";
            this.gpSceneryInfoSync.Size = new System.Drawing.Size(676, 359);
            this.gpSceneryInfoSync.TabIndex = 5;
            this.gpSceneryInfoSync.TabStop = false;
            this.gpSceneryInfoSync.Text = "景区信息同步";
            // 
            // btnSyncSceneryImg
            // 
            this.btnSyncSceneryImg.Location = new System.Drawing.Point(321, 21);
            this.btnSyncSceneryImg.Name = "btnSyncSceneryImg";
            this.btnSyncSceneryImg.Size = new System.Drawing.Size(128, 23);
            this.btnSyncSceneryImg.TabIndex = 7;
            this.btnSyncSceneryImg.Text = "同步景区图片信息";
            this.btnSyncSceneryImg.UseVisualStyleBackColor = true;
            this.btnSyncSceneryImg.Click += new System.EventHandler(this.btnSyncSceneryImg_Click);
            // 
            // btnInitSyncRecord
            // 
            this.btnInitSyncRecord.Location = new System.Drawing.Point(151, 20);
            this.btnInitSyncRecord.Name = "btnInitSyncRecord";
            this.btnInitSyncRecord.Size = new System.Drawing.Size(147, 23);
            this.btnInitSyncRecord.TabIndex = 6;
            this.btnInitSyncRecord.Text = "初始化城市记录";
            this.btnInitSyncRecord.UseVisualStyleBackColor = true;
            this.btnInitSyncRecord.Click += new System.EventHandler(this.btnInitSyncRecord_Click);
            // 
            // ckIsRepeat
            // 
            this.ckIsRepeat.AutoSize = true;
            this.ckIsRepeat.Location = new System.Drawing.Point(46, 20);
            this.ckIsRepeat.Name = "ckIsRepeat";
            this.ckIsRepeat.Size = new System.Drawing.Size(72, 16);
            this.ckIsRepeat.TabIndex = 5;
            this.ckIsRepeat.Text = "重新同步";
            this.ckIsRepeat.UseVisualStyleBackColor = true;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(44, 190);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(53, 12);
            this.lblMsg.TabIndex = 2;
            this.lblMsg.Text = "开始同步";
            // 
            // btnSceneryDetail
            // 
            this.btnSceneryDetail.Location = new System.Drawing.Point(151, 80);
            this.btnSceneryDetail.Name = "btnSceneryDetail";
            this.btnSceneryDetail.Size = new System.Drawing.Size(147, 23);
            this.btnSceneryDetail.TabIndex = 3;
            this.btnSceneryDetail.Text = "同步景区详细信息";
            this.btnSceneryDetail.UseVisualStyleBackColor = true;
            this.btnSceneryDetail.Click += new System.EventHandler(this.btnSceneryDetail_Click);
            // 
            // btnSceneryTicketPriceSync
            // 
            this.btnSceneryTicketPriceSync.Location = new System.Drawing.Point(151, 109);
            this.btnSceneryTicketPriceSync.Name = "btnSceneryTicketPriceSync";
            this.btnSceneryTicketPriceSync.Size = new System.Drawing.Size(147, 23);
            this.btnSceneryTicketPriceSync.TabIndex = 4;
            this.btnSceneryTicketPriceSync.Text = "同步景区价格计划";
            this.btnSceneryTicketPriceSync.UseVisualStyleBackColor = true;
            this.btnSceneryTicketPriceSync.Click += new System.EventHandler(this.btnSceneryTicketPriceSync_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(46, 148);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(315, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // btnSyncScenerySearchInfo
            // 
            this.btnSyncScenerySearchInfo.Location = new System.Drawing.Point(151, 49);
            this.btnSyncScenerySearchInfo.Name = "btnSyncScenerySearchInfo";
            this.btnSyncScenerySearchInfo.Size = new System.Drawing.Size(147, 23);
            this.btnSyncScenerySearchInfo.TabIndex = 0;
            this.btnSyncScenerySearchInfo.Text = "同步景区查询数据";
            this.btnSyncScenerySearchInfo.UseVisualStyleBackColor = true;
            this.btnSyncScenerySearchInfo.Click += new System.EventHandler(this.btnSyncScenery_Click);
            // 
            // SceneryInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 355);
            this.Controls.Add(this.gpSceneryInfoSync);
            this.Name = "SceneryInfoForm";
            this.Text = "SceneryInfoForm";
            this.gpSceneryInfoSync.ResumeLayout(false);
            this.gpSceneryInfoSync.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSyncScenerySearchInfo;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Button btnSceneryDetail;
        private System.Windows.Forms.Button btnSceneryTicketPriceSync;
        private System.Windows.Forms.GroupBox gpSceneryInfoSync;
        private System.Windows.Forms.CheckBox ckIsRepeat;
        private System.Windows.Forms.Button btnInitSyncRecord;
        private System.Windows.Forms.Button btnSyncSceneryImg;
    }
}
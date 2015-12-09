namespace DataSyncBox
{
    partial class SceneryTicketTestForm
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
            this.txtSceneryID = new System.Windows.Forms.TextBox();
            this.btnSceneryTrafficInfo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btmGetSceneryImgs = new System.Windows.Forms.Button();
            this.btnGetNearbyScenery = new System.Windows.Forms.Button();
            this.btnGetSceneryPrice = new System.Windows.Forms.Button();
            this.btnGetSceneryDetail = new System.Windows.Forms.Button();
            this.txtCityID = new System.Windows.Forms.TextBox();
            this.lblCityId = new System.Windows.Forms.Label();
            this.btnGetSceneryByCityID = new System.Windows.Forms.Button();
            this.btnGetCaluar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSceneryID
            // 
            this.txtSceneryID.Location = new System.Drawing.Point(84, 22);
            this.txtSceneryID.Name = "txtSceneryID";
            this.txtSceneryID.Size = new System.Drawing.Size(100, 21);
            this.txtSceneryID.TabIndex = 0;
            // 
            // btnSceneryTrafficInfo
            // 
            this.btnSceneryTrafficInfo.Location = new System.Drawing.Point(221, 22);
            this.btnSceneryTrafficInfo.Name = "btnSceneryTrafficInfo";
            this.btnSceneryTrafficInfo.Size = new System.Drawing.Size(141, 23);
            this.btnSceneryTrafficInfo.TabIndex = 1;
            this.btnSceneryTrafficInfo.Text = "景点交通指南信息";
            this.btnSceneryTrafficInfo.UseVisualStyleBackColor = true;
            this.btnSceneryTrafficInfo.Click += new System.EventHandler(this.btnSceneryTrafficInfo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "景区ID";
            // 
            // btmGetSceneryImgs
            // 
            this.btmGetSceneryImgs.Location = new System.Drawing.Point(221, 52);
            this.btmGetSceneryImgs.Name = "btmGetSceneryImgs";
            this.btmGetSceneryImgs.Size = new System.Drawing.Size(141, 23);
            this.btmGetSceneryImgs.TabIndex = 3;
            this.btmGetSceneryImgs.Text = "获取景区图片信息";
            this.btmGetSceneryImgs.UseVisualStyleBackColor = true;
            this.btmGetSceneryImgs.Click += new System.EventHandler(this.btmGetSceneryImgs_Click);
            // 
            // btnGetNearbyScenery
            // 
            this.btnGetNearbyScenery.Location = new System.Drawing.Point(221, 82);
            this.btnGetNearbyScenery.Name = "btnGetNearbyScenery";
            this.btnGetNearbyScenery.Size = new System.Drawing.Size(141, 23);
            this.btnGetNearbyScenery.TabIndex = 4;
            this.btnGetNearbyScenery.Text = "获取周边景点";
            this.btnGetNearbyScenery.UseVisualStyleBackColor = true;
            this.btnGetNearbyScenery.Click += new System.EventHandler(this.btnGetNearbyScenery_Click);
            // 
            // btnGetSceneryPrice
            // 
            this.btnGetSceneryPrice.Location = new System.Drawing.Point(221, 111);
            this.btnGetSceneryPrice.Name = "btnGetSceneryPrice";
            this.btnGetSceneryPrice.Size = new System.Drawing.Size(141, 23);
            this.btnGetSceneryPrice.TabIndex = 5;
            this.btnGetSceneryPrice.Text = "获取景区价格";
            this.btnGetSceneryPrice.UseVisualStyleBackColor = true;
            this.btnGetSceneryPrice.Click += new System.EventHandler(this.btnGetSceneryPrice_Click);
            // 
            // btnGetSceneryDetail
            // 
            this.btnGetSceneryDetail.Location = new System.Drawing.Point(221, 141);
            this.btnGetSceneryDetail.Name = "btnGetSceneryDetail";
            this.btnGetSceneryDetail.Size = new System.Drawing.Size(141, 23);
            this.btnGetSceneryDetail.TabIndex = 6;
            this.btnGetSceneryDetail.Text = "获取景区详细信息";
            this.btnGetSceneryDetail.UseVisualStyleBackColor = true;
            this.btnGetSceneryDetail.Click += new System.EventHandler(this.btnGetSceneryDetail_Click);
            // 
            // txtCityID
            // 
            this.txtCityID.Location = new System.Drawing.Point(84, 67);
            this.txtCityID.Name = "txtCityID";
            this.txtCityID.Size = new System.Drawing.Size(100, 21);
            this.txtCityID.TabIndex = 7;
            // 
            // lblCityId
            // 
            this.lblCityId.AutoSize = true;
            this.lblCityId.Location = new System.Drawing.Point(26, 76);
            this.lblCityId.Name = "lblCityId";
            this.lblCityId.Size = new System.Drawing.Size(41, 12);
            this.lblCityId.TabIndex = 8;
            this.lblCityId.Text = "城市ID";
            // 
            // btnGetSceneryByCityID
            // 
            this.btnGetSceneryByCityID.Location = new System.Drawing.Point(221, 171);
            this.btnGetSceneryByCityID.Name = "btnGetSceneryByCityID";
            this.btnGetSceneryByCityID.Size = new System.Drawing.Size(141, 23);
            this.btnGetSceneryByCityID.TabIndex = 9;
            this.btnGetSceneryByCityID.Text = "获取景区信息列表";
            this.btnGetSceneryByCityID.UseVisualStyleBackColor = true;
            this.btnGetSceneryByCityID.Click += new System.EventHandler(this.btnGetSceneryByCityID_Click);
            // 
            // btnGetCaluar
            // 
            this.btnGetCaluar.Location = new System.Drawing.Point(221, 201);
            this.btnGetCaluar.Name = "btnGetCaluar";
            this.btnGetCaluar.Size = new System.Drawing.Size(141, 23);
            this.btnGetCaluar.TabIndex = 10;
            this.btnGetCaluar.Text = "获取价格日历";
            this.btnGetCaluar.UseVisualStyleBackColor = true;
            this.btnGetCaluar.Click += new System.EventHandler(this.btnGetCaluar_Click);
            // 
            // SceneryTicketTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 295);
            this.Controls.Add(this.btnGetCaluar);
            this.Controls.Add(this.btnGetSceneryByCityID);
            this.Controls.Add(this.lblCityId);
            this.Controls.Add(this.txtCityID);
            this.Controls.Add(this.btnGetSceneryDetail);
            this.Controls.Add(this.btnGetSceneryPrice);
            this.Controls.Add(this.btnGetNearbyScenery);
            this.Controls.Add(this.btmGetSceneryImgs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSceneryTrafficInfo);
            this.Controls.Add(this.txtSceneryID);
            this.Name = "SceneryTicketTestForm";
            this.Text = "SceneryTicketTestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSceneryID;
        private System.Windows.Forms.Button btnSceneryTrafficInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btmGetSceneryImgs;
        private System.Windows.Forms.Button btnGetNearbyScenery;
        private System.Windows.Forms.Button btnGetSceneryPrice;
        private System.Windows.Forms.Button btnGetSceneryDetail;
        private System.Windows.Forms.TextBox txtCityID;
        private System.Windows.Forms.Label lblCityId;
        private System.Windows.Forms.Button btnGetSceneryByCityID;
        private System.Windows.Forms.Button btnGetCaluar;
    }
}
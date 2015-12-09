namespace DataSyncBox
{
    partial class TicketStaticInfoForm
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
            this.btnImportTicketData = new System.Windows.Forms.Button();
            this.btnImportSceneryTheme = new System.Windows.Forms.Button();
            this.gBoxCityInfo = new System.Windows.Forms.GroupBox();
            this.gBoxSceneryTheme = new System.Windows.Forms.GroupBox();
            this.lblCityMsg = new System.Windows.Forms.Label();
            this.lblThemeMsg = new System.Windows.Forms.Label();
            this.gBoxCityInfo.SuspendLayout();
            this.gBoxSceneryTheme.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImportTicketData
            // 
            this.btnImportTicketData.Location = new System.Drawing.Point(15, 29);
            this.btnImportTicketData.Name = "btnImportTicketData";
            this.btnImportTicketData.Size = new System.Drawing.Size(123, 23);
            this.btnImportTicketData.TabIndex = 0;
            this.btnImportTicketData.Text = " 导入城市信息";
            this.btnImportTicketData.UseVisualStyleBackColor = true;
            this.btnImportTicketData.Click += new System.EventHandler(this.btnImportTicketData_Click);
            // 
            // btnImportSceneryTheme
            // 
            this.btnImportSceneryTheme.Location = new System.Drawing.Point(30, 29);
            this.btnImportSceneryTheme.Name = "btnImportSceneryTheme";
            this.btnImportSceneryTheme.Size = new System.Drawing.Size(123, 23);
            this.btnImportSceneryTheme.TabIndex = 1;
            this.btnImportSceneryTheme.Text = "导入景区主题";
            this.btnImportSceneryTheme.UseVisualStyleBackColor = true;
            this.btnImportSceneryTheme.Click += new System.EventHandler(this.btnImportSceneryTheme_Click);
            // 
            // gBoxCityInfo
            // 
            this.gBoxCityInfo.Controls.Add(this.lblCityMsg);
            this.gBoxCityInfo.Controls.Add(this.btnImportTicketData);
            this.gBoxCityInfo.Location = new System.Drawing.Point(12, 58);
            this.gBoxCityInfo.Name = "gBoxCityInfo";
            this.gBoxCityInfo.Size = new System.Drawing.Size(200, 100);
            this.gBoxCityInfo.TabIndex = 3;
            this.gBoxCityInfo.TabStop = false;
            this.gBoxCityInfo.Text = "景区城市信息";
            // 
            // gBoxSceneryTheme
            // 
            this.gBoxSceneryTheme.Controls.Add(this.lblThemeMsg);
            this.gBoxSceneryTheme.Controls.Add(this.btnImportSceneryTheme);
            this.gBoxSceneryTheme.Location = new System.Drawing.Point(231, 58);
            this.gBoxSceneryTheme.Name = "gBoxSceneryTheme";
            this.gBoxSceneryTheme.Size = new System.Drawing.Size(200, 100);
            this.gBoxSceneryTheme.TabIndex = 4;
            this.gBoxSceneryTheme.TabStop = false;
            this.gBoxSceneryTheme.Text = "景区主题";
            // 
            // lblCityMsg
            // 
            this.lblCityMsg.AutoSize = true;
            this.lblCityMsg.Location = new System.Drawing.Point(13, 67);
            this.lblCityMsg.Name = "lblCityMsg";
            this.lblCityMsg.Size = new System.Drawing.Size(41, 12);
            this.lblCityMsg.TabIndex = 1;
            this.lblCityMsg.Text = "未执行";
            // 
            // lblThemeMsg
            // 
            this.lblThemeMsg.AutoSize = true;
            this.lblThemeMsg.Location = new System.Drawing.Point(30, 67);
            this.lblThemeMsg.Name = "lblThemeMsg";
            this.lblThemeMsg.Size = new System.Drawing.Size(41, 12);
            this.lblThemeMsg.TabIndex = 2;
            this.lblThemeMsg.Text = "未执行";
            // 
            // TicketStaticInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 261);
            this.Controls.Add(this.gBoxSceneryTheme);
            this.Controls.Add(this.gBoxCityInfo);
            this.Name = "TicketStaticInfoForm";
            this.Text = "TicketStaticInfoForm";
            this.Load += new System.EventHandler(this.TicketStaticInfoForm_Load);
            this.gBoxCityInfo.ResumeLayout(false);
            this.gBoxCityInfo.PerformLayout();
            this.gBoxSceneryTheme.ResumeLayout(false);
            this.gBoxSceneryTheme.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImportTicketData;
        private System.Windows.Forms.Button btnImportSceneryTheme;
        private System.Windows.Forms.GroupBox gBoxCityInfo;
        private System.Windows.Forms.Label lblCityMsg;
        private System.Windows.Forms.GroupBox gBoxSceneryTheme;
        private System.Windows.Forms.Label lblThemeMsg;
    }
}
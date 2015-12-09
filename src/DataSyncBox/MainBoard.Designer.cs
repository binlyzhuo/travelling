namespace DataSyncBox
{
    partial class MainBoard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainBoard));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctripProvincesMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.tcSceneryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitHotelTablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.同步ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sceneryInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctripHotelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importHotelDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.备份ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotelDataBakeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sceneryDataBakeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotelRoomRatePlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotelRoomRatePlanImportOnlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quartzTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.接口测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctripApiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tongchengApiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sceneryQuerySettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotelQuerySettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcHotelMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.hotelCityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcApiTestToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.zhunaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zhunaapitestToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.zhunaDataSyncMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hotelDataComformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.panelContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.数据ToolStripMenuItem,
            this.同步ToolStripMenuItem,
            this.备份ToolStripMenuItem,
            this.taskToolStripMenuItem,
            this.接口测试ToolStripMenuItem,
            this.searchSettingToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.tcHotelMenu,
            this.zhunaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(742, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeAppToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // closeAppToolStripMenuItem
            // 
            this.closeAppToolStripMenuItem.Name = "closeAppToolStripMenuItem";
            this.closeAppToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.closeAppToolStripMenuItem.Text = "关闭";
            this.closeAppToolStripMenuItem.Click += new System.EventHandler(this.closeAppToolStripMenuItem_Click);
            // 
            // 数据ToolStripMenuItem
            // 
            this.数据ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctripProvincesMenu,
            this.tcSceneryToolStripMenuItem,
            this.splitHotelTablesToolStripMenuItem});
            this.数据ToolStripMenuItem.Name = "数据ToolStripMenuItem";
            this.数据ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.数据ToolStripMenuItem.Text = "系统初始化";
            // 
            // ctripProvincesMenu
            // 
            this.ctripProvincesMenu.Name = "ctripProvincesMenu";
            this.ctripProvincesMenu.Size = new System.Drawing.Size(148, 22);
            this.ctripProvincesMenu.Text = "携程公共信息";
            this.ctripProvincesMenu.Click += new System.EventHandler(this.ctripProvincesMenu_Click);
            // 
            // tcSceneryToolStripMenuItem
            // 
            this.tcSceneryToolStripMenuItem.Name = "tcSceneryToolStripMenuItem";
            this.tcSceneryToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.tcSceneryToolStripMenuItem.Text = "同程公共信息";
            this.tcSceneryToolStripMenuItem.Click += new System.EventHandler(this.tcSceneryToolStripMenuItem_Click);
            // 
            // splitHotelTablesToolStripMenuItem
            // 
            this.splitHotelTablesToolStripMenuItem.Name = "splitHotelTablesToolStripMenuItem";
            this.splitHotelTablesToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.splitHotelTablesToolStripMenuItem.Text = "数据库表拆分";
            this.splitHotelTablesToolStripMenuItem.Click += new System.EventHandler(this.splitHotelTablesToolStripMenuItem_Click);
            // 
            // 同步ToolStripMenuItem
            // 
            this.同步ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sceneryInfoToolStripMenuItem,
            this.ctripHotelToolStripMenuItem,
            this.importHotelDataToolStripMenuItem});
            this.同步ToolStripMenuItem.Name = "同步ToolStripMenuItem";
            this.同步ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.同步ToolStripMenuItem.Text = "接口数据同步";
            // 
            // sceneryInfoToolStripMenuItem
            // 
            this.sceneryInfoToolStripMenuItem.Name = "sceneryInfoToolStripMenuItem";
            this.sceneryInfoToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.sceneryInfoToolStripMenuItem.Text = "景区数据";
            this.sceneryInfoToolStripMenuItem.Click += new System.EventHandler(this.sceneryInfoToolStripMenuItem_Click);
            // 
            // ctripHotelToolStripMenuItem
            // 
            this.ctripHotelToolStripMenuItem.Name = "ctripHotelToolStripMenuItem";
            this.ctripHotelToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.ctripHotelToolStripMenuItem.Text = "携程酒店";
            this.ctripHotelToolStripMenuItem.Click += new System.EventHandler(this.ctripHotelToolStripMenuItem_Click);
            // 
            // importHotelDataToolStripMenuItem
            // 
            this.importHotelDataToolStripMenuItem.Name = "importHotelDataToolStripMenuItem";
            this.importHotelDataToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.importHotelDataToolStripMenuItem.Text = "酒店数据导入";
            this.importHotelDataToolStripMenuItem.Click += new System.EventHandler(this.importHotelDataToolStripMenuItem_Click);
            // 
            // 备份ToolStripMenuItem
            // 
            this.备份ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hotelDataBakeToolStripMenuItem,
            this.sceneryDataBakeToolStripMenuItem});
            this.备份ToolStripMenuItem.Name = "备份ToolStripMenuItem";
            this.备份ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.备份ToolStripMenuItem.Text = "数据库备份";
            // 
            // hotelDataBakeToolStripMenuItem
            // 
            this.hotelDataBakeToolStripMenuItem.Name = "hotelDataBakeToolStripMenuItem";
            this.hotelDataBakeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.hotelDataBakeToolStripMenuItem.Text = "酒店数据备份";
            this.hotelDataBakeToolStripMenuItem.Click += new System.EventHandler(this.hotelDataBakeToolStripMenuItem_Click);
            // 
            // sceneryDataBakeToolStripMenuItem
            // 
            this.sceneryDataBakeToolStripMenuItem.Name = "sceneryDataBakeToolStripMenuItem";
            this.sceneryDataBakeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.sceneryDataBakeToolStripMenuItem.Text = "景区数据备份";
            this.sceneryDataBakeToolStripMenuItem.Click += new System.EventHandler(this.sceneryDataBakeToolStripMenuItem_Click);
            // 
            // taskToolStripMenuItem
            // 
            this.taskToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hotelRoomRatePlanToolStripMenuItem,
            this.hotelRoomRatePlanImportOnlineToolStripMenuItem,
            this.quartzTestToolStripMenuItem});
            this.taskToolStripMenuItem.Name = "taskToolStripMenuItem";
            this.taskToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.taskToolStripMenuItem.Text = "计划任务";
            // 
            // hotelRoomRatePlanToolStripMenuItem
            // 
            this.hotelRoomRatePlanToolStripMenuItem.Name = "hotelRoomRatePlanToolStripMenuItem";
            this.hotelRoomRatePlanToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.hotelRoomRatePlanToolStripMenuItem.Text = "酒店价格同步计划";
            this.hotelRoomRatePlanToolStripMenuItem.Click += new System.EventHandler(this.hotelRoomRatePlanToolStripMenuItem_Click);
            // 
            // hotelRoomRatePlanImportOnlineToolStripMenuItem
            // 
            this.hotelRoomRatePlanImportOnlineToolStripMenuItem.Name = "hotelRoomRatePlanImportOnlineToolStripMenuItem";
            this.hotelRoomRatePlanImportOnlineToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.hotelRoomRatePlanImportOnlineToolStripMenuItem.Text = "酒店价格计划导入计划";
            this.hotelRoomRatePlanImportOnlineToolStripMenuItem.Click += new System.EventHandler(this.hotelRoomRatePlanImportOnlineToolStripMenuItem_Click);
            // 
            // quartzTestToolStripMenuItem
            // 
            this.quartzTestToolStripMenuItem.Name = "quartzTestToolStripMenuItem";
            this.quartzTestToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.quartzTestToolStripMenuItem.Text = "定时任务测试";
            this.quartzTestToolStripMenuItem.Click += new System.EventHandler(this.quartzTestToolStripMenuItem_Click);
            // 
            // 接口测试ToolStripMenuItem
            // 
            this.接口测试ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctripApiToolStripMenuItem,
            this.tongchengApiToolStripMenuItem});
            this.接口测试ToolStripMenuItem.Name = "接口测试ToolStripMenuItem";
            this.接口测试ToolStripMenuItem.Size = new System.Drawing.Size(72, 21);
            this.接口测试ToolStripMenuItem.Text = " 接口测试";
            // 
            // ctripApiToolStripMenuItem
            // 
            this.ctripApiToolStripMenuItem.Name = "ctripApiToolStripMenuItem";
            this.ctripApiToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.ctripApiToolStripMenuItem.Text = "携程接口";
            this.ctripApiToolStripMenuItem.Click += new System.EventHandler(this.ctripApiToolStripMenuItem_Click);
            // 
            // tongchengApiToolStripMenuItem
            // 
            this.tongchengApiToolStripMenuItem.Name = "tongchengApiToolStripMenuItem";
            this.tongchengApiToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.tongchengApiToolStripMenuItem.Text = "同程接口";
            this.tongchengApiToolStripMenuItem.Click += new System.EventHandler(this.tongchengApiToolStripMenuItem_Click);
            // 
            // searchSettingToolStripMenuItem
            // 
            this.searchSettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sceneryQuerySettingToolStripMenuItem,
            this.hotelQuerySettingToolStripMenuItem});
            this.searchSettingToolStripMenuItem.Name = "searchSettingToolStripMenuItem";
            this.searchSettingToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.searchSettingToolStripMenuItem.Text = "搜索";
            // 
            // sceneryQuerySettingToolStripMenuItem
            // 
            this.sceneryQuerySettingToolStripMenuItem.Name = "sceneryQuerySettingToolStripMenuItem";
            this.sceneryQuerySettingToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.sceneryQuerySettingToolStripMenuItem.Text = "景区搜索";
            this.sceneryQuerySettingToolStripMenuItem.Click += new System.EventHandler(this.sceneryQuerySettingToolStripMenuItem_Click);
            // 
            // hotelQuerySettingToolStripMenuItem
            // 
            this.hotelQuerySettingToolStripMenuItem.Name = "hotelQuerySettingToolStripMenuItem";
            this.hotelQuerySettingToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.hotelQuerySettingToolStripMenuItem.Text = "酒店搜索";
            this.hotelQuerySettingToolStripMenuItem.Click += new System.EventHandler(this.hotelQuerySettingToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.aboutToolStripMenuItem.Text = "关于";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // tcHotelMenu
            // 
            this.tcHotelMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hotelCityToolStripMenuItem,
            this.tcApiTestToolStripMenuItem1});
            this.tcHotelMenu.Name = "tcHotelMenu";
            this.tcHotelMenu.Size = new System.Drawing.Size(68, 21);
            this.tcHotelMenu.Text = "同程酒店";
            // 
            // hotelCityToolStripMenuItem
            // 
            this.hotelCityToolStripMenuItem.Name = "hotelCityToolStripMenuItem";
            this.hotelCityToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.hotelCityToolStripMenuItem.Text = "省份城市";
            this.hotelCityToolStripMenuItem.Click += new System.EventHandler(this.hotelCityToolStripMenuItem_Click);
            // 
            // tcApiTestToolStripMenuItem1
            // 
            this.tcApiTestToolStripMenuItem1.Name = "tcApiTestToolStripMenuItem1";
            this.tcApiTestToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.tcApiTestToolStripMenuItem1.Text = "接口测试";
            this.tcApiTestToolStripMenuItem1.Click += new System.EventHandler(this.tcApiTestToolStripMenuItem1_Click);
            // 
            // zhunaToolStripMenuItem
            // 
            this.zhunaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zhunaapitestToolStripMenuItem1,
            this.zhunaDataSyncMenuItem,
            this.hotelDataComformToolStripMenuItem});
            this.zhunaToolStripMenuItem.Name = "zhunaToolStripMenuItem";
            this.zhunaToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.zhunaToolStripMenuItem.Text = "住哪儿";
            // 
            // zhunaapitestToolStripMenuItem1
            // 
            this.zhunaapitestToolStripMenuItem1.Name = "zhunaapitestToolStripMenuItem1";
            this.zhunaapitestToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.zhunaapitestToolStripMenuItem1.Text = "接口测试";
            this.zhunaapitestToolStripMenuItem1.Click += new System.EventHandler(this.zhunaapitestToolStripMenuItem1_Click);
            // 
            // zhunaDataSyncMenuItem
            // 
            this.zhunaDataSyncMenuItem.Name = "zhunaDataSyncMenuItem";
            this.zhunaDataSyncMenuItem.Size = new System.Drawing.Size(124, 22);
            this.zhunaDataSyncMenuItem.Text = "数据同步";
            this.zhunaDataSyncMenuItem.Click += new System.EventHandler(this.zhunaDataSyncMenuItem_Click);
            // 
            // hotelDataComformToolStripMenuItem
            // 
            this.hotelDataComformToolStripMenuItem.Name = "hotelDataComformToolStripMenuItem";
            this.hotelDataComformToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.hotelDataComformToolStripMenuItem.Text = "数据整合";
            this.hotelDataComformToolStripMenuItem.Click += new System.EventHandler(this.hotelDataComformToolStripMenuItem_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.SystemColors.Control;
            this.panelContainer.Controls.Add(this.panel1);
            this.panelContainer.Location = new System.Drawing.Point(12, 28);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(706, 345);
            this.panelContainer.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(57, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(521, 200);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(347, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "v1.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(41, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "卓家客栈数据同步工具";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "悦悦酒店数据同步工具";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // MainBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 415);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainBoard";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "卓家客栈数据同步工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainBoard_FormClosing);
            this.Load += new System.EventHandler(this.MainBoard_Load);
            this.SizeChanged += new System.EventHandler(this.MainBoard_SizeChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 同步ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctripProvincesMenu;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.ToolStripMenuItem sceneryInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tcSceneryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctripHotelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 备份ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotelDataBakeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sceneryDataBakeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 接口测试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ctripApiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tongchengApiToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem taskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotelRoomRatePlanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importHotelDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotelRoomRatePlanImportOnlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchSettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sceneryQuerySettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotelQuerySettingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quartzTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem splitHotelTablesToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem tcHotelMenu;
        private System.Windows.Forms.ToolStripMenuItem hotelCityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tcApiTestToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zhunaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zhunaapitestToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem zhunaDataSyncMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hotelDataComformToolStripMenuItem;
    }
}
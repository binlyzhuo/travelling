namespace DataSyncBox
{
    partial class RoomRatePlanSyncLogEditForm
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
            this.lblStartDate = new System.Windows.Forms.Label();
            this.startDatePK = new System.Windows.Forms.DateTimePicker();
            this.endDatePK = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(22, 19);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(53, 12);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "开始日期";
            // 
            // startDatePK
            // 
            this.startDatePK.Location = new System.Drawing.Point(85, 13);
            this.startDatePK.Name = "startDatePK";
            this.startDatePK.Size = new System.Drawing.Size(200, 21);
            this.startDatePK.TabIndex = 1;
            // 
            // endDatePK
            // 
            this.endDatePK.Location = new System.Drawing.Point(85, 50);
            this.endDatePK.Name = "endDatePK";
            this.endDatePK.Size = new System.Drawing.Size(200, 21);
            this.endDatePK.TabIndex = 2;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(22, 56);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(53, 12);
            this.lblEndDate.TabIndex = 3;
            this.lblEndDate.Text = "结束日期";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(85, 110);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "确定";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(187, 110);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(75, 23);
            this.btnclose.TabIndex = 5;
            this.btnclose.Text = "关闭";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // RoomRatePlanSyncLogEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 175);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.endDatePK);
            this.Controls.Add(this.startDatePK);
            this.Controls.Add(this.lblStartDate);
            this.MaximizeBox = false;
            this.Name = "RoomRatePlanSyncLogEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RoomRatePlanSyncLogEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker startDatePK;
        private System.Windows.Forms.DateTimePicker endDatePK;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnclose;
    }
}
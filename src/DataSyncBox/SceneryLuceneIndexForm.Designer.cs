namespace DataSyncBox
{
    partial class SceneryLuceneIndexForm
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
            this.btnCreate = new System.Windows.Forms.Button();
            this.ckRepeatCreate = new System.Windows.Forms.CheckBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.pgCreate = new System.Windows.Forms.ProgressBar();
            this.btnSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(15, 39);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(129, 23);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "创建索引";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // ckRepeatCreate
            // 
            this.ckRepeatCreate.AutoSize = true;
            this.ckRepeatCreate.Location = new System.Drawing.Point(15, 17);
            this.ckRepeatCreate.Name = "ckRepeatCreate";
            this.ckRepeatCreate.Size = new System.Drawing.Size(96, 16);
            this.ckRepeatCreate.TabIndex = 1;
            this.ckRepeatCreate.Text = "重新创建索引";
            this.ckRepeatCreate.UseVisualStyleBackColor = true;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(13, 83);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(41, 12);
            this.lblMsg.TabIndex = 2;
            this.lblMsg.Text = "未创建";
            // 
            // pgCreate
            // 
            this.pgCreate.Location = new System.Drawing.Point(12, 118);
            this.pgCreate.Name = "pgCreate";
            this.pgCreate.Size = new System.Drawing.Size(281, 23);
            this.pgCreate.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(178, 39);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(115, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // SceneryLuceneIndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 261);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.pgCreate);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.ckRepeatCreate);
            this.Controls.Add(this.btnCreate);
            this.Name = "SceneryLuceneIndexForm";
            this.Text = "SceneryLuceneIndexForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.CheckBox ckRepeatCreate;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.ProgressBar pgCreate;
        private System.Windows.Forms.Button btnSearch;
    }
}
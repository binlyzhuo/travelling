namespace DataSyncBox
{
    partial class HotelLuceneIndexForm
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
            this.btnCreateHotelDescIndex = new System.Windows.Forms.Button();
            this.btnTestIndexQuery = new System.Windows.Forms.Button();
            this.lblLuceneMsg = new System.Windows.Forms.Label();
            this.pgLuceneIndex = new System.Windows.Forms.ProgressBar();
            this.ckRepeat = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCreateHotelDescIndex
            // 
            this.btnCreateHotelDescIndex.Location = new System.Drawing.Point(41, 30);
            this.btnCreateHotelDescIndex.Name = "btnCreateHotelDescIndex";
            this.btnCreateHotelDescIndex.Size = new System.Drawing.Size(137, 23);
            this.btnCreateHotelDescIndex.TabIndex = 0;
            this.btnCreateHotelDescIndex.Text = "创建酒店信息索引";
            this.btnCreateHotelDescIndex.UseVisualStyleBackColor = true;
            this.btnCreateHotelDescIndex.Click += new System.EventHandler(this.btnCreateHotelDescIndex_Click);
            // 
            // btnTestIndexQuery
            // 
            this.btnTestIndexQuery.Location = new System.Drawing.Point(224, 30);
            this.btnTestIndexQuery.Name = "btnTestIndexQuery";
            this.btnTestIndexQuery.Size = new System.Drawing.Size(134, 23);
            this.btnTestIndexQuery.TabIndex = 1;
            this.btnTestIndexQuery.Text = "测试";
            this.btnTestIndexQuery.UseVisualStyleBackColor = true;
            this.btnTestIndexQuery.Click += new System.EventHandler(this.btnTestIndexQuery_Click);
            // 
            // lblLuceneMsg
            // 
            this.lblLuceneMsg.AutoSize = true;
            this.lblLuceneMsg.Location = new System.Drawing.Point(39, 152);
            this.lblLuceneMsg.Name = "lblLuceneMsg";
            this.lblLuceneMsg.Size = new System.Drawing.Size(41, 12);
            this.lblLuceneMsg.TabIndex = 2;
            this.lblLuceneMsg.Text = "待索引";
            // 
            // pgLuceneIndex
            // 
            this.pgLuceneIndex.Location = new System.Drawing.Point(41, 120);
            this.pgLuceneIndex.Name = "pgLuceneIndex";
            this.pgLuceneIndex.Size = new System.Drawing.Size(327, 23);
            this.pgLuceneIndex.TabIndex = 4;
            // 
            // ckRepeat
            // 
            this.ckRepeat.AutoSize = true;
            this.ckRepeat.Location = new System.Drawing.Point(41, 71);
            this.ckRepeat.Name = "ckRepeat";
            this.ckRepeat.Size = new System.Drawing.Size(72, 16);
            this.ckRepeat.TabIndex = 5;
            this.ckRepeat.Text = "重新创建";
            this.ckRepeat.UseVisualStyleBackColor = true;
            // 
            // HotelLuceneIndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 261);
            this.Controls.Add(this.ckRepeat);
            this.Controls.Add(this.pgLuceneIndex);
            this.Controls.Add(this.lblLuceneMsg);
            this.Controls.Add(this.btnTestIndexQuery);
            this.Controls.Add(this.btnCreateHotelDescIndex);
            this.Name = "HotelLuceneIndexForm";
            this.Text = "HotelLuceneIndexForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateHotelDescIndex;
        private System.Windows.Forms.Button btnTestIndexQuery;
        private System.Windows.Forms.Label lblLuceneMsg;
        private System.Windows.Forms.ProgressBar pgLuceneIndex;
        private System.Windows.Forms.CheckBox ckRepeat;
    }
}
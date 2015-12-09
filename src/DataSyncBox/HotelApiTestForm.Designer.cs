namespace DataSyncBox
{
    partial class HotelApiTestForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtHotelID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCityID = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCityID = new System.Windows.Forms.Label();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtHotelDescID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetUserUnique = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.tuanSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(239, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "运行";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtHotelID
            // 
            this.txtHotelID.Location = new System.Drawing.Point(100, 31);
            this.txtHotelID.Name = "txtHotelID";
            this.txtHotelID.Size = new System.Drawing.Size(100, 21);
            this.txtHotelID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "酒店ID";
            // 
            // txtCityID
            // 
            this.txtCityID.Location = new System.Drawing.Point(100, 91);
            this.txtCityID.Name = "txtCityID";
            this.txtCityID.Size = new System.Drawing.Size(100, 21);
            this.txtCityID.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(239, 88);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblCityID
            // 
            this.lblCityID.AutoSize = true;
            this.lblCityID.Location = new System.Drawing.Point(55, 99);
            this.lblCityID.Name = "lblCityID";
            this.lblCityID.Size = new System.Drawing.Size(41, 12);
            this.lblCityID.TabIndex = 5;
            this.lblCityID.Text = "城市ID";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Location = new System.Drawing.Point(100, 142);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(100, 21);
            this.txtOrderNo.TabIndex = 6;
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Location = new System.Drawing.Point(41, 142);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(53, 12);
            this.lblOrderNo.TabIndex = 7;
            this.lblOrderNo.Text = " orderno";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(239, 137);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = " 取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(239, 181);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "酒店详情查询";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtHotelDescID
            // 
            this.txtHotelDescID.Location = new System.Drawing.Point(100, 183);
            this.txtHotelDescID.Name = "txtHotelDescID";
            this.txtHotelDescID.Size = new System.Drawing.Size(100, 21);
            this.txtHotelDescID.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "酒店ID";
            // 
            // btnGetUserUnique
            // 
            this.btnGetUserUnique.Location = new System.Drawing.Point(239, 222);
            this.btnGetUserUnique.Name = "btnGetUserUnique";
            this.btnGetUserUnique.Size = new System.Drawing.Size(100, 23);
            this.btnGetUserUnique.TabIndex = 12;
            this.btnGetUserUnique.Text = "获取UserUnique";
            this.btnGetUserUnique.UseVisualStyleBackColor = true;
            this.btnGetUserUnique.Click += new System.EventHandler(this.btnGetUserUnique_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "客户名";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(100, 230);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(100, 21);
            this.txtCustomerName.TabIndex = 14;
            // 
            // tuanSearch
            // 
            this.tuanSearch.Location = new System.Drawing.Point(128, 275);
            this.tuanSearch.Name = "tuanSearch";
            this.tuanSearch.Size = new System.Drawing.Size(100, 23);
            this.tuanSearch.TabIndex = 15;
            this.tuanSearch.Text = "团购查询";
            this.tuanSearch.UseVisualStyleBackColor = true;
            this.tuanSearch.Click += new System.EventHandler(this.tuanSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "团购查询";
            // 
            // HotelApiTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 420);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tuanSearch);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGetUserUnique);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHotelDescID);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblOrderNo);
            this.Controls.Add(this.txtOrderNo);
            this.Controls.Add(this.lblCityID);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtCityID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHotelID);
            this.Controls.Add(this.button1);
            this.Name = "HotelApiTestForm";
            this.Text = "HotelApiTestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtHotelID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCityID;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblCityID;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtHotelDescID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGetUserUnique;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Button tuanSearch;
        private System.Windows.Forms.Label label4;
    }
}
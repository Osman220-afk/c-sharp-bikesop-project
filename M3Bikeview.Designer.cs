namespace BikeShop
{
    partial class M3Bikeview
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
            this.txtlist = new System.Windows.Forms.Label();
            this.dgvShowB = new System.Windows.Forms.DataGridView();
            this.PlaceOrderBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCard = new System.Windows.Forms.Label();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtmodel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.EmailTxtBox = new System.Windows.Forms.TextBox();
            this.BrandTxtBox = new System.Windows.Forms.TextBox();
            this.ModelTxtBox = new System.Windows.Forms.TextBox();
            this.PriceTxtBox = new System.Windows.Forms.TextBox();
            this.TotalTxtBox = new System.Windows.Forms.TextBox();
            this.BackBtn = new System.Windows.Forms.Button();
            this.QuantityComBox = new System.Windows.Forms.ComboBox();
            this.idlbl = new System.Windows.Forms.Label();
            this.IdTxtBox = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowB)).BeginInit();
            this.SuspendLayout();
            // 
            // txtlist
            // 
            this.txtlist.AutoSize = true;
            this.txtlist.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 22.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlist.ForeColor = System.Drawing.Color.IndianRed;
            this.txtlist.Location = new System.Drawing.Point(431, 9);
            this.txtlist.Name = "txtlist";
            this.txtlist.Size = new System.Drawing.Size(274, 51);
            this.txtlist.TabIndex = 0;
            this.txtlist.Text = "Order Bike";
            // 
            // dgvShowB
            // 
            this.dgvShowB.AllowUserToAddRows = false;
            this.dgvShowB.AllowUserToDeleteRows = false;
            this.dgvShowB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowB.Location = new System.Drawing.Point(23, 205);
            this.dgvShowB.Name = "dgvShowB";
            this.dgvShowB.ReadOnly = true;
            this.dgvShowB.RowHeadersWidth = 51;
            this.dgvShowB.RowTemplate.Height = 24;
            this.dgvShowB.Size = new System.Drawing.Size(607, 377);
            this.dgvShowB.TabIndex = 6;
            this.dgvShowB.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShowB_CellClick);
            // 
            // PlaceOrderBtn
            // 
            this.PlaceOrderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlaceOrderBtn.Location = new System.Drawing.Point(947, 567);
            this.PlaceOrderBtn.Name = "PlaceOrderBtn";
            this.PlaceOrderBtn.Size = new System.Drawing.Size(159, 38);
            this.PlaceOrderBtn.TabIndex = 9;
            this.PlaceOrderBtn.Text = "Place Order";
            this.PlaceOrderBtn.UseVisualStyleBackColor = true;
            this.PlaceOrderBtn.Click += new System.EventHandler(this.PlaceOrderBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(143, 144);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(244, 22);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 32);
            this.label1.TabIndex = 11;
            this.label1.Text = "Search :";
            // 
            // labelCard
            // 
            this.labelCard.AutoSize = true;
            this.labelCard.BackColor = System.Drawing.Color.Transparent;
            this.labelCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCard.ForeColor = System.Drawing.Color.Red;
            this.labelCard.Location = new System.Drawing.Point(918, 282);
            this.labelCard.Name = "labelCard";
            this.labelCard.Size = new System.Drawing.Size(0, 20);
            this.labelCard.TabIndex = 12;
            // 
            // ClearBtn
            // 
            this.ClearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.Location = new System.Drawing.Point(923, 338);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(97, 31);
            this.ClearBtn.TabIndex = 13;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(690, 463);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Email :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(783, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 25);
            this.label4.TabIndex = 16;
            this.label4.Text = "Brand :";
            // 
            // txtmodel
            // 
            this.txtmodel.AutoSize = true;
            this.txtmodel.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmodel.Location = new System.Drawing.Point(783, 116);
            this.txtmodel.Name = "txtmodel";
            this.txtmodel.Size = new System.Drawing.Size(90, 25);
            this.txtmodel.TabIndex = 17;
            this.txtmodel.Text = "Model :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(795, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 25);
            this.label6.TabIndex = 18;
            this.label6.Text = "Price :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(759, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 25);
            this.label7.TabIndex = 19;
            this.label7.Text = "Quantity :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(797, 278);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 25);
            this.label8.TabIndex = 20;
            this.label8.Text = "Total :";
            // 
            // EmailTxtBox
            // 
            this.EmailTxtBox.Location = new System.Drawing.Point(798, 463);
            this.EmailTxtBox.Name = "EmailTxtBox";
            this.EmailTxtBox.Size = new System.Drawing.Size(244, 22);
            this.EmailTxtBox.TabIndex = 22;
            // 
            // BrandTxtBox
            // 
            this.BrandTxtBox.Location = new System.Drawing.Point(899, 62);
            this.BrandTxtBox.Name = "BrandTxtBox";
            this.BrandTxtBox.ReadOnly = true;
            this.BrandTxtBox.Size = new System.Drawing.Size(244, 22);
            this.BrandTxtBox.TabIndex = 23;
            // 
            // ModelTxtBox
            // 
            this.ModelTxtBox.Location = new System.Drawing.Point(899, 120);
            this.ModelTxtBox.Name = "ModelTxtBox";
            this.ModelTxtBox.ReadOnly = true;
            this.ModelTxtBox.Size = new System.Drawing.Size(244, 22);
            this.ModelTxtBox.TabIndex = 24;
            // 
            // PriceTxtBox
            // 
            this.PriceTxtBox.Location = new System.Drawing.Point(899, 167);
            this.PriceTxtBox.Name = "PriceTxtBox";
            this.PriceTxtBox.ReadOnly = true;
            this.PriceTxtBox.Size = new System.Drawing.Size(244, 22);
            this.PriceTxtBox.TabIndex = 25;
            // 
            // TotalTxtBox
            // 
            this.TotalTxtBox.Location = new System.Drawing.Point(899, 280);
            this.TotalTxtBox.Name = "TotalTxtBox";
            this.TotalTxtBox.ReadOnly = true;
            this.TotalTxtBox.Size = new System.Drawing.Size(244, 22);
            this.TotalTxtBox.TabIndex = 27;
            // 
            // BackBtn
            // 
            this.BackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackBtn.Location = new System.Drawing.Point(23, 614);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(97, 31);
            this.BackBtn.TabIndex = 28;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // QuantityComBox
            // 
            this.QuantityComBox.FormattingEnabled = true;
            this.QuantityComBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.QuantityComBox.Location = new System.Drawing.Point(899, 221);
            this.QuantityComBox.Name = "QuantityComBox";
            this.QuantityComBox.Size = new System.Drawing.Size(121, 24);
            this.QuantityComBox.TabIndex = 29;
            this.QuantityComBox.SelectedIndexChanged += new System.EventHandler(this.QuantityComBox_SelectedIndexChanged_1);
            // 
            // idlbl
            // 
            this.idlbl.AutoSize = true;
            this.idlbl.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idlbl.Location = new System.Drawing.Point(720, 504);
            this.idlbl.Name = "idlbl";
            this.idlbl.Size = new System.Drawing.Size(52, 25);
            this.idlbl.TabIndex = 30;
            this.idlbl.Text = "ID :";
            // 
            // IdTxtBox
            // 
            this.IdTxtBox.Location = new System.Drawing.Point(798, 504);
            this.IdTxtBox.Name = "IdTxtBox";
            this.IdTxtBox.ReadOnly = true;
            this.IdTxtBox.Size = new System.Drawing.Size(244, 22);
            this.IdTxtBox.TabIndex = 31;
            // 
            // SearchBtn
            // 
            this.SearchBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBtn.Location = new System.Drawing.Point(1057, 457);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(97, 31);
            this.SearchBtn.TabIndex = 32;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(26, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(297, 32);
            this.label2.TabIndex = 33;
            this.label2.Text = "Search and Chose Bike,";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(690, 410);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 25);
            this.label5.TabIndex = 34;
            this.label5.Text = "Enter your Email :";
            // 
            // M3Bikeview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1186, 666);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.IdTxtBox);
            this.Controls.Add(this.idlbl);
            this.Controls.Add(this.QuantityComBox);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.TotalTxtBox);
            this.Controls.Add(this.PriceTxtBox);
            this.Controls.Add(this.ModelTxtBox);
            this.Controls.Add(this.BrandTxtBox);
            this.Controls.Add(this.EmailTxtBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtmodel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.labelCard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.PlaceOrderBtn);
            this.Controls.Add(this.dgvShowB);
            this.Controls.Add(this.txtlist);
            this.Name = "M3Bikeview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bike View";
            this.Load += new System.EventHandler(this.M3Bikeview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtlist;
        private System.Windows.Forms.DataGridView dgvShowB;
        private System.Windows.Forms.Button PlaceOrderBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCard;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label txtmodel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox EmailTxtBox;
        private System.Windows.Forms.TextBox BrandTxtBox;
        private System.Windows.Forms.TextBox ModelTxtBox;
        private System.Windows.Forms.TextBox PriceTxtBox;
        private System.Windows.Forms.TextBox TotalTxtBox;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.ComboBox QuantityComBox;
        private System.Windows.Forms.Label idlbl;
        private System.Windows.Forms.TextBox IdTxtBox;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
    }
}
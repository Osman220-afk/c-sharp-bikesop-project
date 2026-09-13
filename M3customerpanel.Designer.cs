namespace BikeShop
{
    partial class M3customerpanel
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
            this.txtVBike = new System.Windows.Forms.Button();
            this.txtPurchase = new System.Windows.Forms.Button();
            this.txtPayment = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtVBike
            // 
            this.txtVBike.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtVBike.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVBike.Location = new System.Drawing.Point(53, 203);
            this.txtVBike.Name = "txtVBike";
            this.txtVBike.Size = new System.Drawing.Size(203, 129);
            this.txtVBike.TabIndex = 0;
            this.txtVBike.Text = "Order Bikes";
            this.txtVBike.UseVisualStyleBackColor = false;
            this.txtVBike.Click += new System.EventHandler(this.txtVBike_Click);
            // 
            // txtPurchase
            // 
            this.txtPurchase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txtPurchase.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPurchase.Location = new System.Drawing.Point(299, 203);
            this.txtPurchase.Name = "txtPurchase";
            this.txtPurchase.Size = new System.Drawing.Size(197, 129);
            this.txtPurchase.TabIndex = 1;
            this.txtPurchase.Text = "Order Details";
            this.txtPurchase.UseVisualStyleBackColor = false;
            this.txtPurchase.Click += new System.EventHandler(this.txtPurchase_Click);
            // 
            // txtPayment
            // 
            this.txtPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPayment.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayment.Location = new System.Drawing.Point(538, 203);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(191, 129);
            this.txtPayment.TabIndex = 2;
            this.txtPayment.Text = "Purchase History";
            this.txtPayment.UseVisualStyleBackColor = false;
            this.txtPayment.Click += new System.EventHandler(this.txtPayment_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(98, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(593, 50);
            this.label1.TabIndex = 3;
            this.label1.Text = "WelCome To AIUB Bike Shop";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // M3customerpanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 520);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPayment);
            this.Controls.Add(this.txtPurchase);
            this.Controls.Add(this.txtVBike);
            this.Name = "M3customerpanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "M3customerpanel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.M3customerpanel_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button txtVBike;
        private System.Windows.Forms.Button txtPurchase;
        private System.Windows.Forms.Button txtPayment;
        private System.Windows.Forms.Label label1;
    }
}
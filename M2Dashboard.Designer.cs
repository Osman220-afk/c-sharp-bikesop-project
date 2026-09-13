namespace BikeShop
{
    partial class M2Dashboard
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
            this.label1 = new System.Windows.Forms.Label();
            this.ManageCustomerbtn = new System.Windows.Forms.Button();
            this.SalesHistorybtn = new System.Windows.Forms.Button();
            this.ProcessOrderbtn = new System.Windows.Forms.Button();
            this.PlaceOrderbtn = new System.Windows.Forms.Button();
            this.Logoutbtn = new System.Windows.Forms.Button();
            this.Wellcomelbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(383, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bike Shop";
            // 
            // ManageCustomerbtn
            // 
            this.ManageCustomerbtn.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ManageCustomerbtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageCustomerbtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ManageCustomerbtn.Location = new System.Drawing.Point(56, 178);
            this.ManageCustomerbtn.Name = "ManageCustomerbtn";
            this.ManageCustomerbtn.Size = new System.Drawing.Size(365, 85);
            this.ManageCustomerbtn.TabIndex = 1;
            this.ManageCustomerbtn.Text = "Manage Customer";
            this.ManageCustomerbtn.UseVisualStyleBackColor = false;
            this.ManageCustomerbtn.Click += new System.EventHandler(this.ManageCustomerbtn_Click);
            // 
            // SalesHistorybtn
            // 
            this.SalesHistorybtn.BackColor = System.Drawing.Color.OrangeRed;
            this.SalesHistorybtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SalesHistorybtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SalesHistorybtn.Location = new System.Drawing.Point(518, 308);
            this.SalesHistorybtn.Name = "SalesHistorybtn";
            this.SalesHistorybtn.Size = new System.Drawing.Size(365, 85);
            this.SalesHistorybtn.TabIndex = 2;
            this.SalesHistorybtn.Text = "Sales History";
            this.SalesHistorybtn.UseVisualStyleBackColor = false;
            this.SalesHistorybtn.Click += new System.EventHandler(this.SalesHistorybtn_Click);
            // 
            // ProcessOrderbtn
            // 
            this.ProcessOrderbtn.BackColor = System.Drawing.Color.Orange;
            this.ProcessOrderbtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcessOrderbtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ProcessOrderbtn.Location = new System.Drawing.Point(56, 317);
            this.ProcessOrderbtn.Name = "ProcessOrderbtn";
            this.ProcessOrderbtn.Size = new System.Drawing.Size(365, 85);
            this.ProcessOrderbtn.TabIndex = 3;
            this.ProcessOrderbtn.Text = "Process Order";
            this.ProcessOrderbtn.UseVisualStyleBackColor = false;
            this.ProcessOrderbtn.Click += new System.EventHandler(this.ProcessOrderbtn_Click);
            // 
            // PlaceOrderbtn
            // 
            this.PlaceOrderbtn.BackColor = System.Drawing.Color.RoyalBlue;
            this.PlaceOrderbtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlaceOrderbtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PlaceOrderbtn.Location = new System.Drawing.Point(518, 178);
            this.PlaceOrderbtn.Name = "PlaceOrderbtn";
            this.PlaceOrderbtn.Size = new System.Drawing.Size(365, 85);
            this.PlaceOrderbtn.TabIndex = 4;
            this.PlaceOrderbtn.Text = "Place Order";
            this.PlaceOrderbtn.UseVisualStyleBackColor = false;
            this.PlaceOrderbtn.Click += new System.EventHandler(this.PlaceOrderbtn_Click);
            // 
            // Logoutbtn
            // 
            this.Logoutbtn.BackColor = System.Drawing.Color.Red;
            this.Logoutbtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logoutbtn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Logoutbtn.Location = new System.Drawing.Point(335, 466);
            this.Logoutbtn.Name = "Logoutbtn";
            this.Logoutbtn.Size = new System.Drawing.Size(281, 85);
            this.Logoutbtn.TabIndex = 5;
            this.Logoutbtn.Text = "Logout";
            this.Logoutbtn.UseVisualStyleBackColor = false;
            this.Logoutbtn.Click += new System.EventHandler(this.Logoutbtn_Click);
            // 
            // Wellcomelbl
            // 
            this.Wellcomelbl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Wellcomelbl.Location = new System.Drawing.Point(346, 89);
            this.Wellcomelbl.Name = "Wellcomelbl";
            this.Wellcomelbl.Size = new System.Drawing.Size(270, 48);
            this.Wellcomelbl.TabIndex = 6;
            this.Wellcomelbl.Text = "Employee Managerial View";
            // 
            // M2Dashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(977, 655);
            this.Controls.Add(this.Wellcomelbl);
            this.Controls.Add(this.Logoutbtn);
            this.Controls.Add(this.PlaceOrderbtn);
            this.Controls.Add(this.ProcessOrderbtn);
            this.Controls.Add(this.SalesHistorybtn);
            this.Controls.Add(this.ManageCustomerbtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "M2Dashboard";
            this.Text = "Empolyee_Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ManageCustomerbtn;
        private System.Windows.Forms.Button SalesHistorybtn;
        private System.Windows.Forms.Button ProcessOrderbtn;
        private System.Windows.Forms.Button PlaceOrderbtn;
        private System.Windows.Forms.Button Logoutbtn;
        private System.Windows.Forms.Label Wellcomelbl;
    }
}
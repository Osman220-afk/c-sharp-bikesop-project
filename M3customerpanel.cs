using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeShop
{
    public partial class M3customerpanel : Form
    {
        public M3customerpanel()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void txtVBike_Click(object sender, EventArgs e)
        {
            M3Bikeview ad = new M3Bikeview();
            ad.Show();
            this.Hide();
        }

        private void txtPurchase_Click(object sender, EventArgs e)
        {
            OrderHistory ad = new OrderHistory();
            ad.Show();
            this.Hide();
        }

        private void txtPayment_Click(object sender, EventArgs e)
        {
            PreviousBuy ad = new PreviousBuy();
            ad.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void M3customerpanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginPage lp = new LoginPage();
            lp.Show();
            this.Hide();
        }
    }
}

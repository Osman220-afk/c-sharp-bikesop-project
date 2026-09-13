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
    public partial class M2Dashboard : Form
    {
        public M2Dashboard()
        {
            InitializeComponent();
        }

        private void PlaceOrderbtn_Click(object sender, EventArgs e)
        {
            M2PlaceOrder placeorder = new M2PlaceOrder();
            placeorder.Show();
            this.Hide();
        }

        private void ManageCustomerbtn_Click(object sender, EventArgs e)
        {
            M2ManageCustomer managecustomer = new M2ManageCustomer();
            managecustomer.Show();
            this.Hide();
        }

        private void SalesHistorybtn_Click(object sender, EventArgs e)
        {
            M2SalesHistory saleshistory = new M2SalesHistory();
            saleshistory.Show();
            this.Hide();
        }

        private void ProcessOrderbtn_Click(object sender, EventArgs e)
        {
            M2AccpetOrder acceptorder = new M2AccpetOrder();
            acceptorder.Show();
            this.Hide();
        }

        private void Logoutbtn_Click(object sender, EventArgs e)
        {
            LoginPage ap = new LoginPage();
            ap.Show();
            this.Hide();
        }
    }
}

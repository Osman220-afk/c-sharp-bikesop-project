using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeShop
{
    public partial class PreviousBuy : Form
    {
        public PreviousBuy()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string id = txtId.Text;
            if (id == "")
            {
                MessageBox.Show("Invalid name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtId.Focus();

                return;

            }

            this.LoadData();
        }

        private void LoadData()
        {
            string id = txtId.Text;
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select* from OrderTable Where Customerid = '{id}'";

                DataSet ds = new DataSet();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];

                dgvBuyH.AutoGenerateColumns = false;

                dgvBuyH.DataSource = dt;
                dgvBuyH.Refresh();

                dgvBuyH.ClearSelection();
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Went Wrong");
            }
        }

        private void dgvBuyH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PreviousBuy_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            M3customerpanel ad = new M3customerpanel();
            ad.Show();
            this.Hide();
        }
    }
    
}

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
    public partial class M2SalesHistory : Form
    {
        public M2SalesHistory()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            M2Dashboard dashboard = new M2Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            DateTime fromdt = FromDatePick.Value.Date;
            DateTime todt = ToDatePick.Value.Date;
            string fromdate = fromdt.ToString("yyyy-MM-dd");
            string todate = todt.ToString("yyyy-MM-dd");
            
            string reference = RefTxtBox.Text;
            if (reference == "")
            {
                MessageBox.Show("Please enter a reference number.", "Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            if (fromdt > todt)
            {
                MessageBox.Show("Please select a valid date range.", "Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select * from SalesTable where Reference = '{reference}' and Date between '{fromdate}' AND '{todate}'";

                DataSet ds = new DataSet();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                con.Close();
                calculatetotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing data: " + ex.Message);
                return;
            }

        }
        private void calculatetotal()
        {
            double totalsales = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[5] != null && row.Cells[5].Value != null)
                {
                    totalsales += Convert.ToDouble(row.Cells[5].Value);
                }
            }
            string totalsale = Convert.ToString(totalsales);
            if(totalsales == 0)
            {
                MessageBox.Show("You have not sale anything in the given date range " +
                    "Or your Employee name is incorrect "+
                    "select valid date and Employee name", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            TotalTxtBox.Text = $"{totalsale}";
        }
    }
}

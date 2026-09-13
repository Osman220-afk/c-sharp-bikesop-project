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
    public partial class OfficialsLogin : Form
    {
        public OfficialsLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string pass = txtPass.Text;

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select * from OfficeLoginTable where Email = '{email}' and Password = '{pass}'";

                DataSet ds = new DataSet();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];
                con.Close();

                if (dt.Rows.Count != 1)
                {
                    MessageBox.Show("Invalid Name or Email. Please try again");
                    return;
                }

                string name = dt.Rows[0]["Name"].ToString();
                MessageBox.Show("Welcome, " + name);
                string user = dt.Rows[0]["UserType"].ToString();

                if (user == "Admin")
                {
                    AdminPanel ad = new AdminPanel();
                    ad.Show();
                    this.Hide();
                }
                else if (user == "Employee")
                {
                    M2Dashboard ad = new M2Dashboard();
                    ad.Show();
                    this.Hide();
                }
                



            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Went Wrong");
            }
        }

        private void OfficialsLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginPage ev = new LoginPage();
            ev.Show();
        
        }

        private void OfficialsLogin_Load(object sender, EventArgs e)
        {

        }
    }
}

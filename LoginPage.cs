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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BikeShop
{
    public partial class LoginPage : Form
    {
        public LoginPage()
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
                cmd.CommandText = $"select * from RegistraTable where Email = '{email}' and Password = '{pass}'";

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

                string mail = dt.Rows[0]["Email"].ToString();
                
                

                if (email == $"{email}")
                {
                    M3customerpanel ad = new M3customerpanel();
                    ad.Show();
                    this.Hide();
                }
                



            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Went Wrong");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OfficialsLogin ol = new OfficialsLogin();
            ol.Show();
            this.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerRegistration cr = new CustomerRegistration();
            cr.Show();
            this.Hide();
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = false;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
        }
    }
}

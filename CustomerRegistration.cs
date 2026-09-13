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
    public partial class CustomerRegistration : Form
    {
        public CustomerRegistration()
        {
            InitializeComponent();
        }

        private void CustomerRegistration_Load(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = textName.Text;
            if (name == "")
            {
                MessageBox.Show("Invalid name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textName.Focus();

                return;

            }

            string phone = txtPhone.Text;
            if (phone == "")
            {
                MessageBox.Show("Invalid Phone", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Focus();

                return;

            }

            string password = txtPass.Text;
            string Cpassword = txtCPass.Text;

            if (password == "")
            {
                MessageBox.Show("Invalid Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Focus();
                return;
            }

            if (Cpassword == "")
            {
                MessageBox.Show("Invalid Confirm Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCPass.Focus();
                return;
            }

            if (password != Cpassword)
            {
                MessageBox.Show("Confirm Password doesn't match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPass.Focus();
                return;
            }

            

            string gender = "";
            if (rbtnMale.Checked == true)
            {
                gender = "male";
            }
            else if (rbtnFemale.Checked == true)
            {
                gender = "Female";
            }
            if (gender == "")
            {
                MessageBox.Show("Invalid gender", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            

            DateTime dob;
            try
            {
                dob = Convert.ToDateTime(txtDTP.Text);
                var age = (DateTime.Now - dob).TotalDays / 365;
                if (age < 18)
                {
                    MessageBox.Show("IV DOB. It should be >= 18", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDTP.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid DOB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDTP.Focus();
                return;
            }

            

            string adress = rtAdress.Text;

            string email = txtEmail.Text;
            if (email == "" || email.Contains("@") == false || email.Contains(".") == false)
            {
                MessageBox.Show("Invalid Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"insert into RegistraTable values('{name}','{email}','{phone}','{password}')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Operation Successful");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Went Wrong");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = false;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            txtCPass.UseSystemPasswordChar = false;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            txtCPass.UseSystemPasswordChar = true;
        }

        private void CustomerRegistration_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginPage ev = new LoginPage();
            ev.Show();
        }
    }
}

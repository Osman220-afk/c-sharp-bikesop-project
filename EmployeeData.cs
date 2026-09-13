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
    public partial class EmployeeData : Form
    {
        public EmployeeData()
        {
            InitializeComponent();
        }

        private void EmployeeData_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void LoadData()
        {
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from OfficeLoginTable";

                DataSet ds = new DataSet();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];

                dgvEmployee.AutoGenerateColumns = false;

                dgvEmployee.DataSource = dt;
                dgvEmployee.Refresh();

                dgvEmployee.ClearSelection();
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Something Went Wrong");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.LoadData();
            this.NewData();
        }

        private void NewData()
        {
            dgvEmployee.ClearSelection();
            txtID.Text = "Auto Genarated";
            txtName.Text = "";
            txtEmail.Text = "";
            txtPass.Text = "";
            txtUser.Text = "";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.NewData();
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtID.Text = dgvEmployee.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dgvEmployee.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtEmail.Text = dgvEmployee.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPass.Text = dgvEmployee.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtUser.Text = dgvEmployee.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            if (id == "Auto Genarated")
            {
                MessageBox.Show("Please Select a row");
                return;
            }

            var result = MessageBox.Show("Are you Sure", "Confermation", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"delete from OfficeLoginTable where Id={id}";
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Operation Complete");
                this.LoadData();
                this.NewData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void button7_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string name = txtName.Text;
            string email = txtEmail.Text;
            string pass = txtPass.Text;
            string user = txtUser.Text;

            string query = "";
            if (id == "Auto Genarated")
            {
                query = $"Insert into OfficeLoginTable values('{name}', '{email}','{pass}', '{user}')";
            }
            else
            {
                query = $"update OfficeLoginTable set Name = '{name}',Email = '{email}',Password = '{pass}',Usertype = '{user}' where ID = {id}";
                
            }

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Operation Complete");
                this.LoadData();
                this.NewData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EmployeeData_FormClosing(object sender, FormClosingEventArgs e)
        {
            AdminPanel ev = new AdminPanel();
            ev.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminPanel ev = new AdminPanel();
            ev.Show();
            this.Hide();
        }
    }
}

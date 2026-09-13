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
using System.Xml.Linq;

namespace BikeShop
{
    public partial class BikeManage : Form
    {
        public BikeManage()
        {
            InitializeComponent();
        }

        private void BikeManage_Load(object sender, EventArgs e)
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
                cmd.CommandText = "select * from BikeInfoTable";

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

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtID.Text = dgvEmployee.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtBrand.Text = dgvEmployee.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtModel.Text = dgvEmployee.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPrice.Text = dgvEmployee.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtStock.Text = dgvEmployee.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.LoadData();
            this.NewData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.NewData();
        }

        private void NewData()
        {
            dgvEmployee.ClearSelection();
            txtID.Text = "Auto Genarated";
            txtBrand.Text = "";
            txtModel.Text = "";
            txtPrice.Text = "";
            txtStock.Text = "";


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
                cmd.CommandText = $"delete from BikeInfoTable where Id={id}";
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
            string brand = txtBrand.Text;
            string model = txtModel.Text;
            string price = txtStock.Text;
            string stock = txtStock.Text;

            string query = "";
            if (id == "Auto Genarated")
            {
                query = $"Insert into BikeInfoTable values('{brand}', '{model}','{price}', '{stock}')";
            }
            else
            {
                query = $"update BikeInfoTable set Brand = '{brand}',Model = '{model}',Price = '{price}',Stock = '{stock}' where ID = {id}";

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

        private void button4_Click(object sender, EventArgs e)
        {
            AdminPanel ap = new AdminPanel();
            ap.Show();
            this.Hide();
        }

        private void BikeManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            AdminPanel ap = new AdminPanel();
            this.Hide();
        }
    }
}

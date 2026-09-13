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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace BikeShop
{
    public partial class EmployeeSalary : Form
    {
        public EmployeeSalary()
        {
            InitializeComponent();
        }

        private void EmployeeSalary_Load(object sender, EventArgs e)
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
                cmd.CommandText = "select ESalaryTable. *, OfficeLoginTable.Name as 'Name' from ESalaryTable inner join OfficeLoginTable on OfficeLoginTable.ID = ESalaryTable.OLID;select* from OfficeLoginTable"; 

                DataSet ds = new DataSet();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];

                dgvEmployee.AutoGenerateColumns = false;

                dgvEmployee.DataSource = dt;
                dgvEmployee.Refresh();

                dgvEmployee.ClearSelection();

                DataTable dt1 = ds.Tables[1];
                cmbEmployee.DataSource = dt1;
                cmbEmployee.ValueMember = "ID";
                cmbEmployee.DisplayMember = "ID";

                DataTable dt2 = ds.Tables[1];
                cmbName2.DataSource = dt2;
                cmbName2.ValueMember = "ID";
                cmbName2.DisplayMember = "Name";

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
                textID.Text = dgvEmployee.Rows[e.RowIndex].Cells[0].Value.ToString();
                cmbEmployee.SelectedValue = dgvEmployee.Rows[e.RowIndex].Cells[1].Value.ToString();
                cmbName2.SelectedValue = dgvEmployee.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSalary.Text = dgvEmployee.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.NewData();
        }

        private void NewData()
        {
            dgvEmployee.ClearSelection();
            textID.Text = "Auto Genarated";
            textSalary.Text = "";
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.LoadData();
            this.NewData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string id = textID.Text;
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
                cmd.CommandText = $"delete from ESalaryTable where Id={id}";
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
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textID.Text;
            string eid = cmbEmployee.SelectedValue.ToString();
            string name = cmbName2.SelectedValue.ToString();
            int salary = Convert.ToInt32(textSalary.Text);

            string query = "";
            if (id == "Auto Genarated")
            {
                query = $"INSERT INTO ESalaryTable VALUES ({eid}, {salary})";
            }
            else
            {
                query = $"UPDATE ESalaryTable SET OLID = {eid},Salary = {salary} WHERE Id = {id}";

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
            AdminPanel ev = new AdminPanel();
            ev.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

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
    public partial class M2ManageCustomer : Form
    {
        public M2ManageCustomer()
        {
            InitializeComponent();
        }
        private void BackBtn_Click(object sender, EventArgs e)
        {
            M2Dashboard dashboard = new M2Dashboard();
            dashboard.Show();
            this.Hide();
        }
       
        private void M2ManageCustomer_Load(object sender, EventArgs e)
        {
            this.LoadData();
            SetPassMode(false);
        }

        private void NewBtn_Click_1(object sender, EventArgs e)
        {
            this.NewData();
            SetPassMode(true);
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            this.LoadData();
            this.NewData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                IdTxtBox.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                NameTxtBox.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                EmailTxtBox.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                PhoneTxtBox.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            SetPassMode(false);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            string id = IdTxtBox.Text;
            if (id == "Auto Generated")
            {
                MessageBox.Show("Please select a Row data to Delete","Delete");
                return;
            }

            var result = MessageBox.Show("Are you want to Delete", "Delete", MessageBoxButtons.YesNo);

            if (result == DialogResult.No) return;

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"delete from RegistraTable where id='{id}'";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted Successfully","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.LoadData();
                this.NewData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Deletion Failed The Customer has an Pending Order","Failed");
                return;
            }
        }
        private void SavBtn_Click_1(object sender, EventArgs e)
        {
            string id = IdTxtBox.Text;
            string Name = NameTxtBox.Text;
            string Email = EmailTxtBox.Text;
            string Phone = PhoneTxtBox.Text;
            string Pass = PassTxtBox.Text;
            string query = "";
            if (Name == "" || Email == "" || Phone == "")
            {
                MessageBox.Show("Please Select Row or Type New Data");
                return;
            }
            if (id == "Auto Generated")
            {
                if (Pass == "")
                {
                    MessageBox.Show("Password is required for new customer");
                    return;
                }
                query = $"insert into RegistraTable  values('{Name}','{Email}','{Phone}','{Pass}')";
            }
            else
            {
                query = $"update RegistraTable set Name='{Name}',Email='{Email}',Phone='{Phone}' where id = '{id}'";
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
                MessageBox.Show("Operation Successfully","Successfull",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.LoadData();
                this.NewData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Operation Failed","Failed");
                return;
            }
        }
        private void LoadData()
        {
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;  // "Data Source=NIHAR-SARKAR-TI\\SQLEXPRESS;Initial Catalog=BShopM;Integrated Security=True;Encrypt=False";
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from RegistraTable";

                DataSet ds = new DataSet();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                dataGridView1.ClearSelection(); //table a selection gayeb kore dei

                con.Close();

                SetPassMode(false);
            }
            catch (Exception e)
            {
                MessageBox.Show("error Loading all data");
                return;
            }
        }

        private void NewData()
        {
            dataGridView1.ClearSelection();
            IdTxtBox.Text = "Auto Generated";
            NameTxtBox.Text = "";
            EmailTxtBox.Text = "";
            PhoneTxtBox.Text = "";
            PassTxtBox.Text = "";
        }

        private void SetPassMode(bool isNew)
        {
            if (isNew)
            {
                PassTxtBox.ReadOnly = false;
                PassTxtBox.Text = "";
            }
            else
            {
                PassTxtBox.ReadOnly = true;
                PassTxtBox.Text = "";
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace BikeShop
{
    public partial class M3Bikeview : Form
    {
        public M3Bikeview()
        {
            InitializeComponent();

        }
        private void M3Bikeview_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        private void LoadData()
        {
         
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from BikeInfoTable";

                DataSet ds = new DataSet();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                DataTable dt = ds.Tables[0];

                

                dgvShowB.DataSource = dt;
                dgvShowB.Refresh();
                dgvShowB.ClearSelection();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing data: " + ex.Message);
            }
        }
      

        private void ShowSearch(){
       try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from BikeInfoTable where Model  like '" + this.textBox1.Text + "%'";

                var adp = new SqlDataAdapter(cmd);
                var ds = new DataSet();
                adp.Fill(ds);

                dgvShowB.AutoGenerateColumns = true;
                dgvShowB.DataSource = ds.Tables[0];

                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void dgvShowB_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BrandTxtBox.Text = dgvShowB.Rows[e.RowIndex].Cells[1].Value.ToString();
                ModelTxtBox.Text = dgvShowB.Rows[e.RowIndex].Cells[2].Value.ToString();
                PriceTxtBox.Text = dgvShowB.Rows[e.RowIndex].Cells[3].Value.ToString();
                CalculateTotalPrice();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.SqlSearch();
        }

        private void SqlSearch()
        {
            
            this.ShowSearch();
        }
        private void CalculateTotalPrice()
        {
            try
            {
                // If price or quantity not selec, show 0
                if (PriceTxtBox.Text == "" || QuantityComBox.SelectedItem == null)
                {
                    TotalTxtBox.Text = "0";
                    return;
                }

                int price = Convert.ToInt32(PriceTxtBox.Text);
                int quantity = Convert.ToInt32(QuantityComBox.SelectedItem);

                int totalPrice = price * quantity;
                TotalTxtBox.Text = totalPrice.ToString();
            }
            catch
            {
                TotalTxtBox.Text = "0";
            }
        }
        private void QuantityComBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            EmailTxtBox.Text = "";
            IdTxtBox.Text = "";
            BrandTxtBox.Text = "";
            ModelTxtBox.Text = "";
            PriceTxtBox.Text = "";
            TotalTxtBox.Text = "0";
            QuantityComBox.SelectedIndex = -1;
            LoadData();
        }

        private void PlaceOrderBtn_Click(object sender, EventArgs e)
        {
            string Email= EmailTxtBox.Text;
            string Id = IdTxtBox.Text;
            string Brand = BrandTxtBox.Text;
            string Model = ModelTxtBox.Text;
            string Price = PriceTxtBox.Text;
            if (QuantityComBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a quantity.", "Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string Quantity = QuantityComBox.SelectedItem.ToString();
            string Total = TotalTxtBox.Text;
            if (Email == "" || Id == "" || Brand == "" || Model == "" || Price == "" || Quantity == null || Total == "") //string.IsNullOrEmpty(Quantity) avabew check kora jai
            {
                MessageBox.Show("Please fill in all fields to place an order.", "Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id;
            int price;
            int quantity;
            int total;
            try
            {
                id = Int32.Parse(Id);
                price = Int32.Parse(Price);
                quantity = Int32.Parse(Quantity);
                total = Int32.Parse(Total);
            }
            catch(Exception) 
            {
                MessageBox.Show("Invalid  data. Please check the values entered.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = cmd.CommandText = $"insert into OrderTable values({id},'{Brand}','{Model}',{quantity},{total})";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Order Placed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Place Order", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            string Email = EmailTxtBox.Text;
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select id from RegistraTable where Email  = '" + Email + "'";
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int id = Convert.ToInt32(result);
                    IdTxtBox.Text = id.ToString();
                    MessageBox.Show("Id Found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Enter a valid Email Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search operation failed please select valid email");
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            M3customerpanel ad = new M3customerpanel();
            ad.Show();
            this.Hide();
        }
    }
}

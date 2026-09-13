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
    public partial class M2PlaceOrder : Form
    {
        public M2PlaceOrder()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                BrandTxtBox.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                ModelTxtBox.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                PriceTxtBox.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                InStockTxtBox.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                calculateTotal();
            }

        }
        private void M2PlaceOrder_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            LoadData();
            NewData();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            M2Dashboard dashboard = new M2Dashboard();
            dashboard.Show();
            this.Hide();   
        }
        private void QuanComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            calculateTotal();
        }

        private void DiscountNumeUD_ValueChanged(object sender, EventArgs e)
        {
            calculateTotal();
        }

        private void CheckoutBtn_Click(object sender, EventArgs e)
        {
            string Id = IdTxtBox.Text;
            string Email = EmailTxtBox.Text;
            string Brand = BrandTxtBox.Text;
            string Model = ModelTxtBox.Text;
            string instock = InStockTxtBox.Text;
            if (QuanComBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a quantity.", "Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string Quantity = QuanComBox.SelectedItem.ToString();
            string Total = TotalTxtBox.Text;
            string Ref = RefTxtBox.Text;
            DateTime dt = DateTime.Now.Date;
            string date = dt.ToString("yyyy-MM-dd");

            if(Id == "" || Email == "" || Brand == "" || Model == "" || Quantity == null || Total == "" || Ref == "")
            {
                MessageBox.Show("Please Select Customer and Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int id;
            int quantity;
            double total;
            int stock;
            try
            {  
                id = Convert.ToInt32(Id);
                quantity = Convert.ToInt32(Quantity);
                total = Convert.ToDouble(Total);
                stock = Convert.ToInt32(instock);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid data", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(quantity > stock)
            {
                MessageBox.Show("Insufficient stock please select a lower quantity", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"insert into SalesTable values ({id}, '{Email}', '{Brand}', '{Model}', {Quantity}, {total}, '{Ref}', CONVERT(DATE, '{date}'))";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Order placed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reduceStock();
                NewData();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error placing order: " + ex.Message);
                return;
            }
        }
      

        private void SrcBtn_Click(object sender, EventArgs e)
        {
       
            string Email = EmailTxtBox.Text;
            if(Email =="")
            {
                MessageBox.Show("Please enter an email address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select ID, Name, Phone from RegistraTable where Email  = '{Email}'";

                var adapter = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    IdTxtBox.Text = dt.Rows[0]["ID"].ToString();
                    NameTxtBox.Text = dt.Rows[0]["Name"].ToString();
                    PhoneTxtBox.Text = dt.Rows[0]["Phone"].ToString();

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
                return; 
            }

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
                cmd.CommandText = "select Brand,Model,Price,Stock from BikeInfoTable";

                DataSet ds = new DataSet();
                var adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                dataGridView1.ClearSelection();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing data: " + ex.Message);
                return;
            }
        }
        private void NewData()
        {
            IdTxtBox.Text = "";
            NameTxtBox.Text = "";
            EmailTxtBox.Text = "";
            PhoneTxtBox.Text = "";
            BrandTxtBox.Text = "";
            ModelTxtBox.Text = "";
            PriceTxtBox.Text = "";
            InStockTxtBox.Text = "";
            QuanComBox.SelectedIndex = -1;
            SubTotalTxtBox.Text = "";
            DiscountNumeUD.Value = 0;
            RefTxtBox.Text = "";
            TotalTxtBox.Text = "";
        }
        private void reduceStock()
        {
            int qty = Convert.ToInt32(QuanComBox.SelectedItem);
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"update BikeInfoTable set Stock = Stock - {qty} where Brand = '{BrandTxtBox.Text}' and Model = '{ModelTxtBox.Text}'";
                cmd.ExecuteNonQuery();
                con.Close();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reducing stock: " + ex.Message);
                return;
            }
        }


        private void calculateTotal()
        {
            try
            {
                if (PriceTxtBox.Text == "" || QuanComBox.SelectedItem == null)
                {
                    TotalTxtBox.Text = "0";
                    return;
                }
                double price = Convert.ToDouble(PriceTxtBox.Text);
                int quantity = Convert.ToInt32(QuanComBox.SelectedItem);
                double subtotal = price * quantity;
                SubTotalTxtBox.Text = subtotal.ToString();
                int dis = (int)DiscountNumeUD.Value;
                double discount = (subtotal * dis) / 100;
                double total = subtotal - discount;
                TotalTxtBox.Text = total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating total: " + ex.Message);
                return;
            }
        }
    }
}

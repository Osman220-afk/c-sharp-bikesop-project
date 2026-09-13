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
    public partial class M2AccpetOrder : Form
    {
        public M2AccpetOrder()
        {
            InitializeComponent();
        }

        private void M2AccpetOrder_Load(object sender, EventArgs e)
        {
            LoadData();
        }
       
        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            LoadData();
            NewData();
        }
       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                OrderIdTxtBox.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                CustomerIdTxtBox.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                EmailTxtBox.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                BrandTxtBox.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                ModelTxtBox.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                QuantityTxtBox.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                TotalTxtBox.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                Stock();
            } 
        }
        private void AcceptBtn_Click(object sender, EventArgs e)
        {
            string CustomerId = CustomerIdTxtBox.Text;
            string Email = EmailTxtBox.Text;
            string Brand = BrandTxtBox.Text;
            string Model = ModelTxtBox.Text;
            string Quantity = QuantityTxtBox.Text;
            string Total = TotalTxtBox.Text;
            string Ref = RefTxtBox.Text;
            DateTime dt = DateTime.Now.Date;
            string date = dt.ToString("yyyy-MM-dd");
            if (CustomerId == "" || Email == "" || Brand == "" || Model == "" || Quantity == "" || Total == "" || Ref == "")
            {
                MessageBox.Show("Please Select order and Reference/Your Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int customerid;
            int quantity;
            double total;
            int stock;
            try
            {
                customerid = Convert.ToInt32(CustomerId);
                quantity = Convert.ToInt32(Quantity);
                total = Convert.ToDouble(Total);
                stock = Convert.ToInt32(StockTxtBox.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid data. Please check the values entered.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(quantity > stock)
            {
                MessageBox.Show("Insufficient stock Decline order or Wait for restock", "Stock", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"insert into SalesTable values ({customerid}, '{Email}', '{Brand}', '{Model}', {quantity}, {total}, '{Ref}', CONVERT(DATE, '{date}'))";
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Order placed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reduceStock();
                deleteOrder();
                NewData();
                LoadData();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error accepting order: " + ex.Message);
                return;
            }
        }

        private void DeclineBtn_Click(object sender, EventArgs e)
        {
            if (OrderIdTxtBox.Text == "")
            {
                MessageBox.Show("Please select an Order to delete");
                return;
            }
            deleteOrder();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            M2Dashboard dashboard = new M2Dashboard();
            dashboard.Show();
            this.Hide();
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
                cmd.CommandText = "select o.Orderid, r.ID AS CustomerID, r.Name, r.Email, r.Phone, o.Brand, o.Model, o.Quantity, o.Total from OrderTable o inner join RegistraTable r on o.Customerid = r.ID";

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
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }
        private void NewData()
        {
            CustomerIdTxtBox.Text = "";
            EmailTxtBox.Text = "";
            QuantityTxtBox.Text = "";
            TotalTxtBox.Text = "";
            BrandTxtBox.Text = "";
            ModelTxtBox.Text = "";
            RefTxtBox.Text = "";
            dataGridView1.ClearSelection();
        }
        private void deleteOrder()
        {
            int orderid;
            try
            {
                orderid = Convert.ToInt32(OrderIdTxtBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("order id conversion failed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();
                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"delete from OrderTable where Orderid = {orderid}";
                cmd.ExecuteNonQuery();
                MessageBox.Show("Order Process successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting order: " + ex.Message);
                return;
            }
        }
        private void reduceStock()
        {
            int qty = Convert.ToInt32(QuantityTxtBox.Text);
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
                NewData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reducing stock: " + ex.Message);
                return;
            }
        }
        private void Stock()
        {
            string Brand = BrandTxtBox.Text;
            string Model = ModelTxtBox.Text;
            try
            {
                var con = new SqlConnection();
                con.ConnectionString = ApplicationHelper.cs;
                con.Open();

                var cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = $"select stock from BikeInfoTable where Brand  = '{Brand}'  and Model = '{Model}'";
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    int stock = Convert.ToInt32(result);
                    StockTxtBox.Text = stock.ToString();
                }
                else
                {
                    MessageBox.Show("Bike not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Stock operation failed please select valid bike");
                return;
            }
        }


    }
}

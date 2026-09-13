using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BikeShop
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AdminPanel_FormClosing(object sender, FormClosingEventArgs e)
        {

            OfficialsLogin ev = new OfficialsLogin();
            ev.Show();
        }

        private void empButton_Click(object sender, EventArgs e)
        {
            EmployeeData ev = new EmployeeData();
            ev.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EmployeeSalary ev = new EmployeeSalary();
            ev.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BikeManage ev = new BikeManage();
            ev.Show();
            this.Hide();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {

        }
    }
}

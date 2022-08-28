using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class ManageStock : Form
    {
        public ManageStock()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminDashboard admin = new AdminDashboard();
            admin.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductCategories products = new ProductCategories();
            products.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageProducts manageProd = new ManageProducts();
            manageProd.Show();
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewStock viewstock = new ViewStock();
            viewstock.Show();
            Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Settings setting = new Settings();
            setting.Show();
            Visible = false;
        }
    }
}

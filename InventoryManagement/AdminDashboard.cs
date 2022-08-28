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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddNew newAttendant = new AddNew();
            newAttendant.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductCategories prodCat = new ProductCategories();
            prodCat.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ManageProducts mProducts = new ManageProducts();
            mProducts.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ManageStock stock = new ManageStock();
            stock.Show();
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewStock vStock = new ViewStock();
            vStock.Show();
            Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set.Show();
            Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddNew add = new AddNew();
            add.Show();
            Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SalesReport sales = new SalesReport();
            sales.Show();
            Visible = false;
        }
    }
}

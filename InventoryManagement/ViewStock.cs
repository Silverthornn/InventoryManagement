using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace InventoryManagement
{
    public partial class ViewStock : Form
    {
        public ViewStock()
        {
            InitializeComponent();
        }

        private void fetchProducts()
        {
            string query = "select * from product";
            DataSet ds  = new DataSet();
            DataView dv;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            try
            {
                dbClass.openConnection();
                MySqlCommand command = new MySqlCommand(query, dbClass.connection);
                adapter.SelectCommand = command;
                adapter.Fill(ds);
                dbClass.closeConnection();

                dv = ds.Tables[0].DefaultView;
                dataGridView1.DataSource = dv;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ManageProducts manageP = new ManageProducts();
            manageP.Show();
            Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ManageProducts manageP = new ManageProducts();
            manageP.Show();
            Visible = false;
        }

        private void ViewStock_Load(object sender, EventArgs e)
        {
            fetchProducts();
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

        private void button3_Click(object sender, EventArgs e)
        {
            ManageStock stock = new ManageStock();
            stock.Show();
            Visible = false;
        }
    }
}

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
    public partial class ManageStock : Form
    {
        public ManageStock()
        {
            InitializeComponent();
        }

        private void managestock()
        {
            string query = "select * from stockmanagement where category = '" +comboBox1.DisplayMember+ "' ";
            DataSet ds = new DataSet();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void ManageStock_Load(object sender, EventArgs e)
        {
            dbClass.openConnection();
            MySqlCommand command;
            string query = "select * from productcategory";
            command = new MySqlCommand(query, dbClass.connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString("Name"));
            }

            dbClass.closeConnection();
            managestock();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            managestock();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            dbClass.openConnection();
            MySqlCommand command;

            try
            {
                string query = "insert into stockmanagement(reorder level) values ('" + textBox1.Text + "')";
                command = new MySqlCommand(query, dbClass.connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Reorder level has been set!");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            managestock();
            dbClass.closeConnection();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dbClass.openConnection();
            MySqlCommand command;

            try
            {
                string query = "update stockmanagement set reorder level = '" + textBox1.Text + "' ";
                command = new MySqlCommand(query, dbClass.connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Reorder level updated succesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            managestock();
            dbClass.closeConnection();
        }
    }
}

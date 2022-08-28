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
    public partial class ProductCategories : Form
    {
        public ProductCategories()
        {
            InitializeComponent();
        }

        private void fetchProductCategories()
        {
            string query = "select * from productcategory";
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

        private void button7_Click(object sender, EventArgs e)
        {
            dbClass.openConnection();
            MySqlCommand command;
            if (textBox1.Text != "" & textBox2.Text != "")
            {
                try
                {
                    string countQuerry = "select count(*) from productcategory where name = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuerry, dbClass.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Category has already been added!");
                    }
                    else
                    {
                        string query = "insert into productcategory values ('" + textBox1.Text + "', '" + textBox2.Text + "')";
                        command = new MySqlCommand(query, dbClass.connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("New product added succesfully!");
                        
                        dbClass.closeConnection();
                        fetchProductCategories();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Please make sure every field is complete");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dbClass.openConnection();
            MySqlCommand command;
            if (textBox1.Text != "")
            {
                try
                {
                    string countQuerry = "select count(*) from productcategory where name = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuerry, dbClass.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        string query = "delete from productcategory where  name = '" + textBox1.Text + "' ";
                        command = new MySqlCommand(query, dbClass.connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Category deleted succesfully!");
                        
                        dbClass.closeConnection();
                        fetchProductCategories();
                    }
                    else
                    {

                        MessageBox.Show("User doesn't exist!");
                        dbClass.closeConnection();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("Please make sure every field is complete");
            }
        }

        private void ProductCategories_Load(object sender, EventArgs e)
        {
            fetchProductCategories();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AdminDashboard admin = new AdminDashboard();
            admin.Show();
            Visible = true;
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

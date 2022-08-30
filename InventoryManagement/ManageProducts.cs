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
    public partial class ManageProducts : Form
    {
        public ManageProducts()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dbClass.openConnection();
            MySqlCommand command;
            if (textBox1.Text != "" & textBox2.Text != "")
            {
                try
                {
                    string countQuerry = "select count(*) from product where product_name = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuerry, dbClass.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Product has already been added!");
                    }
                    else
                    {
                        string query = "insert into product(Product_Name, Product Category, Price, Quantity) values ('" + textBox1.Text + "','"+ comboBox1.DisplayMember +"', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')";
                        command = new MySqlCommand(query, dbClass.connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("New product added succesfully!");
                        ViewStock stock = new ViewStock();
                        stock.Show();
                        Visible = false;
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

        private void button9_Click(object sender, EventArgs e)
        {
            dbClass.openConnection();
            MySqlCommand command;
            if (textBox1.Text != "")
            {
                try
                {
                    string countQuerry = "select count(*) from product where product_name = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuerry, dbClass.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        string query = "delete from product where  name = '" + textBox1.Text + "' ";
                        command = new MySqlCommand(query, dbClass.connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Attendant deleted succesfully!");
                        ViewStock stock = new ViewStock();
                        stock.Show();
                        Visible = false;
                        dbClass.closeConnection();
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

        private void button8_Click(object sender, EventArgs e)
        {
            dbClass.openConnection();
            MySqlCommand command;
            if (textBox1.Text != "")
            {
                try
                {
                    string countQuerry = "select count(*) from product where product_name = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuerry, dbClass.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        string query = "update table product where  product_name = '" + textBox1.Text + "' ";
                        command = new MySqlCommand(query, dbClass.connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Product details succesfully updated!");
                        ViewStock stock = new ViewStock();
                        stock.Show();
                        Visible = false;
                        dbClass.closeConnection();
                    }
                    else
                    {

                        MessageBox.Show("Product doesn't exist!");
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

        private void ManageProducts_Load(object sender, EventArgs e)
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
            
        }
    }
}

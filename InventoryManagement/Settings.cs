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
    public partial class Settings : Form
    {
        public Settings()
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
                    string countQuerry = "select count(*) from admin where aid = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuerry, dbClass.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("User already exists!");
                    }
                    else
                    {
                        string query = "insert into admin values ('" + textBox1.Text + "', '" + textBox2.Text + "')";
                        command = new MySqlCommand(query, dbClass.connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("New admin added succesfully!");
                        AdminDashboard admin = new AdminDashboard();
                        admin.Show();
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

        private void button8_Click(object sender, EventArgs e)
        {
            dbClass.openConnection();
            MySqlCommand command;
            if (textBox1.Text != "")
            {
                try
                {
                    string countQuerry = "select count(*) from admin where aid = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuerry, dbClass.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        string query = "delete from admin where  name = '" + textBox1.Text + "' ";
                        command = new MySqlCommand(query, dbClass.connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Admin deleted succesfully!");
                        AdminDashboard admin = new AdminDashboard();
                        admin.Show();
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
            ManageStock stocks = new ManageStock();
            stocks.Show();
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ViewStock viewstock = new ViewStock();
            viewstock.Show();
            Visible = false;
        }
    }
}

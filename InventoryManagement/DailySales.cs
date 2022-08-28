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
    public partial class DailySales : Form
    {
        public DailySales()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                        MessageBox.Show("User already exists!");
                    }
                    else
                    {
                        string query = "insert into dailytransactions values ('" + textBox1.Text + "', '" + textBox2.Text + "')";
                        command = new MySqlCommand(query, dbClass.connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("New attendant added succesfully!");
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

        private void DailySales_Load(object sender, EventArgs e)
        {
            dbClass.openConnection();
            MySqlCommand command;
            string query = "select name from productcategory";
            command = new MySqlCommand(query, dbClass.connection);
            command.ExecuteNonQuery();
            comboBox1.DataSource = query.ToList();
            comboBox1.ValueMember = "Name";
            comboBox1.DisplayMember = "Name";
        }
    }
}

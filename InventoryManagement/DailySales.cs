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

        

        private void fetchSales()
        {
            string query = "select * from printSales";
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
                    if (count <= 0)
                    {
                        MessageBox.Show("Product is out of stock!");
                    }
                    else
                    {
                        string query = "insert into dailytransactions(Product_Name, Quantity) values ('" + textBox1.Text + "', '" + textBox2.Text + "')";
                        command = new MySqlCommand(query, dbClass.connection);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Transaction Succesfully Added!");

                        string otherquery = "insert into printSales(Product_Name, Quantity) values ('" + textBox1.Text + "', '" + textBox2.Text + "')";
                        command = new MySqlCommand(query, dbClass.connection);
                        command.ExecuteNonQuery();
                        

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
            string query = "select * from productcategory";
            command = new MySqlCommand(query, dbClass.connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString("Name"));
            }

            dbClass.closeConnection();

            fetchSales();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StartTill till = new StartTill();
            till.Show();
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            printDocument1.Print(); ;
        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }
    }
}

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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbClass.openConnection();
            MySqlCommand command;
            if(textBox1.Text != "" & textBox2.Text !="")
            {
                try
                {
                    string countQuerry = "select count(*) from inventorymanager where aid = '" + textBox1.Text + "' ";
                    command = new MySqlCommand(countQuerry, dbClass.connection);
                    Int32 count = Convert.ToInt32(command.ExecuteScalar());
                    if (count > 0)
                    {
                        AdminDashboard admin = new AdminDashboard();
                        admin.Show();
                        Visible = false;
                        dbClass.closeConnection();
                    }
                    else
                    {
                        MessageBox.Show("Invalid account credentials please try again");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
            else
            {
                MessageBox.Show("Please make sure every field is complete");
            }
        }
    }
}

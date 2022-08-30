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
    public partial class StockLedger : Form
    {
        public StockLedger()
        {
            InitializeComponent();
        }

        private void fetchTransactions()
        {
            string query = "select * from dailytransactions";
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
            StartTill starttill = new StartTill();
            starttill.Show();
            Visible = false;
        }

        private void StockLedger_Load(object sender, EventArgs e)
        {
            fetchTransactions();
        }
    }
}

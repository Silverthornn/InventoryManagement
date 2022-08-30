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
    public partial class StartTill : Form
    {
        public StartTill()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DailySales sales  =  new  DailySales();
            sales.Show();
            Visible  =  false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StockLedger ledger = new StockLedger();
            ledger.Show();
            Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            Visible = false;
        }
    }
}

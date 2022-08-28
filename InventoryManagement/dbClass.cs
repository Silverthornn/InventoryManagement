using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace InventoryManagement
{
    internal class dbClass
    {
        public static string connectionString = "server=localhost: database=admin; uid=root; pwd=\"\";";
        public static MySqlConnection connection = new MySqlConnection(connectionString);

        public static void openConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error trying to connect database");
            }
           
        }

        public static void closeConnection()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error trying to close database");
            }

        }
    }
}

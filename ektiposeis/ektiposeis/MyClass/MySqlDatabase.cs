using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ektiposeis.MyClass
{
    public class MySqlDatabase
    {
        String connectionString = "";
        MySqlConnection myConnection;
        public void connect(String _connectionString)
        {
            try
            {
                connectionString = _connectionString;
                myConnection = new MySqlConnection();
                myConnection.ConnectionString = connectionString;
                myConnection.Open();
            }
            catch(MySqlException ex) 
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void connectionClose() 
        {
            try
            {
                myConnection.Close();
            }
            catch (MySqlException ex) 
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public DataTable select(String sql, String tableName) 
        {
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sql, myConnection);
            DataTable dt = new DataTable(tableName);
            mySqlDataAdapter.Fill(dt);
            return dt;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ektiposeis.MyClass
{
    public class Database
    {
        String DBMS = "";
        public Database(String dbms) 
        {
            DBMS = dbms;
        }
        public void connectInDatabase(String connectionString) 
        {
            try
            {
                switch (DBMS)
                {
                    case "postgreSQL":
                        PostgreSqlDatabase postgreSqlDatabase = new PostgreSqlDatabase();
                        postgreSqlDatabase.connect(connectionString);
                        break;
                    case "oracleDB":
                        OracleDatabase oracleDatabase = new OracleDatabase();
                        oracleDatabase.connect(connectionString);
                        break;
                    case "sqlServer":
                        SqlServerDatabase sqlServerDatabase = new SqlServerDatabase();
                        sqlServerDatabase.connect(connectionString);
                        break;
                    case "mySql":
                        MySqlDatabase mySqlDatabase = new MySqlDatabase();
                        mySqlDatabase.connect(connectionString);
                        break;
                }
            }
            catch
            {
                MessageBox.Show("Δεν κατέστη δυνατή η σύνδεση με τη βάση.");
            }
        }
        public DataTable select(String sql, String returnTableName) 
        {
            try
            {
                switch (DBMS)
                {
                    case "postgreSQL":
                        break;
                    case "oracleDB":
                        break;
                    case "sqlServer":
                        break;
                    case "mySql":
                        MySqlDatabase mySqlDatabase = new MySqlDatabase();
                        DataTable returnDataTable = mySqlDatabase.select(sql, returnTableName);
                        return returnDataTable;
                }
            }
            catch
            {
                MessageBox.Show("Παρουσιάστικε σφάλμα κατα την εκτέλεση του ερωτήματος:\n" + sql);
            }
            return null;
        }
    }
}

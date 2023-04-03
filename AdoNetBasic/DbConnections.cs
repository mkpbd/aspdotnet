using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetBasic
{
    public class DbConnections
    {

        public static SqlConnection Connection()
        {
            string connectionString = $"data source=SERVER\\MSSQLSERVER01; database=AdoDotNet35Cookbook; integrated security=SSPI";

            SqlConnection sqlConnection = new SqlConnection(connectionString);  
            sqlConnection.Open();
            return sqlConnection;
        }
    }
}

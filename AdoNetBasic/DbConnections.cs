

using System.Data.SqlClient;

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

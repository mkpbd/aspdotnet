using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotnetTutorials.BasicOperation
{
    public class DbSqlConnection
    {
        public SqlConnection Connecting(string dbName= "StudentDB")
        {
            string ConnectionString = $"data source=.; database={dbName}; integrated security=SSPI";
            SqlConnection con = new SqlConnection(ConnectionString);
            
                con.Open();
                Console.WriteLine("Connection Established Successfully");

            return con;
            
        }
    }

}

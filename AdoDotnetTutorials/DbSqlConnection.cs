using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotnetTutorials
{
    public class DbSqlConnection
    {
         static string ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        public static SqlConnection Connecting(string dbName = "StudentDB")
        {
            string ConnectionString = $"data source=SERVER\\MSSQLSERVER02; database={dbName}; integrated security=SSPI";
            SqlConnection con = new SqlConnection(ConnectionString);
            // SqlConnection con = new SqlConnection(ConString);

            con.Open();
            Console.WriteLine("Connection Established Successfully");

            return con;

        }
    }

}

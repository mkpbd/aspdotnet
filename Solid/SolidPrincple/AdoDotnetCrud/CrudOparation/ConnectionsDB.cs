using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotnetCrud.CrudOparation
{
    public class ConnectionsDB
    {
      

        //  string ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public static SqlConnection Connection(string dbName = "StudentDB")
        {
             string ConnectionString = $"data source=SERVER\\MSSQLSERVER02; database={dbName}; integrated security=SSPI";
            SqlConnection conn = new SqlConnection(ConnectionString);


                conn.Open();

            return conn;





        }


    }
}

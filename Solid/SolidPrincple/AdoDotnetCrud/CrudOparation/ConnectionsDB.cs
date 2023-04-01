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
        static string ConnectionString = "data source=SERVER\\MSSQLSERVER02; database=StudentDB; integrated security=SSPI";

        //  string ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public static SqlConnection Connection()
        {

            SqlConnection conn = new SqlConnection(ConnectionString);


                conn.Open();

            return conn;





        }


    }
}

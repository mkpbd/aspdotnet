using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotnetCrud.CrudOparation
{
    public class AdoNetDeleteRecord
    {
        public void DeleteData()
        {


            try
            {
                string delelteDataById = "delete from student where id = '101'";

                using (SqlCommand cm = new SqlCommand(delelteDataById, ConnectionsDB.Connection()))
                {

                    // Executing the SQL query  
                    cm.ExecuteNonQuery();
                    Console.WriteLine("Record Deleted Successfully");

                }


            }
            catch (Exception ex)
            {

            }










        }

    }
}


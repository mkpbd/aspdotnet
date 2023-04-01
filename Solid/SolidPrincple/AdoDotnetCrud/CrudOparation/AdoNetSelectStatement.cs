using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotnetCrud.CrudOparation
{
    public class AdoNetSelectStatement
    {

        public void GetSelectDataFromStudent()
        {

            try
            {
                // Creating SqlCommand objcet   
                SqlCommand cm = new SqlCommand("select * from student", ConnectionsDB.Connection());
                // Opening Connection  
                // connection.Open();
                // Executing the SQL query  
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["Name"] + ",  " + sdr["Email"] + ",  " + sdr["Mobile"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + ex.Message);

            }
        }



        public void DataSelectBySqlCommandObject()
        {
            try
            {
                // Creating SqlCommand objcet 
                using (SqlCommand cm = new SqlCommand())
                {

                    cm.CommandText = "select * from student";
                    cm.Connection = ConnectionsDB.Connection();

                    // Executing the SQL query  

                    SqlDataReader sdr = cm.ExecuteReader();

                    while (sdr.Read())
                    {
                        Console.WriteLine(sdr["Name"] + ",  " + sdr["Email"] + ",  " + sdr["Mobile"]);
                    }

                }
            }catch(Exception ex)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + ex);
            }

        }
    }
}

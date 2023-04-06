using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotnetTutorials.BasicOperation
{
    public class SqlCommandObjectAndMethods
    {

        //-------------- ExecuteReader -----------------
        public void SqlCommandExecuteRedear()
        {
            try
            {
                string ConString = "data source=.; database=StudentDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    // Creating SqlCommand objcet   
                    SqlCommand cm = new SqlCommand("select * from student", connection);

                    // Opening Connection  
                    connection.Open();

                    // Executing the SQL query  
                    SqlDataReader sdr = cm.ExecuteReader();
                    while (sdr.Read())
                    {
                        Console.WriteLine(sdr["Name"] + ",  " + sdr["Email"] + ",  " + sdr["Mobile"]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            Console.ReadKey();
        }


        // Understanding Sql Command Object 

        public void SqlCommandOtject()
        {
            try
            {
                string ConString = "data source=.; database=StudentDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    // Creating SqlCommand objcet 
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select * from student";
                    cmd.Connection = connection;
                    // Opening Connection  
                    connection.Open();
                    // Executing the SQL query  
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        Console.WriteLine(sdr["Name"] + ",  " + sdr["Email"] + ",  " + sdr["Mobile"]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            Console.ReadKey();
        }

        //-------------- ExecuteScalar Method of SqlCommand Object in C#:
        public void ExecuteScalarMethod()
        {

            try
            {
                string ConString = "data source=.; database=StudentDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    // Creating SqlCommand objcet 
                    SqlCommand cmd = new SqlCommand("select count(id) from student", connection);
                    // Opening Connection  
                    connection.Open();
                    // Executing the SQL query  
                    // Since the return type of ExecuteScalar() is object, we are type casting to int datatype
                    int TotalRows = (int)cmd.ExecuteScalar();
                    Console.WriteLine("TotalRows in Student Table :  " + TotalRows);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            Console.ReadKey();
        }


        //------------------- ExecuteNonQuery Method of ADO.NET SqlCommand Object in C#:


        /*
         * 
         * When you want to perform Insert, Update or Delete operations and want to return the number of rows affected by your query then you need to use the ExecuteNonQuery method of the SqlCommand object in C#. Let us understand this with an example. The following example performs Insert, Update and Delete operations using the ExecuteNonQuery() method
         * 
         */
        public void ExecuteNonQueryMethod()
        {
            try
            {
                string ConString = "data source=.; database=StudentDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    SqlCommand cmd = new SqlCommand("insert into Student values (105, 'Ramesh', 'Ramesh@dotnettutorial.net', '1122334455')", connection);
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Inserted Rows = " + rowsAffected);
                    //Set to CommandText to the update query. We are reusing the command object, 
                    //instead of creating a new command object
                    cmd.CommandText = "update Student set Name = 'Ramesh Changed' where Id = 105";
                    rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Updated Rows = " + rowsAffected);
                    //Set to CommandText to the delete query. We are reusing the command object, 
                    //instead of creating a new command object
                    cmd.CommandText = "Delete from Student where Id = 105";

                    rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine("Deleted Rows = " + rowsAffected);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            Console.ReadKey();
        }


    }





    }
}

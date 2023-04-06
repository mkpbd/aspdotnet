using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotnetTutorials.BasicOperation
{
    public class ADONETSqlDataReader
    {
        public void SqlDataReader()
        {
            try
            {
                string ConString = "data source=.; database=StudentDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    // Creating the command object
                    SqlCommand cmd = new SqlCommand("select Name, Email, Mobile from student", connection);
                    // Opening Connection  
                    connection.Open();
                    // Executing the SQL query  
                    SqlDataReader sdr = cmd.ExecuteReader();
                    //Looping through each record
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


        //------------------ Example: SqlDataReader Active and Open Connection in C#


        public void SqlDataReaderActiveAndOpenConnection()
        {
            try
            {
                string ConString = @"data source=.; database=StudentDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    // Creating the command object
                    SqlCommand cmd = new SqlCommand("select Name, Email, Mobile from student", connection);
                    // Opening Connection  
                    connection.Open();
                    // Executing the SQL query  
                    SqlDataReader sdr = cmd.ExecuteReader();
                    // Closing the Connection  
                    connection.Close();
                    //Reading Data from Reader will give runtime error as the connection is closed
                    while (sdr.Read())
                    {
                        Console.WriteLine(sdr[0] + ",  " + sdr[1] + ",  " + sdr[2]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e.Message);
            }
            Console.ReadKey();
        }



        //=========== Example to Understand NextResult Method of DataReader Object: ===============

        public void NextResultMethodDataReader()
        {
            try
            {
                string ConString = @"data source=SERVER\MSSQLSERVER02; database=ShoppingCartDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    // Creating the command object
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Customers; SELECT * FROM Orders", connection);
                    // Opening Connection  
                    connection.Open();
                    // Executing the SQL query  
                    SqlDataReader reader = cmd.ExecuteReader();
                    //Looping through First Result Set
                    Console.WriteLine("First Result Set:");
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0] + ",  " + reader[1] + ",  " + reader[2]);
                    }
                    //To retrieve the second result set from SqlDataReader object, use the NextResult(). 
                    //The NextResult() method returns true and advances to the next result-set.
                    while (reader.NextResult())
                    {
                        Console.WriteLine("\nSecond Result Set:");
                        //Looping through each record
                        while (reader.Read())
                        {
                            Console.WriteLine(reader[0] + ",  " + reader[1] + ",  " + reader[2]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();
        }




    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotnetTutorials.BasicOperation
{
    public class UnderstandingSqlDataAdopter
    {


        public void SqlDataAdapter()
        {

            try
            {
                string ConString = @"data source=SERVER\MSSQLSERVER02; database=StudentDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from student", connection);
                    //Using Data Table
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //The following things are done by the Fill method
                    //1. Open the connection
                    //2. Execute Command
                    //3. Retrieve the Result
                    //4. Fill/Store the Retrieve Result in the Data table
                    //5. Close the connection
                    Console.WriteLine("Using Data Table");
                    //Active and Open connection is not required
                    //dt.Rows: Gets the collection of rows that belong to this table
                    //DataRow: Represents a row of data in a DataTable.
                    foreach (DataRow row in dt.Rows)
                    {
                        //Accessing using string Key Name
                        Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                        //Accessing using integer index position
                        //Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                    }
                    Console.WriteLine("---------------");
                    //Using DataSet
                    DataSet ds = new DataSet();
                    da.Fill(ds, "student"); //Here, the datatable student will be stored in Index position 0
                    Console.WriteLine("Using Data Set");
                    //Tables: Gets the collection of tables contained in the System.Data.DataSet.
                    //Accessing the datatable from the dataset using the datatable name
                    foreach (DataRow row in ds.Tables["student"].Rows)
                    {
                        //Accessing the data using string Key Name
                        Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                        //Accessing the data using integer index position
                        //Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                    }
                    //Accessing the datatable from the dataset using the datatable index position
                    //foreach (DataRow row in ds.Tables[0].Rows)
                    //{
                    //    Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                    //}
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            Console.ReadKey();
        }


        // C# SqlDataAdapter using SQL Server Stored Procedure:

        public void SqlDataAdapterSqlServerStoreProcedure()
        {
            try
            {
                string ConString = "data source=.; database=StudentDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConString))
                {

                    SqlDataAdapter da = new SqlDataAdapter("spGetStudents", connection);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                    }
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

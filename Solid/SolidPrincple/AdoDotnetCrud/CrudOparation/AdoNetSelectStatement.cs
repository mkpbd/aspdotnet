using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            }
            catch (Exception ex)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + ex);
            }

        }



        public void GetSelectDataRowByDataAdopter()
        {
            string SelectStudentData = "select * from student";
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(SelectStudentData, ConnectionsDB.Connection()))
            {

                // Using Data Table
                DataTable dt = new DataTable();

                dataAdapter.Fill(dt);
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
                dataAdapter.Fill(ds, "student"); //Here, the datatable student will be stored in Index position 0
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



            }

        }



    }
}

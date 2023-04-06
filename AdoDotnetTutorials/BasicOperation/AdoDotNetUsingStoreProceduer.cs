using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotnetTutorials.BasicOperation
{
    public class AdoDotNetUsingStoreProceduer
    {
        // ============= Example to understand how to Call a Stored Procedure in C# without Parameters: 

        public void CallStoredProcedure()
        {
            try
            {
                //Store the connection string in the ConnectionString variable
                string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=StudentDB; integrated security=SSPI";
                //Create the SqlConnection object
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //Create the SqlCommand object by passing the stored procedure name and connection object as parameters
                    SqlCommand cmd = new SqlCommand("spGetStudents", connection)
                    {
                        //Specify the command type as Stored Procedure
                        CommandType = CommandType.StoredProcedure
                    };
                    //Open the Connection
                    connection.Open();
                    //Execute the command i.e. Executing the Stored Procedure using ExecuteReader method
                    //SqlDataReader requires an active and open connection
                    SqlDataReader sdr = cmd.ExecuteReader();
                    //Read the data from the SqlDataReader 
                    //Read() method will returns true as long as data is there in the SqlDataReader
                    while (sdr.Read())
                    {
                        //Accessing the data using the string key as index
                        Console.WriteLine(sdr["Id"] + ",  " + sdr["Name"] + ",  " + sdr["Email"] + ",  " + sdr["Mobile"]);
                        //Accessing the data using the integer index position as key
                        //Console.WriteLine(sdr[0] + ",  " + sdr[1] + ",  " + sdr[2] + ",  " + sdr[3]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();
        }

        //==================== Example to Understand How to Call a Stored Procedure with Input Parameter in C#: ===================

        public void CallStoredProcedureInputParameter()
        {
            try
            {
                //Store the connection string in the ConnectionString variable
                string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=StudentDB; integrated security=SSPI";
                //Create the SqlConnection object
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //Create the SqlCommand object
                    SqlCommand cmd = new SqlCommand()
                    {
                        CommandText = "spGetStudentById", //Specify the Stored procedure name
                        Connection = connection, //Specify the connection object where the stored procedure is going to execute
                        CommandType = CommandType.StoredProcedure //Specify the command type as Stored Procedure
                    };
                    //Create an instance of SqlParameter
                    SqlParameter param1 = new SqlParameter
                    {
                        ParameterName = "@Id", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.Int, //Data Type of Parameter
                        Value = 101, //Value passes to the paramtere
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    //Add the parameter to the Parameters property of SqlCommand object
                    cmd.Parameters.Add(param1);
                    //Open the Connection
                    connection.Open();
                    //Execute the command i.e. Executing the Stored Procedure using ExecuteReader method
                    //SqlDataReader requires an active and open connection
                    SqlDataReader sdr = cmd.ExecuteReader();
                    //Read the data from the SqlDataReader 
                    //Read() method will returns true as long as data is there in the SqlDataReader
                    while (sdr.Read())
                    {
                        //Accessing the data using the string key as index
                        Console.WriteLine(sdr["Id"] + ",  " + sdr["Name"] + ",  " + sdr["Email"] + ",  " + sdr["Mobile"]);
                        //Accessing the data using the integer index position as key
                        //Console.WriteLine(sdr[0] + ",  " + sdr[1] + ",  " + sdr[2] + ",  " + sdr[3]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();
        }


        // ============= How to Call a Stored Procedure with both Input and Output Parameters in C#? 

        public void StoredProcedureWithBothInputAndOutputParameters()
        {
            try
            {
                string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=StudentDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //Create the Command Object
                    SqlCommand cmd = new SqlCommand()
                    {
                        CommandText = "spCreateStudent",
                        Connection = connection,
                        CommandType = CommandType.StoredProcedure
                    };
                    //Set Input Parameter
                    SqlParameter param1 = new SqlParameter
                    {
                        ParameterName = "@Name", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.NVarChar, //Data Type of Parameter
                        Value = "Test", //Set the value
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    //Add the parameter to the SqlCommand object
                    cmd.Parameters.Add(param1);
                    //Another approach to add Input Parameter
                    cmd.Parameters.AddWithValue("@Email", "Test@dotnettutorial.net");
                    cmd.Parameters.AddWithValue("@Mobile", "1234567890");
                    //Set Output Parameter
                    SqlParameter outParameter = new SqlParameter
                    {
                        ParameterName = "@Id", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.Int, //Data Type of Parameter
                        Direction = ParameterDirection.Output //Specify the parameter as ouput
                        //No need to specify the value property
                    };
                    //Add the parameter to the Parameters collection property of SqlCommand object
                    cmd.Parameters.Add(outParameter);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    //Now you can access the output parameter using the value propery of outParameter object
                    Console.WriteLine("Newely Generated Student ID : " + outParameter.Value.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();

        }

        //============= Example to Understand How to Call a Stored Procedure with Input Parameter in C# using ADO.NET DataSet:=====

        public void CalStoredProcedureWithInputParameter()
        {
            try
            {
                //Store the connection string in the ConnectionString variable
                string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=EmployeeDB; integrated security=SSPI";
                //Creating the connection object using the ConnectionString
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //Creating DataSet Object
                    DataSet ds = new DataSet();
                    //Creating SQL Command Object 
                    SqlCommand sqlCmd = new SqlCommand
                    {
                        CommandText = "spGetEmployeesByAgeDept", //Specifying the Stored Procedure Name
                        CommandType = CommandType.StoredProcedure, //We are going to Execute the command is a Stored Procedure
                        Connection = connection //Specifying the connection object whhere the Stored Procedure is going to be execute
                    };
                    //Create the Input Parameter for the Stored Procedure
                    SqlParameter paramAge = new SqlParameter
                    {
                        ParameterName = "@Age", //Parameter name defined in stored procedure
                        SqlDbType = SqlDbType.Int, //Data Type of Parameter
                        Value = 25, //Set the value
                        Direction = ParameterDirection.Input //Specify the parameter as input
                    };
                    //Add the parameter to the SqlCommand object
                    sqlCmd.Parameters.Add(paramAge);
                    //You can also directly add the parameter to the command object using AddWithValue method
                    sqlCmd.Parameters.AddWithValue("@Dept", "IT");
                    //Create SqlDataAdapter object
                    SqlDataAdapter da = new SqlDataAdapter
                    {
                        //Specify the Select Command as the command object we created
                        SelectCommand = sqlCmd
                    };
                    //Call the Fill Method to fill the dataset
                    da.Fill(ds);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        //Accessing the Data using the string column name as key
                        Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"] + ",  " + row["Age"] + ",  " + row["Age"]);
                        //Accessing the Data using the integer index position as key
                        //Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2] + ",  " + row[3] + ",  " + row[4] + ",  " + row[5]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();
        }

        //================ Another Approach of Calling Stored Procedure and Storing the Result in a DataSet: ===============

        public void CallingStoredProcedureAndStoringTheResult()
        {
            try
            {
                //Store the connection string in the ConnectionString variable
                string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=EmployeeDB; integrated security=SSPI";
                //Creating the connection object using the ConnectionString
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //Creating DataSet Object
                    DataSet ds = new DataSet();
                    //Creating SQL Command Object 
                    SqlCommand sqlCmd = connection.CreateCommand();
                    //Specifying the Stored Procedure Name
                    sqlCmd.CommandText = "spGetEmployeesByAgeDept";
                    //We are going to Execute the command is a Stored Procedure
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    //sqlCmd.Connection = connection; //No need to specify the connection object as the command object is created based on the connection object
                    //Add the parameter to the SqlCommand object directly using the AddWithValue method
                    sqlCmd.Parameters.AddWithValue("@Age", 25);
                    sqlCmd.Parameters.AddWithValue("@Dept", "IT");
                    //Create SqlDataAdapter object by passing the command object as a parameter to the constructor
                    SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                    //Call the Fill Method to fill the dataset
                    da.Fill(ds);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        //Accessing the Data using the string column name as key
                        Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"] + ",  " + row["Age"] + ",  " + row["Age"]);
                        //Accessing the Data using the integer index position as key
                        //Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2] + ",  " + row[3] + ",  " + row[4] + ",  " + row[5]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();

        }

        //==================== Generic Method that returns DataSet from Stored Procedure in C#: ===============


        public void GenericMethodThatReturnsDataSet()
        {
            try
            {
                //Store the connection string in the ConnectionString variable
                string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=EmployeeDB; integrated security=SSPI";
                //Executing the spGetEmployeesByAgeDept Stored Procedure
                //Create SqlParameter Required by spGetEmployeesByAgeDept Stored Procedure
                SqlParameter[] paramterList = new SqlParameter[]
                {
                    new SqlParameter("@Age", 25),
                 new SqlParameter("@Dept", "IT")
                };
                //Call the Generic Method to Execute the Stored Procedure which returns a DataSet
                DataSet dataSet1 = ExecuteStoredProcedureReturnDataSet(ConnectionString, "spGetEmployeesByAgeDept", paramterList);
                Console.WriteLine("spGetEmployeesByAgeDept Result:");
                foreach (DataRow row in dataSet1.Tables[0].Rows)
                {
                    //Accessing the Data using the string column name as key
                    Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"] + ",  " + row["Age"] + ",  " + row["Age"]);
                }
                //Executing the spGetEmployees Stored Procedure
                DataSet dataSet2 = ExecuteStoredProcedureReturnDataSet(ConnectionString, "spGetEmployees");
                Console.WriteLine("\nspGetEmployees Result:");
                foreach (DataRow row in dataSet2.Tables[0].Rows)
                {
                    //Accessing the Data using the string column name as key
                    Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"] + ",  " + row["Age"] + ",  " + row["Age"]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();
        }
        public static DataSet ExecuteStoredProcedureReturnDataSet(string connectionString, string procedureName, params SqlParameter[] paramterList)
        {
            //Create DataSet Object
            DataSet dataSet = new DataSet();
            //Create the connection object using the connectionString parameter which it received as input parameter
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                //Create the command object
                using (var command = sqlConnection.CreateCommand())
                {
                    //Create the SqlDataAdapter object by passing command object as a parameter to the constructor
                    using (SqlDataAdapter sda = new SqlDataAdapter(command))
                    {
                        //Set the command type as StoredProcedure
                        command.CommandType = CommandType.StoredProcedure;
                        //Set the command text as the procedure name which you received as input parameter
                        command.CommandText = procedureName;
                        //If Parameter list is not null, add the parameterlist into Parameters collection of the command object
                        if (paramterList != null)
                        {
                            command.Parameters.AddRange(paramterList);
                        }

                        //Fill the Dataset
                        sda.Fill(dataSet);
                    }
                }
            }
            //Return the DataSet
            return dataSet;
        }


    }
}

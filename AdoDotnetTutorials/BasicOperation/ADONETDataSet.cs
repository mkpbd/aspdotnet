using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdoDotnetTutorials.BasicOperation
{
    public class ADONETDataSet
    {

        public void CreateDatableAndData()
        {
            try
            {
                // Creating Customer Data Table
                DataTable Customer = new DataTable("Customer");
                // Adding Data Columns to the Customer Data Table
                DataColumn CustomerId = new DataColumn("ID", typeof(Int32));
                Customer.Columns.Add(CustomerId);
                DataColumn CustomerName = new DataColumn("Name", typeof(string));
                Customer.Columns.Add(CustomerName);
                DataColumn CustomerMobile = new DataColumn("Mobile", typeof(string));
                Customer.Columns.Add(CustomerMobile);
                //Adding Data Rows into Customer Data Table
                Customer.Rows.Add(101, "Anurag", "2233445566");
                Customer.Rows.Add(202, "Manoj", "1234567890");
                // Creating Orders Data Table
                DataTable Orders = new DataTable("Orders");
                // Adding Data Columns to the Orders Data Table
                DataColumn OrderId = new DataColumn("ID", typeof(System.Int32));
                Orders.Columns.Add(OrderId);
                DataColumn CustId = new DataColumn("CustomerId", typeof(Int32));
                Orders.Columns.Add(CustId);
                DataColumn OrderAmount = new DataColumn("Amount", typeof(int));
                Orders.Columns.Add(OrderAmount);
                //Adding Data Rows into Orders Data Table
                Orders.Rows.Add(10001, 101, 20000);
                Orders.Rows.Add(10002, 102, 30000);
                //Creating DataSet Object
                DataSet dataSet = new DataSet();
                //Adding DataTables into DataSet
                dataSet.Tables.Add(Customer);
                dataSet.Tables.Add(Orders);
                //Fetching Customer Data Table Data
                Console.WriteLine("Customer Table Data: ");
                //Fetching DataTable from Dataset using the Index position
                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    //Accessing the data using string column name
                    Console.WriteLine(row["ID"] + ",  " + row["Name"] + ",  " + row["Mobile"]);
                    //Accessing the data using integer index position
                    //Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                }
                Console.WriteLine();
                //Fetching Orders Data Table Data
                Console.WriteLine("Orders Table Data: ");
                //Fetching DataTable from the DataSet using the table name
                foreach (DataRow row in dataSet.Tables["Orders"].Rows)
                {
                    //Accessing the data using string column name
                    Console.WriteLine(row["ID"] + ",  " + row["CustomerId"] + ",  " + row["Amount"]);
                    //Accessing the data using integer index position
                    //Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();

        }



        //=========== Example to Understand ADO.NET DataSet using SQL Server Database in C#: ============


        public void DataSetSQLServerDatabase()
        {

            try
            {
                string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=ShoppingCartDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //Create the SqlDataAdapter instance by specifying the command text and connection object
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from customers", connection);
                    //Creating DataSet Object
                    DataSet dataSet = new DataSet();
                    //Filling the DataSet using the Fill Method of SqlDataAdapter object
                    //Here, we have not specified the data table name and the data table will be created at index position 0
                    dataAdapter.Fill(dataSet);
                    //Iterating through the DataSet 
                    //First fetch the Datatable from the dataset and then fetch the rows using the Rows property of Datatable
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        //Accessing the Data using the string column name as key
                        Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Mobile"]);
                        //Accessing the Data using the integer index position as key
                        //Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Mobile"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();
        }

        // ============ DataSet with Multiple Database Tables using SQL Server in C#: ============

        public void MultipleDatabaseTables()
        {

            try
            {
                string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=ShoppingCartDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //We have written two Select Statements to return data from customers and orders table
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from customers; select * from orders", connection);
                    DataSet dataSet = new DataSet();
                    //Data Table 1 will be customers data which is at Index Position 0
                    //Data Table 2 will be orders data which is at Index Position 1
                    dataAdapter.Fill(dataSet);
                    // Fetching First Table Data i.e. Customers Data
                    Console.WriteLine("Table 1 Data");
                    //Accessing the Data Table from the DataSet using Integer Index Position
                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        //Accessing using string column name as keys
                        Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Mobile"]);
                        //Accessing using integer index position as keys
                        //Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                    }
                    Console.WriteLine();
                    // Fetching Second Table Data i.e. Orders Data
                    Console.WriteLine("Table 2 Data");
                    //Accessing the Data Table from the DataSet using Integer Index Position
                    foreach (DataRow row in dataSet.Tables[1].Rows)
                    {
                        //Accessing using string column name as keys
                        //Console.WriteLine(row["Id"] + ",  " + row["CustomerId"] + ",  " + row["Amount"]);
                        //Accessing using integer index position as keys
                        Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();

        }


        //==================== Accessing Data table from DataSet Using Default Table Name in C#: ==================

        public void AccessingDatatableFromDataSet()
        {
            try
            {
                string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=ShoppingCartDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //We have written two Select Statements to return data from customers and orders table
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from customers; select * from orders", connection);
                    DataSet dataSet = new DataSet();
                    //Data Table 1 will be customers data which is at Index Position 0
                    //Data Table 2 will be orders data which is at Index Position 1
                    dataAdapter.Fill(dataSet);
                    // Fetching First Table Data i.e. Customers Data
                    Console.WriteLine("Table 1 Data");
                    //Accessing the Data Table from the DataSet using Default Table name
                    //By Default, first table name is Table
                    foreach (DataRow row in dataSet.Tables["Table"].Rows)
                    {
                        //Accessing using string column name as keys
                        Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Mobile"]);
                        //Accessing using integer index position as keys
                        //Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                    }
                    Console.WriteLine();
                    // Fetching Second Table Data i.e. Orders Data
                    Console.WriteLine("Table 2 Data");
                    //Accessing the Data Table from the DataSet using Default Table name
                    //By Default, second table name is Table1
                    foreach (DataRow row in dataSet.Tables["Table1"].Rows)
                    {
                        //Accessing using string column name as keys
                        //Console.WriteLine(row["Id"] + ",  " + row["CustomerId"] + ",  " + row["Amount"]);
                        //Accessing using integer index position as keys
                        Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();
        }
        //============================ How to Set the Data Table name Explicitly in ADO.NET DataSet? =====================

        public void DataTableNameExplicitly()
        {
            try
            {
                string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=ShoppingCartDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //We have written two Select Statements to return data from customers and orders table
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from customers; select * from orders", connection);
                    DataSet dataSet = new DataSet();
                    //Data Table 1 will be customers data which is at Index Position 0
                    //Data Table 2 will be orders data which is at Index Position 1
                    dataAdapter.Fill(dataSet);
                    dataSet.Tables[0].TableName = "Customers";
                    dataSet.Tables[1].TableName = "Orders";
                    // Fetching First Table Data i.e. Customers Data
                    Console.WriteLine("Table 1 Data");
                    //Accessing the Data Table from the DataSet using the Custom Table name
                    foreach (DataRow row in dataSet.Tables["Customers"].Rows)
                    {
                        //Accessing using string column name as keys
                        Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Mobile"]);
                        //Accessing using integer index position as keys
                        //Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                    }
                    Console.WriteLine();
                    // Fetching Second Table Data i.e. Orders Data
                    Console.WriteLine("Table 2 Data");
                    //Accessing the Data Table from the DataSet using the Custom Table name
                    foreach (DataRow row in dataSet.Tables["Orders"].Rows)
                    {
                        //Accessing using string column name as keys
                        //Console.WriteLine(row["Id"] + ",  " + row["CustomerId"] + ",  " + row["Amount"]);
                        //Accessing using integer index position as keys
                        Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();
        }

        //==================== Example to understand Copy, Clone, and Clear Methods of DataSet Object in C#: =================

        public void CopyCloneAndClearMethods()
        {
            try
            {
                string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=StudentDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from student", connection);
                    DataSet originalDataSet = new DataSet();
                    da.Fill(originalDataSet);
                    Console.WriteLine("Original Data Set:");
                    foreach (DataRow row in originalDataSet.Tables[0].Rows)
                    {
                        Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Copy Data Set:");
                    //Copies both the structure and data for this System.Data.DataSet.
                    DataSet copyDataSet = originalDataSet.Copy();
                    if (copyDataSet.Tables != null)
                    {
                        foreach (DataRow row in copyDataSet.Tables[0].Rows)
                        {
                            Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("Clone Data Set");
                    // Copies the structure of the DataSet, including all DataTable
                    // schemas, relations, and constraints. Does not copy any data.
                    DataSet cloneDataSet = originalDataSet.Clone();
                    if (cloneDataSet.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in cloneDataSet.Tables[0].Rows)
                        {
                            Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Clone Data Set is Empty");
                        Console.WriteLine("Adding Data to Clone Data Set Table");
                        cloneDataSet.Tables[0].Rows.Add(101, "Test1", "Test1@dotnettutorial.net", "1234567890");
                        cloneDataSet.Tables[0].Rows.Add(101, "Test2", "Test1@dotnettutorial.net", "1234567890");
                        foreach (DataRow row in cloneDataSet.Tables[0].Rows)
                        {
                            Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                        }
                    }
                    Console.WriteLine();
                    //Clears the DataSet of any data by removing all rows in all tables.
                    copyDataSet.Clear();
                    if (copyDataSet.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in copyDataSet.Tables[0].Rows)
                        {
                            Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("After Clear No Data is Their...");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();
        }

        // ============== Example to Remove a DataTable from a Dataset in C#: =========================

        public void RemoveDataTableFromDataset()
        {
            try
            {
                string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=ShoppingCartDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //We have written two Select Statements to return data from customers and orders table
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from customers; select * from orders", connection);
                    DataSet dataSet = new DataSet();
                    //Data Table 1 will be customers data which is at Index Position 0
                    //Data Table 2 will be orders data which is at Index Position 1
                    dataAdapter.Fill(dataSet);
                    dataSet.Tables[0].TableName = "Customers";
                    dataSet.Tables[1].TableName = "Orders";
                    // Fetching First Table Data i.e. Customers Data
                    Console.WriteLine("Customers Data");
                    //Accessing the Data Table from the DataSet using the Custom Table name
                    foreach (DataRow row in dataSet.Tables["Customers"].Rows)
                    {
                        //Accessing using string column name as keys
                        Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Mobile"]);
                    }
                    Console.WriteLine();
                    // Fetching Second Table Data i.e. Orders Data
                    Console.WriteLine("Orders Data");
                    //Accessing the Data Table from the DataSet using the Custom Table name
                    foreach (DataRow row in dataSet.Tables["Orders"].Rows)
                    {
                        //Accessing using integer index position as keys
                        Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                    }
                    Console.WriteLine();
                    //Now, we want to delete the Orders data table from the DataSet
                    if (dataSet.Tables.Contains("Orders") && dataSet.Tables.CanRemove(dataSet.Tables["Orders"]))
                    {
                        Console.WriteLine("Deleting Orders Data Table..");
                        dataSet.Tables.Remove(dataSet.Tables["Orders"]);
                        //dataSet.Tables.Remove(dataSet.Tables[1]);
                    }
                    //Now check whether the DataTable exists or not
                    if (dataSet.Tables.Contains("Orders"))
                    {
                        Console.WriteLine("Orders Data Table Exits");
                    }
                    else
                    {
                        Console.WriteLine("Orders Data Table Not Exits Anymore");
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

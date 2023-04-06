using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotnetTutorials.BasicOperation
{
    public class ADONET_DataViewClass
    {
        //============= Example to Create and Display the Data of a DataView in C#:

        public void CreateAndDisplayTheDataOfDataView()
        {
            try
            {
                string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=EmployeeDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //Create the SqlDataAdapter instance by specifying the command text and connection object
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Id, Name, Email, Mobile, Age, Salary, Department FROM EMPLOYEE", connection);
                    //Creating DataTable Object
                    DataTable EmployeeDataTable = new DataTable();
                    //Filling the DataTable using the Fill Method of SqlDataAdapter object
                    dataAdapter.Fill(EmployeeDataTable);
                    //Creating DataView instance using DataView Constructor
                    //Initializes a new instance of the DataView class with the specified DataTable.
                    DataView dataView1 = new DataView(EmployeeDataTable);
                    Console.WriteLine("Accessing DataView using For Loop:");
                    for (int i = 0; i < dataView1.Count; i++)
                    {
                        Console.WriteLine($"Id: {dataView1[i]["Id"]}, Name: {dataView1[i]["Name"]}, Email: {dataView1[i]["Email"]}, Mobile: {dataView1[i]["Mobile"]}");
                    }
                    //Creating DataView instance using DefaultView property of Data Table
                    DataView dataView2 = EmployeeDataTable.DefaultView;
                    Console.WriteLine("\nAccessing DataView using Foreach Loop:");
                    foreach (DataRowView rowView in dataView2)
                    {
                        DataRow row = rowView.Row;
                        Console.WriteLine($"Id: {row["Id"]}, Age: {row["Age"]}, Salary: {row["Salary"]}, Department: {row["Department"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();

        }

        //================ Sorting ADO.NET DataView in C#: ==============

        public void SortingAdoNetDataView()
        {
            try
            {
                string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=EmployeeDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //Create the SqlDataAdapter instance by specifying the command text and connection object
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Id, Name, Email, Mobile, Age, Salary, Department FROM EMPLOYEE", connection);
                    //Creating DataTable Object
                    DataTable EmployeeDataTable = new DataTable();
                    //Filling the DataTable using the Fill Method of SqlDataAdapter object
                    dataAdapter.Fill(EmployeeDataTable);
                    //Creating DataView instance using DataView Constructor
                    //Initializes a new instance of the DataView class with the specified DataTable
                    DataView dataView1 = new DataView(EmployeeDataTable);
                    dataView1.Sort = "Name ASC";
                    Console.WriteLine("DataView Sorted By: Name ASC");
                    for (int i = 0; i < dataView1.Count; i++)
                    {
                        Console.WriteLine($"Id: {dataView1[i]["Id"]}, Name: {dataView1[i]["Name"]}, Department: {dataView1[i]["Department"]}");
                    }
                    //Creating DataView instance using DataView Constructor
                    //Sorting Based on Multiple Columns Separated by comma
                    DataView dataView2 = new DataView(EmployeeDataTable);
                    dataView2.Sort = "Department DESC, Name ASC";
                    //The above statement is similar to the below statement
                    //dataView2.Sort = "Department DESC, Name";
                    Console.WriteLine("\nDataView Sorted By: Department DESC and Name ASC");
                    foreach (DataRowView rowView in dataView2)
                    {
                        DataRow row = rowView.Row;
                        Console.WriteLine($"Id: {row["Id"]}, Department: {row["Department"]}, Name: {row["Name"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();
        }

        // =============== Filtering ADO.NET DataView in C# with Examples: ==============

        public void ilteringADONETDataView()
        {
            try
            {
                string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=EmployeeDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //Create the SqlDataAdapter instance by specifying the command text and connection object
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Id, Name, Email, Mobile, Age, Salary, Department FROM EMPLOYEE", connection);
                    //Creating DataTable Object
                    DataTable EmployeeDataTable = new DataTable();
                    //Filling the DataTable using the Fill Method of SqlDataAdapter object
                    dataAdapter.Fill(EmployeeDataTable);
                    //Creating DataView instance using DefaultView property of Data Table
                    DataView dataView1 = EmployeeDataTable.DefaultView;
                    //Applying Single Filter
                    dataView1.RowFilter = "Age > 25";
                    Console.WriteLine($"DataView with Filter: {dataView1.RowFilter}");
                    foreach (DataRowView rowView in dataView1)
                    {
                        DataRow row = rowView.Row;
                        Console.WriteLine($"Id: {row["Id"]}, Age: {row["Age"]}, Age: {row["Salary"]}, Department: {row["Department"]}");
                    }
                    //Creating DataView instance using DataView constructor
                    DataView dataView2 = new DataView(EmployeeDataTable);
                    //Applying Multiple Filter
                    dataView2.RowFilter = "Age > 25 AND Department = 'HR'";
                    Console.WriteLine($"\nDataView with Filter: {dataView2.RowFilter}");
                    foreach (DataRowView rowView in dataView2)
                    {
                        DataRow row = rowView.Row;
                        Console.WriteLine($"Id: {row["Id"]}, Name: {row["Name"]}, Age: {row["Age"]}, Department: {row["Department"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();
        }


        //=============== Adding Row in ADO.NET DataView using C#: ==============

        public void AddingRowAdoNetDataView()
        {
            try
            {
                string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=EmployeeDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //Create the SqlDataAdapter instance by specifying the command text and connection object
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Id, Name, Email, Mobile, Age, Salary, Department FROM EMPLOYEE", connection);
                    //Creating DataTable Object
                    DataTable EmployeeDataTable = new DataTable();
                    //Filling the DataTable using the Fill Method of SqlDataAdapter object
                    dataAdapter.Fill(EmployeeDataTable);
                    //Creating DataView instance using DataView constructor
                    DataView dataView1 = new DataView(EmployeeDataTable);
                    //Create a new DataRowView by calling the AddNew Method of the dataview object
                    //If you want restrict new row on the data view then set AllowNew property to false
                    dataView1.AllowNew = true;
                    DataRowView newRow = dataView1.AddNew();
                    //Set the newRow column values
                    newRow["Id"] = 108;
                    newRow["Name"] = "New Name";
                    newRow["Mobile"] = "New Mobile";
                    newRow["Age"] = 27;
                    newRow["Salary"] = 20000;
                    newRow["Department"] = "IT";
                    //You can see the new row in the Data View
                    Console.WriteLine($"\nDataView Data");
                    foreach (DataRowView rowView in dataView1)
                    {
                        DataRow row = rowView.Row;
                        Console.WriteLine($"Id: {row["Id"]}, Name: {row["Name"]}, Mobile: {row["Mobile"]}, Department: {row["Department"]}");
                    }
                    //You cannot see the new row in the DataTable
                    Console.WriteLine($"\nDataTable Data:");
                    foreach (DataRow row in EmployeeDataTable.Rows)
                    {
                        Console.WriteLine($"Id: {row["Id"]}, Name: {row["Name"]}, Mobile: {row["Mobile"]}, Department: {row["Department"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();
        }

        // Updating Row in ADO.NET DataView with Examples: 
        public void RowInADONETDataView()
        {
            try
            {
                string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=EmployeeDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //Create the SqlDataAdapter instance by specifying the command text and connection object
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Id, Name, Email, Mobile, Age, Salary, Department FROM EMPLOYEE", connection);
                    //Creating DataTable Object
                    DataTable EmployeeDataTable = new DataTable();
                    //Filling the DataTable using the Fill Method of SqlDataAdapter object
                    dataAdapter.Fill(EmployeeDataTable);
                    //Creating DataView instance using DataView constructor
                    DataView dataView1 = new DataView(EmployeeDataTable);
                    //You can see the new row in the Data View
                    Console.WriteLine($"DataView Data Before Update");
                    foreach (DataRowView rowView in dataView1)
                    {
                        DataRow row = rowView.Row;
                        Console.WriteLine($"Id: {row["Id"]}, Name: {row["Name"]}, Salary: {row["Salary"]}, Department: {row["Department"]}");
                    }
                    //If you want restrict the data view to be Updated then set AllowEdit property to false
                    dataView1.AllowEdit = true;
                    //Updating the Salary of IT Department employees by adding 1000 to their current Salary
                    foreach (DataRowView rowView in dataView1)
                    {
                        if (Convert.ToString(rowView["Department"]) == "IT")
                        {
                            //You can  access the column by using string column name
                            rowView["Salary"] = Convert.ToInt32(rowView["Salary"]) + 1000;
                            //You can also access the column by using Integer Index Position
                            //rowView[5] = Convert.ToInt32(rowView[5]) + 1000;
                        }
                    }
                    //You can also access Individual DataView Row as follow
                    //Here, Index position 0 specify the first row
                    //dataView1[0]["Salary"] = Convert.ToInt32(dataView1[0]["Salary"]) + 1000;
                    //dataView1[0][5] = Convert.ToInt32(dataView1[0][5]) + 1000;
                    Console.WriteLine($"\nDataView Data After Update");
                    foreach (DataRowView rowView in dataView1)
                    {
                        DataRow row = rowView.Row;
                        Console.WriteLine($"Id: {row["Id"]}, Name: {row["Name"]}, Salary: {row["Salary"]}, Department: {row["Department"]}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();
        }

        //==================== Deleting Row from ADO.NET DataView using C#: =======================

        public void DeletingRowFromADONETDataView()
        {
            try
            {
                string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=EmployeeDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //Create the SqlDataAdapter instance by specifying the command text and connection object
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Id, Name, Email, Mobile, Age, Salary, Department FROM EMPLOYEE", connection);
                    //Creating DataTable Object
                    DataTable EmployeeDataTable = new DataTable();
                    //Filling the DataTable using the Fill Method of SqlDataAdapter object
                    dataAdapter.Fill(EmployeeDataTable);
                    //Creating DataView instance using DataView constructor
                    DataView dataView1 = new DataView(EmployeeDataTable);
                    //You can see the new row in the Data View
                    Console.WriteLine($"DataView Data Before Delete:");
                    foreach (DataRowView rowView in dataView1)
                    {
                        DataRow row = rowView.Row;
                        Console.WriteLine($"Id: {row["Id"]}, Name: {row["Name"]}, Salary: {row["Salary"]}, Department: {row["Department"]}");
                    }
                    //If you want restrict the delete operation on a dataview then set AllowDelete property to false
                    dataView1.AllowDelete = true;
                    //Deleting IT Department employees from the Data View
                    foreach (DataRowView rowView in dataView1)
                    {
                        if (Convert.ToString(rowView["Department"]) == "IT")
                        {
                            rowView.Delete();
                        }
                    }
                    //You can also delete Individual DataView Row as follow
                    //Here, Index position 0 specify the first row
                    //dataView1[0].Delete();
                    Console.WriteLine($"\nDataView Data After Delete:");
                    foreach (DataRowView rowView in dataView1)
                    {
                        DataRow row = rowView.Row;
                        Console.WriteLine($"Id: {row["Id"]}, Name: {row["Name"]}, Salary: {row["Salary"]}, Department: {row["Department"]}");
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotnetTutorials.BasicOperation
{
    public class SqlDataTableObject
    {

        public void DataTable()
        {
            try
            {
                //Creating data table instance
                DataTable dataTable = new DataTable("Student");
                //Add the DataColumn using all properties
                DataColumn Id = new DataColumn("ID");
                Id.DataType = typeof(int);
                Id.Unique = true;
                Id.AllowDBNull = false;
                Id.Caption = "Student ID";
                dataTable.Columns.Add(Id);

                //Add the DataColumn few properties
                DataColumn Name = new DataColumn("Name");
                Name.MaxLength = 50;
                Name.AllowDBNull = false;
                dataTable.Columns.Add(Name);

                //Add the DataColumn using defaults
                DataColumn Email = new DataColumn("Email");
                dataTable.Columns.Add(Email);

                //Setting the Primary Key
                dataTable.PrimaryKey = new DataColumn[] { Id };

                //Add New DataRow by creating the DataRow object
                DataRow row1 = dataTable.NewRow();
                row1["Id"] = 101;
                row1["Name"] = "Anurag";
                row1["Email"] = "Anurag@dotnettutorials.net";
                dataTable.Rows.Add(row1);
                //Adding new DataRow by simply adding the values
                dataTable.Rows.Add(102, "Mohanty", "Mohanty@dotnettutorials.net");
                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Email"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            Console.ReadKey();
        }

        //====================== Example to understand Autoincrement Column in C#: =========================

        public void AutoincrementColumn()
        {
            try
            {
                //Creating data table instance
                DataTable dataTable = new DataTable("Student");

                DataColumn Id = new DataColumn
                {
                    ColumnName = "Id",
                    DataType = System.Type.GetType("System.Int32"),
                    AutoIncrement = true,
                    AutoIncrementSeed = 1000,
                    AutoIncrementStep = 10
                };
                dataTable.Columns.Add(Id);

                //Add the DataColumn few properties
                DataColumn Name = new DataColumn("Name");
                Name.MaxLength = 50;
                Name.AllowDBNull = false;
                dataTable.Columns.Add(Name);

                //Add the DataColumn using defaults
                DataColumn Email = new DataColumn("Email");
                dataTable.Columns.Add(Email);

                //Add New DataRow by creating the DataRow object
                DataRow row1 = dataTable.NewRow();

                row1["Name"] = "Anurag";
                row1["Email"] = "Anurag@dotnettutorials.net";
                dataTable.Rows.Add(row1);

                //Adding new DataRow by simply adding the values
                //Supply null for auto increment column
                dataTable.Rows.Add(null, "Mohanty", "Mohanty@dotnettutorials.net");
                foreach (DataRow row in dataTable.Rows)
                {
                    Console.WriteLine(row["Id"] + ",  " + row["Name"] + ",  " + row["Email"]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            Console.ReadKey();
        }


        // =================  DataTable Methods in C# with Examples ======================

        public void SampleDataInDataTable()
        {
            try
            {
                string ConnectionString = "data source=.; database=StudentDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from student", connection);
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


        public void CopyAndCloneDataTable()
        {
            try
            {
                string ConnectionString = "data source=.; database=StudentDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from student", connection);
                    DataTable originalDataTable = new DataTable();
                    da.Fill(originalDataTable);
                    Console.WriteLine("Original Data Table : originalDataTable");
                    foreach (DataRow row in originalDataTable.Rows)
                    {
                        Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Copy Data Table : copyDataTable");
                    DataTable copyDataTable = originalDataTable.Copy();
                    if (copyDataTable != null)
                    {
                        foreach (DataRow row in copyDataTable.Rows)
                        {
                            Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("Clone Data Table : cloneDataTable");
                    DataTable cloneDataTable = originalDataTable.Clone();
                    if (cloneDataTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in cloneDataTable.Rows)
                        {
                            Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("cloneDataTable is Empty");
                        Console.WriteLine("Adding Data to cloneDataTable");
                        cloneDataTable.Rows.Add(101, "Test1", "Test1@dotnettutorial.net", "1234567890");
                        cloneDataTable.Rows.Add(101, "Test2", "Test1@dotnettutorial.net", "1234567890");
                        foreach (DataRow row in cloneDataTable.Rows)
                        {
                            Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OOPs, something went wrong.\n" + e);
            }
            Console.ReadKey();
        }


        public void DeleteDataTableMethod()
        {
            try
            {
                string ConnectionString = "data source=.; database=StudentDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from student", connection);
                    DataTable originalDataTable = new DataTable();
                    da.Fill(originalDataTable);
                    Console.WriteLine("Before Deletion");
                    foreach (DataRow row in originalDataTable.Rows)
                    {
                        Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                    }
                    Console.WriteLine();
                    foreach (DataRow row in originalDataTable.Rows)
                    {
                        if (Convert.ToInt32(row["Id"]) == 101)
                        {
                            row.Delete();
                            Console.WriteLine("Row with Id 101 Deleted");
                        }
                    }
                    originalDataTable.AcceptChanges();
                    Console.WriteLine();
                    Console.WriteLine("After Deletion");
                    foreach (DataRow row in originalDataTable.Rows)
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



        public void RemoveMethod()
        {
            try
            {
                string ConnectionString = "data source=.; database=StudentDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from student", connection);
                    DataTable originalDataTable = new DataTable();
                    da.Fill(originalDataTable);
                    Console.WriteLine("Before Deletion");
                    foreach (DataRow row in originalDataTable.Rows)
                    {
                        Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                    }
                    Console.WriteLine();
                    foreach (DataRow row in originalDataTable.Select())
                    {
                        if (Convert.ToInt32(row["Id"]) == 101)
                        {
                            originalDataTable.Rows.Remove(row);
                            Console.WriteLine("Row with Id 101 Deleted");
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine("After Deletion");
                    foreach (DataRow row in originalDataTable.Rows)
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


        public void RejectChangesMethod()
        {
            try
            {
                string ConnectionString = "data source=.; database=StudentDB; integrated security=SSPI";
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from student", connection);
                    DataTable originalDataTable = new DataTable();
                    da.Fill(originalDataTable);
                    Console.WriteLine("Before Deletion");
                    foreach (DataRow row in originalDataTable.Rows)
                    {
                        Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
                    }
                    Console.WriteLine();
                    foreach (DataRow row in originalDataTable.Rows)
                    {
                        if (Convert.ToInt32(row["Id"]) == 101)
                        {
                            row.Delete();
                            Console.WriteLine("Row with Id 101 Deleted");
                        }
                    }

                    //Rollbacking the Data
                    originalDataTable.RejectChanges();
                    Console.WriteLine();
                    Console.WriteLine("Rollbacking the Changes");
                    foreach (DataRow row in originalDataTable.Rows)
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

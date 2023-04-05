using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace AdoNetBasic.Chapter5
{
    public class DataModifyAndAdd
    {
        public void AutoIncrementWithoutConflict()
        {
            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect = "SELECT * FROM HumanResources.Department";
            // Create and fill a DataTable with schema and data

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            da.FillSchema(dt, SchemaType.Source);
            // Configure the primary key column DepartmentID
            dt.Columns["DepartmentID"].AutoIncrementSeed = -1;
            dt.Columns["DepartmentID"].AutoIncrementStep = -1;
            dt.PrimaryKey = new DataColumn[] { dt.Columns["DepartmentID"] };
            da.Fill(dt);
            // Add two records
            dt.Rows.Add(new object[] { null, "Test Name 1", "Test Group 1", System.DateTime.Now });
            dt.Rows.Add(new object[] { null, "Test Name 2", "Test Group 2", System.DateTime.Now });
            foreach (DataRow row in dt.Rows)
                Console.WriteLine("ID = {0}\tName = {1}, GroupName = {2}",
                row["DepartmentID"], row["Name"], row["GroupName"]);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

        }


        public void GetSqlServerIdentityValue()
        {
            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdoDotNet35Cookbook;";
            string sqlSelect = "SELECT * FROM GetSqlServerIdentityValue";
            // Create a DataAdapter, setting the insert command to the
            // stored procedure
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            da.InsertCommand = new SqlCommand("InsertGetSqlServer IdentityValue",
            da.SelectCommand.Connection);
            da.InsertCommand.CommandType = CommandType.StoredProcedure;
            SqlParameter param = da.InsertCommand.Parameters.Add("@Id",
            SqlDbType.Int, 0, "Id");
            param.Direction = ParameterDirection.Output;
            da.InsertCommand.Parameters.Add("@Field1", SqlDbType.NVarChar,
            50, "Field1");
            da.InsertCommand.Parameters.Add("@Field2", SqlDbType.NVarChar,
            50, "Field2");
            // Use a DataAdapter to fill schema and data of a DataTable
            DataTable dt = new DataTable();
            da.FillSchema(dt, SchemaType.Source);
            // Set autoincrement properties to avoid collision with existing records
            dt.Columns["Id"].AutoIncrementSeed = -1;
            dt.Columns["Id"].AutoIncrementStep = -1;
            da.Fill(dt);

            //Output the initial DataTable to the console.
            Console.WriteLine("---INITIAL RESULT SET---");
            foreach (DataRow row in dt.Rows)
                Console.WriteLine("Id = {0}\tField1 = {1}\tField2 = {2}\tRowState ={ 3} ", row["Id"], row["Field1"], row["Field2"], row.RowState);
            // Add rows and display results of different UpdateRowSource values
            AddRow(1, da, dt, UpdateRowSource.FirstReturnedRecord);
            AddRow(2, da, dt, UpdateRowSource.OutputParameters);
            AddRow(3, da, dt, UpdateRowSource.None);
            // Clear the DataTable reload
            dt.Clear();
            da.Fill(dt);

            //Output the final DataTable to the console.
            Console.WriteLine("\n---FINAL RESULT SET---");
            foreach (DataRow row in dt.Rows)
                Console.WriteLine("Id = {0}\tField1 = {1}\tField2 = {2}\tRowState ={ 3}  ", row["Id"], row["Field1"], row["Field2"], row.RowState);
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }

        private static void AddRow(int n, SqlDataAdapter da, DataTable dt,UpdateRowSource urs)
        {
            // Add a row to the DataTable
            dt.Rows.Add(new object[] { null, "field 1." + (n + 1), "field 2." + (n + 1) });
            Console.WriteLine("\n=> Row added");
            // Output the interim DataTable to the console.
            Console.WriteLine("\n---INTERIM RESULT SET {0}---", n);
            foreach (DataRow row in dt.Rows)
                Console.WriteLine("Id = {0}\tField1 = {1}\tField2 = {2}\tRowState ={ 3} ", row["Id"], row["field1"], row["field2"], row.RowState);
            // Set the UpdateRowSource to first returned record
            da.InsertCommand.UpdatedRowSource = urs;
            da.Update(dt);
            Console.WriteLine("\n=> DataTable.Update( )");
            // Output the DataTable to the console.
            Console.WriteLine(
            "\n---UpdateRowSource.{0} RESULT SET AFTER DataAdapter.Update( )---   ",
            urs.ToString());
            foreach (DataRow row in dt.Rows)
                Console.WriteLine("Id = {0}\tField1 = {1}\tField2 = {2}\tRowState ={ 3}  ",
                    row["Id"], row["field1"], row["field2"], row.RowState);
        }

        private OleDbDataAdapter da;
        private string oledbConnectString =
            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + @"C:\Northwind 2007.accdb;";
        string sqlSelect = "SELECT * FROM Customers";
        public void AccessAutoNumberValue()
        {
          
            string oledbConnectString =
            "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +  @"C:\Northwind 2007.accdb;";
            string sqlSelect = "SELECT * FROM Customers";
            da = new OleDbDataAdapter(sqlSelect, oledbConnectString);
            // Create the insert command for the DataAdapter.
            // (most fields omitted for brevity)
            string sqlInsert = "INSERT INTO Customers " + "([Last Name], [First Name]) VALUES (?, ?)";
            da.InsertCommand = new OleDbCommand(sqlInsert, da.SelectCommand.Connection);
            da.InsertCommand.Parameters.Add("@LastName", OleDbType.Char,    50, "Last Name");
            da.InsertCommand.Parameters.Add("@FirstName", OleDbType.Char,  50, "First Name");
            // Handle this event to retrieve the autonumber value.
            da.RowUpdated += new OleDbRowUpdatedEventHandler(OnRowUpdated);
            // Create DataTable and fill with schema and data
            DataTable dt = new DataTable();
            da.FillSchema(dt, SchemaType.Source);
            // Set these values before adding rows to the DataTable with Fill( )
            dt.Columns["ID"].AutoIncrementSeed = -1;
            dt.Columns["ID"].AutoIncrementStep = -1;
            da.Fill(dt);

            // Create the new row, setting a few fields and leaving the rest null
            DataRow row = dt.NewRow();
            row["First Name"] = "Bill";
            row["Last Name"] = "Hamilton";
            // Add the row the the DataTable
            dt.Rows.Add(row);
            Console.WriteLine("ID AutoNumber value in new row before update = {0}",  row["ID"]);
            // Persist the changes (new row) to the database
            da.Update(dt);
            Console.WriteLine("\nID AutoNumber value in new row after update = {0}",  row["ID"]);
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();

        }
        private static void OnRowUpdated(object Sender,OleDbRowUpdatedEventArgs args)
        {
         
            // Retrieve autonumber value for inserts only.
            if (args.StatementType == StatementType.Insert)
            {
                Console.WriteLine("\nOnRowUpdate( ) called for StatementType.Insert.");
                // SQL command to retrieve the identity value created
               // OleDbCommand cmd = new OleDbCommand("SELECT @@IDENTITY", da.SelectCommand.Connection());
                // Store the new identity value to the ID in the table.
              //  args.Row["ID"] = (int)cmd.ExecuteScalar();
            }

        }



    }
}


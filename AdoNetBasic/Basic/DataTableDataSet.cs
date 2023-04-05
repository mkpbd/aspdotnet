using Microsoft.Data.SqlClient;
using System.Data;

namespace AdoNetBasic.Basic
{
    public class DataTableDataSet
    {


        // Executing a Query That Returns  Multiple Result Sets
        public void ExecuteBatchQuery()
        {
            // 1. SqlConnections
            // 2. DataAdapter
            // 3. DataTable
            // 4. DataSet

            string sqlSelect = "SELECT TOP 3 * FROM Sales.SalesOrderHeader;" + "SELECT TOP 3 * FROM Sales.SalesOrderDetail";

            int rsNumber;
            // SQL batch using a DataSet
            Console.WriteLine("---DataSet---");

            // Fill the DataSet with the results of the batch query.
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, DbConnections.Connection());

            DataSet ds = new DataSet();
            da.Fill(ds);

            rsNumber = 0;
            // Iterate over the result sets in the DataTable collection
            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine("Result set: {0}", ++rsNumber);
                foreach (DataRow row in dt.Rows)
                {
                    // Output the first three fields for each record
                    Console.WriteLine("{0}, {1}, {2}", row[0], row[1], row[2]);
                }
                Console.WriteLine(Environment.NewLine);
            }

            using (DbConnections.Connection())
            {
                // SQL batch using a DataReader
                Console.WriteLine("---DataReader---");
                // Create the DataReader from the batch query
                SqlCommand command = new SqlCommand(sqlSelect, DbConnections.Connection());

                SqlDataReader dr = command.ExecuteReader();

                rsNumber = 0;
                //Iterate over the result sets using the NextResult( ) method
                do
                {
                    Console.WriteLine("Result set: {0}", ++rsNumber);
                    // Iterate over the rows in the DataReader.
                    while (dr.Read())
                    {
                        // Output the first three fields for each record
                        Console.WriteLine("{0}, {1}, {2}", dr[0], dr[1], dr[2]);
                    }
                    Console.WriteLine(Environment.NewLine);
                } while (dr.NextResult());
            }
        }



        public void AddingExistingConstraints()
        {

            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect = "SELECT TOP 5 ContactID," + "FirstName, LastName FROM Person.Contact";
            // Create a data adapter
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);

            // Fill a DataSet without schema
            DataSet ds = new DataSet();
            da.Fill(ds, "Contact");

            Console.WriteLine("---WITHOUT SCHEMA--", ds.Tables.Count);
            Console.WriteLine("GetXmlSchema( ) = {0}", ds.GetXmlSchema());

            // Fill a DataSet with schema using FillSchema( )
            DataSet dsSchema = new DataSet();
            da.FillSchema(dsSchema, SchemaType.Source, "Person.Contact");
            da.Fill(dsSchema, "Contact");
            Console.WriteLine("\n---WITH SCHEMA using FillSchema( )--",
            dsSchema.Tables.Count);
            Console.WriteLine(
            "GetXmlSchema( ) = {0}", dsSchema.GetXmlSchema());


        }



        public void RetrieveHierarchicalDataSet()
        {
            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelectHeader = "SELECT * FROM Sales.SalesOrderHeader";
            string sqlSelectDetail = "SELECT * FROM Sales.SalesOrderDetail";

            DataSet ds = new DataSet();
            SqlDataAdapter da;

            // Fill the Header table in the DataSet
            da = new SqlDataAdapter(sqlSelectHeader, sqlConnectString);
            da.FillSchema(ds, SchemaType.Source, "SalesOrderHeader");
            da.Fill(ds, "SalesOrderHeader");

            // Fill the Detail table in the DataSet
            da = new SqlDataAdapter(sqlSelectDetail, sqlConnectString);
            da.FillSchema(ds, SchemaType.Source, "SalesOrderDetail");
            da.Fill(ds, "SalesOrderDetail");

            // Relate the Header and Order tables in the DataSet
            DataRelation dr = new DataRelation("SalesOrderHeader_SalesOrderDetail",
            ds.Tables["SalesOrderHeader"].Columns["SalesOrderID"],
            ds.Tables["SalesOrderDetail"].Columns["SalesOrderID"]);
            ds.Relations.Add(dr);

            // Output fields from first three header rows with detail
            for (int i = 0; i < 3; i++)
            {
                DataRow rowHeader = ds.Tables["SalesOrderHeader"].Rows[i];

                Console.WriteLine("HEADER: OrderID = {0}, Date = {1}, TotalDue = {2}", rowHeader["SalesOrderID"], rowHeader["OrderDate"], rowHeader["TotalDue"]);

                foreach (DataRow rowDetail in rowHeader.GetChildRows(dr))
                {
                    Console.WriteLine("\tDETAIL: OrderID = {0}, DetailID = {1}, "
                    +
                    "LineTotal = {2}",
                    rowDetail["SalesOrderID"],
                    rowDetail["SalesOrderDetailID"],
                    rowDetail["LineTotal"]);
                }
            }


        }


        public void RetrieveHierarchicalDataSetBatch()
        {

            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect = "SELECT * FROM Sales.SalesOrderHeader;" + "SELECT * FROM Sales.SalesOrderDetail";
            DataSet ds = new DataSet();
            SqlDataAdapter da;

            // Fill the DataSet with Header and Detail,
            // mapping the default table names
            da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            da.TableMappings.Add("Table", "SalesOrderHeader");
            da.TableMappings.Add("Table1", "SalesOrderDetail");
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds);

            // Relate the Header and Order tables in the DataSet
            DataRelation dr = new DataRelation("SalesOrderHeader_SalesOrderDetail",
            ds.Tables["SalesOrderHeader"].Columns["SalesOrderID"],
            ds.Tables["SalesOrderDetail"].Columns["SalesOrderID"]);
            ds.Relations.Add(dr);

            // Output fields from first three header rows with detail
            for (int i = 0; i < 3; i++)
            {
                DataRow rowHeader = ds.Tables["SalesOrderHeader"].Rows[i];
                Console.WriteLine( "HEADER: OrderID = {0}, Date = {1}, TotalDue = {2}",     rowHeader["SalesOrderID"], rowHeader["OrderDate"],    rowHeader["TotalDue"]);
                foreach (DataRow rowDetail in rowHeader.GetChildRows(dr))
                {
                    Console.WriteLine("\tDETAIL: OrderID = {0}, DetailID = {1}, " + "LineTotal = {2}", rowDetail["SalesOrderID"], rowDetail["SalesOrderDetailID"], rowDetail["LineTotal"]);
                }
            }



        }


        public void NavigatingParentChildTables()
        {

            string sqlConnectString = "Data Source=(local);" +"Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect = @"SELECT * FROM Sales.SalesOrderHeader; SELECT * FROM Sales.SalesOrderDetail;";

            DataSet ds = new DataSet();
            SqlDataAdapter da;

            // Fill the Header and Detail table in the DataSet
            da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.TableMappings.Add("Table", "SalesOrderHeader");
            da.TableMappings.Add("Table1", "SalesOrderDetail");
            da.Fill(ds);

            // Relate the Header and Order tables in the DataSet
            DataRelation dr = new  DataRelation("SalesOrderHeader_SalesOrderDetail",
            ds.Tables["SalesOrderHeader"].Columns["SalesOrderID"],
            ds.Tables["SalesOrderDetail"].Columns["SalesOrderID"]);
            ds.Relations.Add(dr);

            // Iterate over the first two header rows
            for (int i = 0; i < 2; i++)
            {
                // Display data from the SalesOrderHeader record
                DataRow rowHeader = ds.Tables["SalesOrderHeader"].Rows[i];
                Console.WriteLine("HEADER: OrderID = {0}, CustomerID = {1}",
                rowHeader["SalesOrderID"], rowHeader["CustomerID"]);
                // Iterate over the SalesOrderDetail records for the
                // SalesOrderHeader
                foreach (DataRow rowDetail in rowHeader.GetChildRows(dr))
                {
                    Console.WriteLine("\tDETAIL: OrderID = {0}, DetailID = {1}, " +   "CustomerID = {3}",  rowDetail["SalesOrderID"],   rowDetail["SalesOrderDetailID"],  rowDetail["LineTotal"],   rowDetail.GetParentRow(dr)["CustomerID"]);
                }
            }



        }



        public void ExecutingParameterizedQuery()
        {
            // SQL Server parameterized query
            Console.WriteLine("---Data Provider for SQL Server");
            string sqlConnectString = "Data Source=(local);" +  "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect = "SELECT * FROM Sales.SalesOrderHeader " + "WHERE TotalDue > @TotalDue";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectString);
            SqlCommand sqlCommand = new SqlCommand(sqlSelect, sqlConnection);
            // Add the TotalDue parameter to the command
            sqlCommand.Parameters.Add("@TotalDue", SqlDbType.Money);
            // Set the value of the TotalDue paramter
            sqlCommand.Parameters["@TotalDue"].Value = 200000;
            // Use a DataAdapter to retrieve the result set into a DataTable
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCommand);
            DataTable sqlDt = new DataTable();
            sqlDa.Fill(sqlDt);


            foreach (DataRow row in sqlDt.Rows)
            {
                Console.WriteLine
                ("SalesOrderID = {0}, OrderDate = {1}, TotalDue = {2}",
                row["SalesOrderID"], row["OrderDate"], row["TotalDue"]);
            }

            Console.WriteLine();
            // OLE DB parameterized query
            Console.WriteLine("---Data Provider for OLE DB");
            string oledbConnectString = "Provider=SQLOLEDB; Data Source=(local);"
            +
            "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string oledbSelect = "SELECT * FROM Sales.SalesOrderHeader " +
            "WHERE TotalDue > ?";
            SqlConnection oledbConnection =
            new SqlConnection(oledbConnectString);
            SqlCommand oledbCommand = new SqlCommand(oledbSelect, oledbConnection);
            // Add the TotalDue parameter to the command
            oledbCommand.Parameters.Add("@TotalDue", SqlDbType.Int);

            // Set the value of the TotalDue paramter
            oledbCommand.Parameters["@TotalDue"].Value = 200000;

            // Use a DataAdapter to retrieve the result set into a DataTable
            SqlDataAdapter oledbDa = new SqlDataAdapter(oledbCommand);
            DataTable oledbDt = new DataTable();

            oledbDa.Fill(oledbDt);
            foreach (DataRow row in oledbDt.Rows)
            {
                Console.WriteLine ("SalesOrderID = {0}, OrderDate = {1}, TotalDue = {2}", row["SalesOrderID"], row["OrderDate"], row["TotalDue"]);
            }





        }


        public void RetrieveDataSqlServerStoredProcedure()
        {
            string sqlConnectString = "Data Source=(local);" +"Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect = "uspGetEmployeeManagers";

            // Create a connection
            SqlConnection connection = new SqlConnection(sqlConnectString);
            // Create the store procedure command
            SqlCommand command = new SqlCommand(sqlSelect, connection);
            command.CommandType = CommandType.StoredProcedure;
            // Add the parameter and set its value to 100
            command.Parameters.Add("@EmployeeID", SqlDbType.Int).Value = 100;
            // Create a DataTable and fill it using the stored procedure
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            // Output the result set to the console
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("[{0}] {1} {2}, {3} -> {4} {5}, {6}", row["RecursionLevel"], row["EmployeeID"], row["LastName"], row["FirstName"], row["ManagerID"], row["ManagerLastName"], row["ManagerFirstName"]);
            }

        }

        /*
         * 
         * Value Description
            StoredProcedure              Stored procedure.
            TableDirect                 Name of a table. All rows and columns are returned for TableDirect
                                        queries. You can access a join of multiple tables by creating a
                                        comma-delimited list of table names without spaces.
                                        TableDirect is only supported by the OLE DB data provider. You
                                        cannot access multiple tables when CommandType is set to
                                        TableDirect.
            Text                     A SQL text command. This is the default.
         * 
         */

    }
}

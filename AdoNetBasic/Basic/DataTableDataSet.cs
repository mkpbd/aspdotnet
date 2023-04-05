using Microsoft.Data.SqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                Console.WriteLine("HEADER: OrderID = {0}, Date = {1}, TotalDue = {2}", rowHeader["SalesOrderID"], rowHeader["OrderDate"], rowHeader["TotalDue"]);
                foreach (DataRow rowDetail in rowHeader.GetChildRows(dr))
                {
                    Console.WriteLine("\tDETAIL: OrderID = {0}, DetailID = {1}, " + "LineTotal = {2}", rowDetail["SalesOrderID"], rowDetail["SalesOrderDetailID"], rowDetail["LineTotal"]);
                }
            }



        }


        public void NavigatingParentChildTables()
        {

            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
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
            DataRelation dr = new DataRelation("SalesOrderHeader_SalesOrderDetail",
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
                    Console.WriteLine("\tDETAIL: OrderID = {0}, DetailID = {1}, " + "CustomerID = {3}", rowDetail["SalesOrderID"], rowDetail["SalesOrderDetailID"], rowDetail["LineTotal"], rowDetail.GetParentRow(dr)["CustomerID"]);
                }
            }



        }



        public void ExecutingParameterizedQuery()
        {
            // SQL Server parameterized query
            Console.WriteLine("---Data Provider for SQL Server");
            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
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
                Console.WriteLine("SalesOrderID = {0}, OrderDate = {1}, TotalDue = {2}", row["SalesOrderID"], row["OrderDate"], row["TotalDue"]);
            }





        }


        public void RetrieveDataSqlServerStoredProcedure()
        {
            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
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



        public void PassNullValueToStoredProcedureParameter()
        {
            // Create the connection
            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            bool isNullParameter;
            using (SqlConnection connection = new SqlConnection(sqlConnectString))
            {
                // Create the stored procedure command.
                SqlCommand command = new SqlCommand("PassNullParameter", connection);
                command.CommandType = CommandType.StoredProcedure;
                // Define the parameter.

                command.Parameters.Add("@ValueIn", SqlDbType.Int);
                // Set the parameter value to 1 and execute the stored procedure
                command.Parameters[0].Value = 1;
                Console.WriteLine("Parameter value = 1");
                connection.Open();
                isNullParameter = Convert.ToBoolean(command.ExecuteScalar());
                Console.WriteLine(
                "Input parameter is null = {0}", isNullParameter);
                Console.WriteLine();
                // Set the parameter value to null and execute the stored  procedure
                // in a try...catch block
                command.Parameters[0].Value = null;
                Console.WriteLine("Parameter value = null");


                try
                {
                    isNullParameter = Convert.ToBoolean(command.ExecuteScalar());
                    Console.WriteLine(
                    "Input parameter is null = {0}", isNullParameter);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERROR: {0}", ex.Message);
                }
                Console.WriteLine();
                // Set the parameter value to System.DBNull.Value and execute the
                // stored procedure
                command.Parameters[0].Value = System.DBNull.Value;
                Console.WriteLine("Parameter value = System.DBNull.Value");
                isNullParameter = Convert.ToBoolean(command.ExecuteScalar());
                Console.WriteLine(
                "Input parameter is null = {0}", isNullParameter);
                Console.WriteLine();
            }

        }


        public void TableValuedParameter()
        {

            string sqlConnectString = @"Data Source=(local)Integrated security=SSPI;Initial Catalog=AdoDotNet35Cookbook;";
            string sqlSelect = "SELECT * FROM TVPTable";
            // Output the contents of the table in the database
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);

            DataTable dt = new DataTable();
            da.Fill(dt);
            Console.WriteLine("---INITIAL---");
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("ID = {0}\tField1 = {1}\tField2 = {2}",row["ID"], row["Field1"], row["Field2"]);
            }
            // Create the DataTable that will be used to pass a table
            // into the table-valued parameter
            DataTable dtTVP = new DataTable();
            dtTVP.Columns.Add("Id", typeof(int));
            dtTVP.Columns.Add("Field1", typeof(string)).MaxLength = 50;
            dtTVP.Columns.Add("Field2", typeof(string)).MaxLength = 50;
            // Add data to the DataTable
            dtTVP.Rows.Add(new object[] { 1, "Field1.1", "Field2.1" });
            dtTVP.Rows.Add(new object[] { 2, "Field1.2", "Field2.2" });
            dtTVP.Rows.Add(new object[] { 3, "Field1.3", "Field2.3" });


            SqlConnection connection = new SqlConnection(sqlConnectString);
            SqlCommand command = new SqlCommand("InsertTVPTable", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter param = command.Parameters.AddWithValue("@tvp", dtTVP);
            param.SqlDbType = SqlDbType.Structured;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine("\n=> Stored procedure with TVP executed.");
            // Output the contents of the table in the database
            dt.Clear();
            da.Fill(dt);
            Console.WriteLine("\n---FINAL---");
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("ID = {0}\tField1 = {1}\tField2 = {2}",row["ID"], row["Field1"], row["Field2"]);
            }


        }


        public void StoredProcedureReturnValueDataReader()
        {

            string sqlConnectString = "Data Source=(local);" +"Integrated security=SSPI;Initial Catalog=AdventureWorks;";

            using (SqlConnection connection = new SqlConnection(sqlConnectString))
            {
                // Create the stored procedure to use in the DataReader.
                SqlCommand command =
                new SqlCommand("Person.GetContacts", connection);
                command.CommandType = CommandType.StoredProcedure;
                // Create the output parameter
                command.Parameters.Add("@RowCount", SqlDbType.Int).Direction =
                ParameterDirection.Output;
                // Create the return parameter
                SqlParameter retParam =
                command.Parameters.Add("@RetVal", SqlDbType.Int);
                retParam.Direction = ParameterDirection.ReturnValue;
                Console.WriteLine(
                "Before execution, return value = {0}", retParam.Value);
                // Create a DataReader for the result set returned by
                // the stored procedure.
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                Console.WriteLine(
                "After execution, return value = {0}", retParam.Value);
                // Iterate over the records for the DataReader.
                int rowCount = 0;
                while (dr.Read())
                {
                    rowCount++;
                    // Code to process result set in DataReader.
                }
                Console.WriteLine("After reading all {0} rows, return value = {1}",rowCount, retParam.Value);
                // Close the DataReader
                dr.Close();
                Console.WriteLine(  "After DataReader.Close( ), return value = {0}",  retParam.Value);
                connection.Close();
                Console.WriteLine(  "After Connection.Close( ), return value = {0}", retParam.Value);
            }


            /****
             * 
             * 
             * 
             * Value Description
                Input                   The parameter is an input parameter allowing the caller to pass a data
                                         value to the stored procedure.
                InputOutput         The parameter is both an input and output parameter, allowing the caller to
                                    pass a data value to the stored procedure and the stored procedure to pass a
                                    data value back to the caller.
                Output              The parameter is an output parameter allowing the stored procedure to
                                    pass a data value back to the caller.
                ReturnValue         The parameter represents the value returned from the stored procedure.
             * 
             * 
             * 
             * 
             */
        }


        public void StoredProcedureOutputValueDataReader()
        {

            string sqlConnectString = "Data Source=(local);" +
"Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            using (SqlConnection connection = new SqlConnection(sqlConnectString))
            {
                // Create the stored procedure to use in the DataReader.
                SqlCommand command =
                new SqlCommand("Person.GetContacts", connection);
                command.CommandType = CommandType.StoredProcedure;
                // Create the output parameter
                command.Parameters.Add("@RowCount", SqlDbType.Int).Direction =
                ParameterDirection.Output;
                Console.WriteLine("Before execution, @RowCount = {0}",
                command.Parameters["@RowCount"].Value);
                // Create a DataReader for the result set returned by
                // the stored procedure.
                connection.Open();
                SqlDataReader dr = command.ExecuteReader();
                Console.WriteLine("After execution, @RowCount = {0}",
                command.Parameters["@RowCount"].Value);
                // Iterate over the records for the DataReader.
                int rowCount = 0;
                while (dr.Read())
                {
                    rowCount++;
                    // Code to process result set in DataReader.
                }
          //      Console.WriteLine("After reading all {0} rows, @RowCount = {1}",(g { } , @{ } ,rowCount, command.Parameters["@RowCount"].Value);
                // Close the DataReader
                dr.Close();
                Console.WriteLine("After DataReader.Close( ), @RowCount = {0}",
                command.Parameters["@RowCount"].Value);
                connection.Close();
                Console.WriteLine("After Connection.Close(), @RowCount = {0}",
                command.Parameters["@RowCount"].Value);
            }


        }



        public void RaiseAndHandleStoredProcedureError()
        {
            string sqlConnectString = "Data Source=(local);" +"Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            using (SqlConnection connection = new SqlConnection(sqlConnectString))
            {
                // Attach handler for SqlInfoMessage events.
              //  connection.InfoMessage += new SqlInfoMessageEventHandler(SqlMessageEventHandler);
                // Create the stored procedure
                SqlCommand command = new SqlCommand("RaiseError", connection);
                command.CommandType = CommandType.StoredProcedure;
                // Create the input parameters for error severity and state
                command.Parameters.Add("@Severity", SqlDbType.Int);
                command.Parameters.Add("@State", SqlDbType.Int);
                for (int severity = -1; severity <= 26; severity++)
                {
                    // Set the value for the stored procedure parameters.
                    command.Parameters["@Severity"].Value = severity;


                }

                command.Parameters["@State"].Value = 0;
                // Open the connection.
                connection.Open();
                try
                {
                    // Try to execute the stored procedure.
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    // Catch SqlException errors.
                    Console.WriteLine("ERROR: {0}", ex.Message);
                }
                catch (Exception ex)
                {
                    // Catch other errors.
                    Console.WriteLine("OTHER ERROR: {0}", ex.Message);
                }
                finally
                {
                    // Close the connection.
                    connection.Close();
                }
            }
        }



        public void ExecuteUserDefinedScalarValuedFunction()
        {

            string sqlConnectString = "Data Source=(local);" +"Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect = "SELECT TOP 5 *, " + "dbo.ExtendedPrice(UnitPrice, OrderQty, UnitPriceDiscount) " +  "ExtendedPrice FROM Sales.SalesOrderDetail";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
                Console.WriteLine("SalesOrderDetailID = {0}, LineTotal = {1}, " +
                "ExtendedPrice = {2}", row["SalesOrderDetailID"],
                row["LineTotal"], row["ExtendedPrice"]);

            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();

        }

        public void ExecuteTableValuedFunction()
        {
            string sqlConnectString = "Data Source=(local);" +"Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            // Select all fields from all records returned by the
            // table-valued function for ContactID = 10.
            string sqlSelect = "SELECT * FROM dbo.ufnGetContactInformation(10)";
            // Fill a Data Table with the result set from the table-valued function


            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            // Output the row count and result set to the console
            Console.WriteLine("{0} rows retrieved.\n", dt.Rows.Count);
            foreach (DataColumn col in dt.Columns)
            {
                Console.WriteLine("{0} = {1}",
                col.ColumnName, dt.Rows[0][col.Ordinal]);
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();

        }

    }

}


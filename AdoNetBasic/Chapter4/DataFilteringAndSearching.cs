using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetBasic.Chapter4
{
    public class DataFilteringAndSearching
    {

        public void DetermineDataDifferenceDataSets()
        {
            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            // Fill DataSet A
            string sqlSelectA = "SELECT * FROM HumanResources.Department " + "WHERE DepartmentID BETWEEN 1 AND 5";
            DataSet dsA = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sqlSelectA, sqlConnectString);

            da.TableMappings.Add("Table", "TableA");
            da.FillSchema(dsA, SchemaType.Source);
            da.Fill(dsA);
            // Set the primary key
            dsA.Tables["TableA"].PrimaryKey = new DataColumn[] { dsA.Tables["TableA"].Columns["DepartmentID"]
            };

            // Fill DataSet B
            string sqlSelectB = "SELECT * FROM HumanResources.Department " + "WHERE DepartmentID BETWEEN 4 AND 8";
            DataSet dsB = new DataSet();
            da = new SqlDataAdapter(sqlSelectB, sqlConnectString);
            da.TableMappings.Add("Table", "TableB");
            da.FillSchema(dsB, SchemaType.Source);
            da.Fill(dsB);
            // Set the primary key
            dsB.Tables["TableB"].PrimaryKey = new DataColumn[] { dsB.Tables["TableB"].Columns["DepartmentID"]
            };

            Console.WriteLine(GetDataSetDifference(dsA, dsB));
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }


        private static string GetDataSetDifference(DataSet ds1, DataSet ds2)
        {
            // Accept any edits within the DataSet objects.
            ds1.AcceptChanges();
            ds2.AcceptChanges();
            // Create a DataSet to store the differences.
            DataSet ds = new DataSet();
            DataTable dt1Copy = null;
            // Iterate over the collection of tables in the first DataSet.
            for (int i = 0; i < ds1.Tables.Count; i++)
            {
                DataTable dt1 = ds1.Tables[i];
                DataTable dt2 = ds2.Tables[i];
                // Create a copy of the table in the first DataSet.
                dt1Copy = dt1.Copy();
                // Iterate over the collection of rows in the
                // copy of the table from the first DataSet.



                foreach (DataRow row1 in dt1Copy.Rows)
                {
                    DataRow row2 = dt2.Rows.Find(row1["DepartmentID"]);
                    if (row2 == null)
                    {
                        // Delete rows not in table 2 from table 1.
                        row1.Delete();
                    }
                    else
                    {
                        // Modify table 1 rows that are different from
                        // table 2 rows.
                        for (int j = 0; j < dt1Copy.Columns.Count; j++)
                        {
                            if (row2[j] == DBNull.Value)
                            {
                                // Column in table 2 is null,
                                // but not null in table 1
                                if (row1[j] != DBNull.Value)
                                    row1[j] = DBNull.Value;
                            }
                            else if (row1[j] == DBNull.Value)
                            {
                                // Column in table 1 is null,
                                // but not null in table 2
                                row1[j] = row2[j];
                            }
                            else if (row1[j].ToString() !=
                            row2[j].ToString())
                            {
                                // Neither column in table 1 nor
                                // table 2 is null, and the
                                // values in the columns are
                                // different.
                                row1[j] = row2[j];
                            }
                        }
                    }
                }
                foreach (DataRow row2 in dt2.Rows)
                {
                    DataRow row1 =
                    dt1Copy.Rows.Find(row2["DepartmentID"]);
                    if (row1 == null)
                    {
                        // Insert rows into table 1 that are in table 2
                        // but not in table 1.
                        dt1Copy.LoadDataRow(row2.ItemArray, false);
                    }
                    // Add the table to the difference DataSet.
                    ds.Tables.Add(dt1Copy);
                }

            }
            // Write a XML DiffGram with containing the differences between  tables.
            StringWriter sw = new StringWriter();
            ds.WriteXml(sw, XmlWriteMode.DiffGram);
            return sw.ToString();
        }



        public void CombineHeterogeneousData()
        {

            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string accessFileName =
            @"C:\Documents and Settings\bill\MyDocuments\AdventureWorks.accdb";
            string sqlSelect =
            "SELECT TOP 20 h.SalesOrderID, h.CustomerID, h.OrderDate, " +
            "d.ProductID, d.OrderQty, d.LineTotal " +
            "FROM Sales.SalesOrderHeader h INNER JOIN " +
            "OPENROWSET('Microsoft.ACE.OLEDB.12.0','" + accessFileName +
            "';'admin';'',Sales_SalesOrderDetail) AS d " +
            "ON h.SalesOrderID = d.SalesOrderID " +
            "ORDER BY h.SalesOrderID, d.ProductID";
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Console.WriteLine("OrderID\tCustID\tOrderDate\t\tProdID\t" + "Qty\tLineTotal");
            foreach (DataRow row in dt.Rows)
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
                row["SalesOrderID"], row["CustomerID"], row["OrderDate"],
                row["ProductID"], row["OrderQty"], row["LineTotal"]);
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }


        public void FilterRows()
        {
            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect = "SELECT * FROM Person.Contact";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            da.Fill(dt);
            string filter = "LastName LIKE 'AG*'";
            // Filter the rows using Select() method of DataTable
            DataRow[] rows = dt.Select(filter);
            Console.WriteLine("---Filtering using DataTable.Select()---");
            foreach (DataRow row in rows)
                Console.WriteLine("{0}\t{1}, {2}", row["ContactID"], row["LastName"], row["FirstName"]);
            Console.WriteLine();
            // Filter the rows using RowFilter property of a DataView
            DataView dv = dt.DefaultView;
            dv.RowFilter = filter;
            Console.WriteLine("---Filtering using DataView.RowFilter---");
            foreach (DataRowView row in dv)
                Console.WriteLine("{0}\t{1}, {2}", row["ContactID"], row["LastName"], row["FirstName"]);
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();

        }


        public void FindRows2()
        {
            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect = "SELECT * FROM Person.Contact";
            // Fill the DataTable with schema and data
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            da.FillSchema(dt, SchemaType.Source);
            da.Fill(dt);
            // Find a row matching a primary key (ContactID) value (429)
            Console.WriteLine("---Finding rows using DataTable.Rows.Find()---");
            DataRow row = dt.Rows.Find(new object[] { 429 });
            if (row != null)
                Console.WriteLine("{0}\t{1}, {2}",
                row["ContactID"], row["LastName"], row["FirstName"]);
            else
                Console.WriteLine("Row not found.");
            Console.WriteLine();


            DataView dv = dt.DefaultView;
            // Find a row matching a primary key (ContactID) value (429)
            Console.WriteLine("---Finding a row using DataView.Find()---");
            dv.Sort = "ContactID";
            int rowIndex = dv.Find(new object[] { 429 });
            if (rowIndex != -1)
                Console.WriteLine("{0}\t{1}, {2}", dv[rowIndex]["ContactID"], dv[rowIndex]["LastName"], dv[rowIndex]["FirstName"]);
            else
                Console.WriteLine("Row not found.");
            Console.WriteLine();
            // Find rows matching the sort field LastName in a DataView
            dv.Sort = "LastName";
            DataRowView[] drv = dv.FindRows(new object[] { "Jacobson" });
            Console.WriteLine("---Finding rows using DataView.FindRows()---");
            foreach (DataRowView dvrow in drv)
                Console.WriteLine("{0}\t{1}, {2}", dvrow["ContactID"], dvrow["LastName"], dvrow["FirstName"]);
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }



        public void FilterSortData()
        {

            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect = "SELECT * FROM Production.Product";
            // Fill the DataSet, mapping the default table name
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            da.TableMappings.Add("Table", "Product");
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataView dv = ds.Tables["Product"].DefaultView;
            dv.RowFilter = "DaysToManufacture >= 4";
            dv.Sort = "Name";
            foreach (DataRowView dvr in dv)
                Console.WriteLine("ProductID = {0}, Name = {1}, DaysToManufacture = {2}", dvr["ProductID"], dvr["Name"], dvr["DaysToManufacture"]);
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }




        public void FilterSortDataSelect()
        {
            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect = "SELECT * FROM Production.Product";
            // Fill the DataSet, mapping the default table name
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            da.TableMappings.Add("Table", "Product");
            DataSet ds = new DataSet();
            da.Fill(ds);
            // Filter and sort using the Select() method of the DataTable
            string rowFilter = "DaysToManufacture >= 4";
            string sort = "Name";
            DataRow[] rows = ds.Tables["Product"].Select(rowFilter, sort);
            foreach (DataRow row in rows)
                Console.WriteLine("ProductID = {0}, Name = {1}, DaysToManufacture = {2}", row["ProductID"], row["Name"], row["DaysToManufacture"]);
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }


        public void FilterNullValues()
        {
            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect = "SELECT * FROM Person.Contact";

            string filter = "Title IS NULL";
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            da.Fill(dt);
            // Filter the rows using Select() method of DataTable
            DataRow[] rows = dt.Select(filter);
            // Output the top 5 rows
            Console.WriteLine("---DataTable.Select()---");
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine("{0}\tTitle = '{1}'\t{2}, {3}",
                rows[i]["ContactID"], rows[i]["Title"],
                rows[i]["LastName"], rows[i]["FirstName"]);
            }

            // Filter the rows using the Filter property of the DataView
            DataView dv = dt.DefaultView;
            dv.RowFilter = filter;
            // Output the top 5 rows
            Console.WriteLine("\n---Filter property of DataView---");
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine("{0}\tTitle = '{1}'\t{2}, {3}",
                dv[i]["ContactID"], dv[i]["Title"],
                dv[i]["LastName"], dv[i]["FirstName"]);
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }


        public void AccessDeletedDataRows()
        {
            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect = "SELECT TOP 3 ContactID, FirstName, LastName " +
            "FROM Person.Contact";
            // Fill the DataSet with the results of the batch query.
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            // Output the rows in the DataTable
            Console.WriteLine("---ORIGINAL DATATABLE---");
            foreach (DataRow row in dt.Rows)
                Console.WriteLine("{0}, {1}, {2}", row[0], row[1], row[2]);
            Console.WriteLine();
            // Delete row 2
            dt.Rows[1].Delete();

            // Output the rows in the DataTable
            Console.WriteLine("---AFTER ROW 2 DELETED---");
            foreach (DataRow row in dt.Rows)
            {
                if (row.RowState == DataRowState.Deleted)
                {
                    Console.WriteLine("{0}:\t {1}, {2}, {3}",
                    row.RowState, row[0, DataRowVersion.Original],
                    row[1, DataRowVersion.Original], row[2,
                    DataRowVersion.Original]);
                }
                else
                {
                    Console.WriteLine("{0}:\t {1}, {2}, {3}", row.RowState,
                    row[0], row[1], row[2]);
                }
            }
            Console.WriteLine();
            Console.WriteLine("---USING DATAVIEW CONSTRUCTOR TO ACCESS DELETED  ROW-- - ");
            DataView dv = new DataView(dt, null, null, DataViewRowState.Deleted);
            foreach (DataRowView row in dv)
                Console.WriteLine("{0}, {1}, {2}", row[0], row[1], row[2]);
            Console.WriteLine("\n---USING DATAVIEW FILTER TO ACCESS DELETED ROWS(--");
            dv = new DataView(dt);
            dv.RowStateFilter = DataViewRowState.Deleted;
            foreach (DataRowView row in dv)
                Console.WriteLine("{0}, {1}, {2}", row[0], row[1], row[2]);
            Console.WriteLine("\n---USING DATATABLE.SELECT()---");
            // Get the DataRow array of deleted items
            DataRow[] dra = dt.Select(null, null, DataViewRowState.Deleted);
            // Iterate over the array and display the original version of each
            // deleted row
            for (int i = 0; i < dra.Length; i++)
            {
                Console.WriteLine("{0}, {1}, {2}", dra[i][0,
                DataRowVersion.Original],
                dra[i][1, DataRowVersion.Original],
                dra[i][2, DataRowVersion.Original]);
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();


        }


        public void SelectTopNRowsDataTable()
        {
            int topN = 4;

            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect = "SELECT * FROM Sales.SalesTaxRate";
            // Fill the DataTable with Sales.SalesOrderHeader schema and data
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            da.FillSchema(dt, SchemaType.Source);
            da.Fill(dt);
            // Sort the default view on the TaxRate field
            DataView dv = dt.DefaultView;
            dv.Sort = "TaxRate DESC";
            // Output the top 10 records from the DataView
            Console.WriteLine("---First 10 records from DataView---");
            for (int i = 0; i < 10; i++)
                Console.WriteLine("Record = {0}\t{1}\t{2}\tTaxRate = {3}", i + 1,
                dv[i]["SalesTaxRateID"], dv[i]["StateProvinceID"],
                dv[i]["TaxRate"]);
            // Create a filter for all records with a value <= the nth.
            StringBuilder filter = new StringBuilder("SalesTaxRateID >=" +
            dv[topN - 1]["SalesTaxRateID"]);
            dv.RowFilter = filter.ToString();
            // Handle where there is more than one record with the nth value.
            // Eliminate enough rows from the bottom of the dv using a filter on
            // the primary key to return the correct number (top N) of values.
            bool refilter = false;
            // Iterate over all records in the view after the nth.
            for (int i = dv.Count; i > topN; i--)
            {
                // Exclude the record using a filter on the primary key
                filter.Append(" AND SalesTaxRateID <> " + dv[i - 1]
                ["SalesTaxRateID"]);
                refilter = true;
            }

            // Reapply the view filter if necessary.
            if (refilter)
                dv.RowFilter = filter.ToString();
            // Output all of the records from the filtered DataView
            int record = 1;
            Console.WriteLine("\n---Top {0} records using filtered DataView---", topN);
            foreach (DataRowView row in dv)
                Console.WriteLine("Record: {0}\t{1}\t{2}\tTaxRate = {3}",
                record++,
                row["SalesTaxRateID"], row["StateProvinceID"],
                row["TaxRate"]);
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();




        }


        public void ExecuteComputeByQuery()
        {
            string oledbConnectString = "Provider=SQLOLEDB;Data Source=(local);" + "Integrated Security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect = "SELECT SalesOrderID, ProductID, OrderQty " +
            "FROM Sales.SalesOrderDetail " +
            "WHERE SalesOrderID BETWEEN 43683 AND 43699 " + "ORDER BY ProductID " +
            "COMPUTE SUM(OrderQty) BY ProductID";
            using (OleDbConnection connection = new OleDbConnection(oledbConnectString))
            {
                OleDbCommand command = new OleDbCommand(sqlSelect, connection);
                connection.Open();
                OleDbDataReader dr = command.ExecuteReader();
                do
                {
                    // Output the detail result set.
                    Console.WriteLine("Order\tProduct\tQuantity");
                    while (dr.Read())
                        Console.WriteLine("{0}\t{1}\t{2}", dr.GetInt32(0), dr.GetInt32(1), dr.GetInt16(2));
                    Console.WriteLine();
                    // Output the sum result set.
                    dr.NextResult();
                    dr.Read();
                    Console.WriteLine("SUM:\t\t{0}\n", dr.GetInt32(0));
                } while (dr.NextResult());
            }

        }


        public void RetrieveRandomSampleRecords()
        {

            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect;
            DataTable dt;
            SqlDataAdapter da;
            // Get the count of records in Person.Contact.
            sqlSelect = "SELECT COUNT(*) FROM Person.Contact";
            int recCount;
            using (SqlConnection connection = new
            SqlConnection(sqlConnectString))
            {
                SqlCommand command = new SqlCommand(sqlSelect, connection);
                connection.Open();
                recCount = (int)command.ExecuteScalar();
            }
            Console.WriteLine("Person.Contact record count = {0}\n", recCount);
            // Fill the DataTable with Person.Contact data
            sqlSelect = "SELECT * FROM Person.Contact TABLESAMPLE (10 PERCENT)";
            dt = new DataTable();
            da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            da.Fill(dt);
            // Output the top 10 rows using TABLESAMPLE
            Console.WriteLine("---{0} rows retrieved using TABLESAMPLE. " +
            "Displaying top 10 rows.---", dt.Rows.Count);
            for (int i = 0; i < 10; i++)
                Console.WriteLine("ID = {0}\t{1}, {2}",
                dt.Rows[i]["ContactID"], dt.Rows[i]["LastName"],
                dt.Rows[i]["FirstName"]);

            // Fill the DataTable with Person.Contact data
            sqlSelect = "SELECT * FROM Person.Contact WHERE " + "0.1 >= CAST(CHECKSUM(NEWID(), ContactID) & 0x7fffffff AS float) " + "/ CAST(0x7fffffff AS int)";

            dt = new DataTable();
            da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            da.Fill(dt);
            // Output top 10 rows using custom method
            Console.WriteLine("\n---{0} rows retrieved using custom method. " +
            "Displaying top 10 rows.---", dt.Rows.Count);
            for (int i = 0; i < 10; i++)
                Console.WriteLine("ID = {0}\t{1}, {2}",
                dt.Rows[i]["ContactID"], dt.Rows[i]["LastName"],
                dt.Rows[i]["FirstName"]);
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }


        public void ExecuteCommonTableExpression()
        {
            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect =
            "WITH ManagerEmployees(ManagerID, EmployeesPerManager) AS " +
            "( SELECT ManagerID, COUNT(*) " +
            "FROM HumanResources.Employee " +
            "WHERE ManagerID <= 25 " +
            "GROUP BY ManagerID ) " +
            "SELECT ManagerID, EmployeesPerManager " +
            "FROM ManagerEmployees " +
            "ORDER BY ManagerID";
            // Fill the DataTable
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            da.Fill(dt);

            Console.WriteLine("ManagerID\tEmployeesPerManager");
            foreach (DataRow row in dt.Rows)
                Console.WriteLine("{0}\t\t{1}", row["ManagerID"],
                row["EmployeesPerManager"]);
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();

        }


        public void ExecuteRecursiveQuery()
        {
            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect =
            "WITH DirectReports( " +
            "ManagerID, EmployeeID, Title, FirstName, LastName, EmployeeLevel) AS " + "(SELECT e.ManagerID, e.EmployeeID, e.Title, c.FirstName,c.LastName, " +
            "0 AS EmployeeLevel " +
            "FROM HumanResources.Employee e " +
            "JOIN Person.Contact AS c ON e.ContactID = c.ContactID " +
            "WHERE ManagerID IS NULL " +
            "UNION ALL " +
            "SELECT e.ManagerID, e.EmployeeID, e.Title, c.FirstName,c.LastName, " +
            "EmployeeLevel + 1 " +
            "FROM HumanResources.Employee e " +
            "INNER JOIN DirectReports d ON e.ManagerID = d.EmployeeID " +
            "JOIN Person.Contact AS c ON e.ContactID = c.ContactID) " +
            "SELECT TOP 20 * " +
            "FROM DirectReports";

            // Fill the DataTable
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            da.Fill(dt);
            Console.WriteLine("MgrID\tEmpID\tTitle\t\t\tLevel\tName");
            foreach (DataRow row in dt.Rows)
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}, {5}",
                row["ManagerID"], row["EmployeeID"],
                row["Title"].ToString().PadRight(23).Substring(0, 23),
                row["EmployeeLevel"], row["LastName"], row["FirstName"]);
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();



        }



        public void RetrieveRankedResultSet()
        {
            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect = "SELECT TOP 10 ROW_NUMBER() " +
            "OVER(ORDER BY LastName, FirstName) Rank, " +
            "ContactID, FirstName, LastName " +
            "FROM Person.Contact";
            // Fill the DataTable
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            da.Fill(dt);
            Console.WriteLine("Rank\tID\tName");
            foreach (DataRow row in dt.Rows)
                Console.WriteLine("{0}\t{1}\t{2}, {3}",
                row["Rank"], row["ContactID"], row["LastName"],
                row["FirstName"]);
            Console.WriteLine("\nPress any key to continue.");

        }

        public void RetrieveRankedPartitionedResultSet()
        {
            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";

            string sqlSelect = "SELECT TOP 20 ManagerID, ROW_NUMBER() " +
                "OVER(PARTITION BY ManagerID ORDER BY LastName, FirstName) Rank," + "e.ContactID, FirstName, LastName " +
                "FROM HumanResources.Employee e " +
                " LEFT JOIN Person.Contact c " +
                " ON e.ContactID = c.ContactID";
            // Fill the DataTable
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            da.Fill(dt);
            Console.WriteLine("MgrID\tRank\tID\tName");
            foreach (DataRow row in dt.Rows)
                Console.WriteLine("{0}\t{1}\t{2}\t{3}, {4}",
                row["ManagerID"], row["Rank"], row["ContactID"],
                row["LastName"], row["FirstName"]);
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }


        public void RetrievePivotTable()
        {
            string sqlConnectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect = "SELECT EmployeeID, [2002] Y2002, " +
            "[2003] Y2003, [2004] Y2004 FROM " +
            "(SELECT YEAR(OrderDate) OrderYear, EmployeeID, TotalDue " +
            "FROM Purchasing.PurchaseOrderHeader) poh " +
            "PIVOT (SUM(TotalDue) FOR OrderYear IN " +
            "([2002], [2003], [2004])) pvt " +
            "WHERE EmployeeID BETWEEN 200 AND 300 " +
            "ORDER BY EmployeeID";
            // Fill the DataTable
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            da.Fill(dt);
            Console.WriteLine("Employee ID\t2002\t\t2003\t\t2004");
            Console.WriteLine("-----------\t----\t\t----\t\t----");
            foreach (DataRow row in dt.Rows)
                Console.WriteLine("{0}\t\t{1}\t{2}\t{3}", row["EmployeeID"],
                row["Y2002"], row["Y2003"], row["Y2004"]);
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();

        }


        public void RetrieveUnpivotTable()
        {
            string sqlConnectString = "Data Source=(local);" +"Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect = "SELECT EmployeeID, OrderYear, TotalDue FROM " +
            "(SELECT EmployeeID, [2002] Y2002, " +
            "[2003] Y2003, [2004] Y2004 FROM " +
            "(SELECT YEAR(OrderDate) OrderYear, EmployeeID, TotalDue " +
            "FROM Purchasing.PurchaseOrderHeader) poh " +
            "PIVOT (SUM(TotalDue) FOR OrderYear IN " +"([2002], [2003], [2004])) pvt " +"WHERE EmployeeID BETWEEN 200 AND 300) pvtTable " +"UNPIVOT " +"(TotalDue FOR OrderYear IN (Y2002, Y2003, Y2004)) unpvt " +"ORDER BY EmployeeID, OrderYear";
            // Fill the DataTable
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            da.Fill(dt);

            Console.WriteLine("EmployeeID\tOrderYear\tTotalDue");
            foreach (DataRow row in dt.Rows)
                Console.WriteLine("{0}\t\t{1}\t\t{2}",
                row["EmployeeID"], row["OrderYear"], row["TotalDue"]);
        }


        public void InvokeFunctionForEachRowResultSet()
        {
            string sqlConnectString = "Data Source=(local);" +"Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect = "SELECT e.ContactID, " +
            "c.FirstName, c.LastName, c.JobTitle, c.ContactType " +
            "FROM HumanResources.Employee e " +
            "CROSS APPLY ufnGetContactInformation(e.ContactID) c " +
            "WHERE e.ContactID BETWEEN 1285 AND 1290 " +
            "ORDER BY e.ContactID";
            // Fill the DataTable
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, sqlConnectString);
            da.Fill(dt);


            Console.WriteLine("ID\tType\t\tName\t\tJobTitle");
            Console.WriteLine("--\t----\t\t----\t\t--------");
            foreach (DataRow row in dt.Rows)
                Console.WriteLine("{0}\t{1}\t{2}, {3}\t{4}",
                row["ContactID"], row["ContactType"], row["LastName"],
                row["FirstName"], row["JobTitle"]);
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();


        }

    }

}

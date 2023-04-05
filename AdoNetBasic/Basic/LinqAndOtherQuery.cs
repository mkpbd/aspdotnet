﻿using AdoNetBasic.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdoNetBasic.Basic
{
    public class LinqAndOtherQuery
    {
        public void LinqToDataSetQuery()
        {
            string connectString = "Data Source=(local);" + "Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            string sqlSelect = "SELECT * FROM Production.Product; " + "SELECT * FROM Production.ProductInventory;";
            // Create the data adapter to retrieve data from the database
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, connectString);
            // Create table mappings
            da.TableMappings.Add("Table", "Product");
            da.TableMappings.Add("Table1", "ProductInventory");
            // Create and fill the DataSet
            DataSet ds = new DataSet();
            da.Fill(ds);
            // Create the relationship between the Product and ProductInventory tables
            DataRelation dr = ds.Relations.Add("Product_ProductInventory",
            ds.Tables["Product"].Columns["ProductID"],
            ds.Tables["ProductInventory"].Columns["ProductID"]);
            DataTable product = ds.Tables["Product"];
            DataTable inventory = ds.Tables["ProductInventory"];
            var query = from p in product.AsEnumerable()
                        join i in inventory.AsEnumerable()
                        on p.Field<int>("ProductID") equals
                        i.Field<int>("ProductID")
                        where p.Field<int>("ProductID") < 100
                        select new
                        {
                            ProductID = p.Field<int>("ProductID"),
                            Name = p.Field<string>("Name"),
                            LocationID = i.Field<short>("LocationID"),
                            Quantity = i.Field<short>("Quantity")
                        };

            foreach (var q in query)
            {
                Console.WriteLine("{0} - {1}: LocationID = {2} => Quantity = {3}",
                q.ProductID, q.Name, q.LocationID, q.Quantity);
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }


        public void LinqInColorQuery()
        {

            string[] colors = { "Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Violet" };
            var colorQuery = from color in colors
                             where color.Length <= 5
                             orderby color
                             select color;
            foreach (string s in colorQuery)
                Console.WriteLine(s);
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }



        public void LINQtoDataSet()
        {
            var product = new[] {
                new {ProductID =  1, Name = " abc", LocationID = 1,Quantity = 33,},
                new {ProductID =  2, Name = " abc", LocationID = 1,Quantity = 33,},
                new {ProductID =  3, Name = " abc", LocationID = 1,Quantity = 33,},
                new {ProductID =  4, Name = " abc", LocationID = 1,Quantity = 33,},
                new {ProductID =  5, Name = " abc", LocationID = 1,Quantity = 33,},
                new {ProductID =  6, Name = " abc", LocationID = 1,Quantity = 33,},
                new {ProductID =  7, Name = " abc", LocationID = 1,Quantity = 33,},
            };

            //var query = from p in product.AsEnumerable()
            //            where p.Field<int>("ProductID") < 100
            //            from i in p.GetChildRows("Product_ProductInventory")
            //            select new
            //            {
            //                ProductID = p.Field<int>("ProductID"),
            //                Name = p.Field<string>("Name"),
            //                LocationID = i.Field<int>("LocationID"),
            //                Quantity = i.Field<int>("Quantity")
            //            };




            var query = from p in product.AsEnumerable()
                        where p.ProductID < 100

                        select new
                        {
                            ProductID = p.ProductID,
                            Name = p.Name,
                            LocationID = p.LocationID,
                            Quantity = p.Quantity
                        };

            foreach (var q in query)
            {
                Console.WriteLine("{0} - {1}: LocationID = {2} => Quantity = {3}", q.ProductID, q.Name, q.LocationID, q.Quantity);
            }


        }

        private static MyDataClassesDataContext dc;

        public void LinqToSql()
        {
            dc = new MyDataClassesDataContext();
            // Execute the queries and output results
            Query1();
            Query2();
            Query3();
            Query4();
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();

        }

        private static void Query1()
        {
            Console.WriteLine("---QUERY 1---");
            var products = from row in dc.Products
                           where row.ProductID < 100
                           select row;
            foreach (Product p in products)
                Console.WriteLine(p.ProductID + ": " + p.Name);
        }
        private static void Query2()
        {
            Console.WriteLine("\n---QUERY 2---");
            var products = from row in dc.Products
                           where row.ProductID < 100
                           select new
                           {
                               ProductID = row.ProductID,
                               ProductName = row.Name
                           };
            foreach (var p in products)
                Console.WriteLine(p.ProductID + ": " + p.ProductName);
        }
        private static void Query3()
        {
            Console.WriteLine("\n---QUERY 3---");
            var products = from row in dc.Products
                           where row.ProductID < 100
                           select row;
            foreach (var p in products)
            {
                Console.WriteLine("{0}: {1}", p.ProductID, p.Name);
                // iterate over the collection of ProductInventory records
                foreach (var pi in p.ProductInventories)
                    Console.WriteLine(" {0} = {1}", pi.LocationID,
                    pi.Quantity);
            }
        }


        private static void Query4()
        {
            Console.WriteLine("\n---QUERY 4---");
            var query = from p in dc.Products
                        join pi in dc.ProductInventories
                        on p.ProductID equals pi.ProductID into pis
                        where p.ProductID < 100
                        select new { Product = p, Inventories = pis };
            foreach (var q in query)
            {
                Console.WriteLine("{0}: {1}", q.Product.ProductID,
                q.Product.Name);
                // iterate over the collection of ProductInventory records
                foreach (var pi in q.Inventories)
                    Console.WriteLine(" {0} = {1}", pi.LocationID,
                    pi.Quantity);
            }
        }



        public void ReadTextFileData()
        {

            string sqlSelect = "SELECT * FROM [Category.txt]";
            string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=..\..\..\;" + "Extended Properties=\"text;HDR=yes;FMT=Delimited\";";

            // Create and fill a DataTable.
            OleDbDataAdapter da = new OleDbDataAdapter(sqlSelect, connectString);
            DataTable dt = new DataTable("Categories");
            da.Fill(dt);
            Console.WriteLine("CategoryID; CategoryName; Description\n");
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("{0}; {1}; {2}", row["CategoryID"],
                row["CategoryName"], row["Description"]);
            }
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
        }




        public void ReadExcelData()
        {

            string oledbConnectString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=..\..\..\Category.xlsx;" + "Extended Properties=\"Excel 12.0;HDR=YES\";";
            string commandText = "SELECT CategoryID, CategoryName, " + "Description FROM [Sheet1$]";
            Console.WriteLine("---CONNECTION---");
            Console.WriteLine(oledbConnectString);
            OleDbConnection connection = new OleDbConnection(oledbConnectString);
            OleDbCommand command = new OleDbCommand(commandText, connection);
            connection.Open();
            OleDbDataReader dr = command.ExecuteReader();
            Console.WriteLine("\nID Name Description");

            while (dr.Read())
            {
                Console.WriteLine("{0} {1} {2}", dr["CategoryID"], dr["CategoryName"].ToString().PadRight(14), dr["Description"]);
            }
            connection.Close();
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();




        }


        public void QueryingDataAsynchronouslywithMessageQueuing()
        {
            string queueNameQuery = @".\Private$\AdoNet35Cookbook_AsynchronousQuery";
            string queueNameResult = @".\Private$\AdoNet35Cookbook_AsynchronousResult";
            int contactID = 10;


            // Create the query queue if it does not exist.
            if (!MessageQueue.Exists(queueNameQuery))
            {
                MessageQueue.Create(queueNameQuery);
                Console.WriteLine("Query queue {0} created.", queueNameQuery);
            }
            else
                Console.WriteLine("Query queue {0} found.", queueNameQuery);
            // Create the result queue if it does not exist.
            if (!MessageQueue.Exists(queueNameResult))
            {
                MessageQueue.Create(queueNameResult);
                Console.WriteLine("Result queue {0} created.", queueNameResult);
            }
            else
                Console.WriteLine("Result queue {0} found.", queueNameResult);
            // Create an object to access the query queue for sending.


            using (MessageQueue mqQueryOut = new MessageQueue(queueNameQuery))
            {
                mqQueryOut.Formatter =
                new XmlMessageFormatter(new Type[] { typeof(String) });
                // Send a message containing the contact ID to query for.
                string body = "ContactID=" + contactID;
                mqQueryOut.Send(body);
                Console.WriteLine(
                "\nQuery for ContactID = {0} sent to query queue.",
                contactID);
            }
            // Create an object to access the query queue for receiving.
            int queryContactID;
            using (MessageQueue mqQueryIn = new MessageQueue(queueNameQuery))
            {
                mqQueryIn.Formatter =
new XmlMessageFormatter(new Type[] { typeof(String) });
                // Retrieve the query message from the queue
                Message msg = mqQueryIn.Receive(new TimeSpan(0, 0, 1));
                Console.WriteLine("\nQuery message {0} received.", msg.Id);
                // Get the contact ID from the message body.
                queryContactID = int.Parse(msg.Body.ToString().Substring(10));
                Console.WriteLine("Query ContactID = {0} retrieved from message.",
                queryContactID);
            }

            // Retrieve data for the specified contact using a DataAdapter.
            string sqlConnectString = "Data Source=(local);" +"Integrated security=SSPI;Initial Catalog=AdventureWorks;";
            String sqlText = "SELECT * FROM Person.Contact WHERE ContactID=" + queryContactID;
            SqlDataAdapter da = new SqlDataAdapter(sqlText, sqlConnectString);
            // Fill the Customer table in the DataSet with customer data.
            DataSet ds = new DataSet();
            da.FillSchema(ds, SchemaType.Source);
            da.Fill(ds);
            Console.WriteLine("Result set created.");
            // Create an object to access the result queue for sending.
            using (MessageQueue mqResultOut = new MessageQueue(queueNameResult))
            {
                mqResultOut.Formatter =
                new XmlMessageFormatter(new Type[] { typeof(DataSet) });
                // Write the result message to the queue
                mqResultOut.Send(ds, "ContactID=" + queryContactID);
                Console.WriteLine(
                "Result message ContactID = {0} sent to result queue.",
                queryContactID);
            }
            // Create an object to access the result queue for receiving.
            DataSet dsResult;
            using (MessageQueue mqResultIn = new MessageQueue(queueNameResult))
            {
                mqResultIn.Formatter =
                new XmlMessageFormatter(new Type[] { typeof(DataSet) });
                Message msg = mqResultIn.Receive(new TimeSpan(0, 0, 1));
                Console.WriteLine("\nResult message {0} received.", msg.Id);
                // Create the customer DataSet from the message body.
                dsResult = (DataSet)msg.Body;
            }

            //Output the results to the console
            Console.WriteLine("\n---RESULT SET---");
            foreach (DataColumn col in dsResult.Tables[0].Columns)
                Console.WriteLine("{0} = {1}",
                col.ColumnName, dsResult.Tables[0].Rows[0][col.Ordinal]);
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();

        }
    }
}

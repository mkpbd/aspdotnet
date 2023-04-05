using AdoNetBasic.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    }
}

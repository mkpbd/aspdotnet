using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotnetCrud.CrudOparation
{
    public class AdoNetInsertData
    {
        public void InsertRecord()
        {
            string insterDataFromString = $@"insert into student (id, name, email, Mobile) values ('110', 'Ronald Trump', 'ronald@example.com', '1234567890')";


            // writing sql query 
            using (SqlCommand cm = new  SqlCommand(insterDataFromString, ConnectionsDB.Connection()))
            {



                // Executing the SQL query  

                cm.ExecuteNonQuery();

                // Displaying a message  
                Console.WriteLine("Record Inserted Successfully");

            }

        }



        public void AddDataInDatabaseUsingDataTable()
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
    }
}

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetBasic.Basic
{
    public class BasicCrudeOperations
    {


        public void DeleteDataFromTable()
        {
            string deleteDataById = $"delete  from ExecuteQueryNoResultSet where id = 2";

            // Create and execute a command to delete the record with
            // Id = 2 from the table ExecuteQueryNoResultSet
            SqlCommand sqlCommand = new SqlCommand(deleteDataById, DbConnections.Connection());


            int rowEffects = sqlCommand.ExecuteNonQuery();

            Console.WriteLine($"data has been delete {rowEffects}");


        }

        /*
         * Use the ExecuteReader() method of the Command object to create a  DataReader that retrieves a result set. The solution creates a Connection, Command, and DataReader that return a
         * 
         * 
         */

        public void RetrieveSingleValueFromQuery()
        {
            string sqlSelect = $"SELECT ContactID, FirstName, LastName FROM Person.Contact WHERE ContactID BETWEEN 10 AND 14";
            // Create the command and open the connection
            SqlCommand sqlCommand = new SqlCommand(sqlSelect, DbConnections.Connection());


            // Create the DataReader to retrieve data
            using (SqlDataReader dr = sqlCommand.ExecuteReader())
            {
                while (dr.Read())
                {
                    // Output fields from DataReader row
                    Console.WriteLine("Cont actID = {0}\tFirstName = {1}\tLastName = {2}",
                    dr["ContactID"], dr["LastName"], dr["FirstName"]);
                }
            }
            DbConnections.Connection().Close();

        }


        public void RetrieveValuesDataReader()
        {
            string sqlSelect = $@"SELECT ContactID, NameStyle, Title,
                                FirstName, MiddleName, LastName, Suffix, EmailAddress,
                                EmailPromotion, Phone, PasswordHash, PasswordSalt
                                FROM Person.Contact";

            // Create the command and open the connection
            SqlCommand sqlCommand = new SqlCommand(sqlSelect, DbConnections.Connection());

            // create data redear 
            SqlDataReader dr = sqlCommand.ExecuteReader();
            dr.Read();

            // Output fields from the first DataRow reader using different
            // techniques
            Console.WriteLine("ContactID = {0}", dr[0]);
            Console.WriteLine("Title = {0}", dr["Title"]);
            Console.WriteLine("FirstName = {0}", dr.IsDBNull(3) ? "NULL" : dr.GetString(3));
            Console.WriteLine("MiddleName = {0}", dr.IsDBNull(4) ? "NULL" : dr.GetSqlString(4));
            Console.WriteLine("LastName = {0}", dr.IsDBNull(5) ? "NULL" : dr.GetSqlString(5).Value);
            Console.WriteLine("EmailAddress = {0}", dr.GetValue(7));
            Console.WriteLine("EmailPromotion = {0}", int.Parse(dr["EmailPromotion"].ToString()));
            // Get the column ordinal for the Phone attribute and use it to
            // output the column
            int coPhone = dr.GetOrdinal("Phone");
            Console.WriteLine("Phone = {0}", dr[coPhone]);

            // Get the column name for the PasswordHash attribute
            // and use it to output the column
            string cnPasswordHash = dr.GetName(10);
            Console.WriteLine("PasswordHash = {0}", dr[cnPasswordHash]);
            // Create an object array and load the row into it
            object[] o = new object[dr.FieldCount];
            // Output the PasswordSalt attribute from the object array
            dr.GetValues(o);
            Console.WriteLine("PasswordSalt = {0}", o[11].ToString());
        }

        public void RetrieveDataIntoDataTable()
        {

            string sqlSelect = "SELECT TOP 5 FirstName, LastName FROM Person.Contact";

            // create DataAdapter  and open connections 

            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, DbConnections.Connection());

            // Fill a DataTable using DataAdapter and output to console
            DataTable dt = new DataTable();
            da.Fill(dt);

            Console.WriteLine("---DataTable---");
            foreach (DataRow row in dt.Rows)
                Console.WriteLine("{0} {1}", row[0], row["LastName"]);

            // Fill a DataSet using DataAdapter and output to console
            DataSet ds = new DataSet();
            da.Fill(ds, "Contact");
            Console.WriteLine("\n---DataSet; DataTable count = {0}---", ds.Tables.Count);
            Console.WriteLine("[TableName = {0}]", ds.Tables[0].TableName);
            foreach (DataRow row in ds.Tables["Contact"].Rows)
                Console.WriteLine("{0} {1}", row[0], row[1]);


        }


        public void RetrieveDataIntoDataTable2()
        {

            string sqlSelect = @"SELECT ContactID, FirstName, LastName FROM Person.Contact WHERE ContactID BETWEEN 10 AND 14";
            // Create a data adapter

            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, DbConnections.Connection());
            // Fill a DataTable using DataAdapter and output to console
            DataTable dt = new DataTable();
            da.Fill(dt);

            // Accessing rows using indexer
            Console.WriteLine("---Index loop over DataRowCollection---");
            for (int i = 0; i < 5; i++)
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine(@"Row = {0}\tContactID = {1}\tFirstName = {2} \tLastName = {3}", i, row[0], row["FirstName"], row[2, DataRowVersion.Default]);
            }



            // Accessing rows using foreach loop
            Console.WriteLine("\n---foreach loop over DataRowCollection---");
            int j = 0;
            foreach (DataRow row in dt.Rows)
            {
                j++;
                Console.WriteLine("Row = {0}\tContactID = {1}\tFirstName = {2} \tLastName = {3}", j, row[0], row["FirstName"], row["LastName", DataRowVersion.Default]);
            }


            // Accessing DataTable values directly
            Console.WriteLine("\n---Accessing FirstName value in row 3 (ContactID = 12) directly---");
            Console.WriteLine("FirstName = {0}", dt.Rows[2][1]);
            Console.WriteLine("FirstName = {0}", dt.Rows[2]["FirstName"]);
            Console.WriteLine("FirstName = {0}", dt.Rows[2]["FirstName", DataRowVersion.Default]);
            Console.WriteLine("FirstName = {0}", dt.Rows[2][dt.Columns[1]]);
            Console.WriteLine("FirstName = {0}", dt.Rows[2][dt.Columns["FirstName"]]);
            Console.WriteLine("FirstName = {0}", dt.Rows[2].Field<string>(1));
            Console.WriteLine("FirstName = {0}", dt.Rows[2].Field<string>("FirstName"));
            Console.WriteLine("FirstName = {0}", dt.Rows[2].Field<string>("FirstName", DataRowVersion.Default));
            Console.WriteLine("FirstName = {0}", dt.Rows[2].Field<string>(dt.Columns[1]));
            Console.WriteLine("FirstName = {0}", dt.Rows[2].Field<string>(dt.Columns["FirstName"]));






        }




    }
}

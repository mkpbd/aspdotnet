using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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

            Console.WriteLine( $"data has been delete {rowEffects}");


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
                    Console.WriteLine( "Cont actID = {0}\tFirstName = {1}\tLastName = {2}",
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
            Console.WriteLine("FirstName = {0}",dr.IsDBNull(3) ? "NULL" : dr.GetString(3));
            Console.WriteLine("MiddleName = {0}", dr.IsDBNull(4) ? "NULL" : dr.GetSqlString(4));
            Console.WriteLine("LastName = {0}",  dr.IsDBNull(5) ? "NULL" : dr.GetSqlString(5).Value);
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
    }
}

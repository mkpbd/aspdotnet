using System;
using System.Collections.Generic;
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
    }
}

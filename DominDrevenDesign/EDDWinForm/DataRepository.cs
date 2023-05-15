using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDDWinForm
{
    public class DataRepository
    {

        public void InsertDataInDatabase(Address address)
        {
            string ConnectionString = "data source=SERVER\\MSSQLSERVER01; database=Students; integrated security=SSPI";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try { 
                // Creating SqlCommand objcet   
                SqlCommand cm = new SqlCommand($"INSERT INTO Address (Id, Name, SecondName) VALUES('{address.Id}', '{address.Name}', '{address.SecondName}') ", con);
                con.Open();
                    int row = cm.ExecuteNonQuery();
                    Console.WriteLine("Connection Established Successfully");
                } catch(Exception ex)
                {

                }
            }
        }
    }
}

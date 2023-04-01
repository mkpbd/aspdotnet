using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotnetCrud.CrudOparation
{
    public class AdoNetDeleteRecord
    {
        public void DeleteData()
        {


            try
            {
                string delelteDataById = "delete from student where id = '101'";

                using (SqlCommand cm = new SqlCommand(delelteDataById, ConnectionsDB.Connection()))
                {

                    // Executing the SQL query  
                    cm.ExecuteNonQuery();
                    Console.WriteLine("Record Deleted Successfully");

                }


            }
            catch (Exception ex)
            {

            }

        }





        public void DataDeleteByDataTable()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from student", ConnectionsDB.Connection());
            DataTable originalDataTable = new DataTable();
            da.Fill(originalDataTable);
            Console.WriteLine("Before Deletion");
            foreach (DataRow row in originalDataTable.Rows)
            {
                Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
            }

            Console.WriteLine();
            foreach (DataRow row in originalDataTable.Rows)
            {
                if (Convert.ToInt32(row["Id"]) == 102)
                {
                    row.Delete();
                    Console.WriteLine("Row with Id 101 Deleted");
                }
            }
            originalDataTable.AcceptChanges();

            Console.WriteLine();
            Console.WriteLine("After Deletion");
            foreach (DataRow row in originalDataTable.Rows)
            {
                Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
            }

        }




        public void DataRemoveByTableData()
        {

            SqlDataAdapter da = new SqlDataAdapter("select * from student", ConnectionsDB.Connection());
            DataTable originalDataTable = new DataTable();
            da.Fill(originalDataTable);
            Console.WriteLine("Before Deletion");
            foreach (DataRow row in originalDataTable.Rows)
            {
                Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
            }
            Console.WriteLine();
            foreach (DataRow row in originalDataTable.Select())
            {
                if (Convert.ToInt32(row["Id"]) == 102)
                {
                    originalDataTable.Rows.Remove(row);
                    Console.WriteLine("Row with Id 101 Deleted");
                }
            }

            Console.WriteLine();
            Console.WriteLine("After Deletion");
            foreach (DataRow row in originalDataTable.Rows)
            {
                Console.WriteLine(row["Name"] + ",  " + row["Email"] + ",  " + row["Mobile"]);
            }
        }








    }
}


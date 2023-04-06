using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdoDotnetTutorials.Transection
{
    public class ADONETTransactions
    {

        public void SingleDatabaseTransaction()
        {
            try
            {
                Console.WriteLine("Before Transaction");
                GetAccountsData();
                //Doing the Transaction
                MoneyTransfer();
                //Verifying the Data After Transaction
                Console.WriteLine("After Transaction");

                GetAccountsData();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();
        }
        private static void MoneyTransfer()
        {
            //Store the connection string in a variable
            string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; initial catalog=BankDB; integrated security=True";

            //Creating the connection object
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                //Open the connection
                //The connection needs to be open before we begin a transaction
                connection.Open();
                // Create the transaction object by calling the BeginTransaction method on connection object
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    // Associate the first update command with the transaction
                    SqlCommand cmd = new SqlCommand("UPDATE Accounts SET Balance = Balance - 500 WHERE AccountNumber = 'Account1'", connection, transaction);
                    //Execute the First Update Command
                    cmd.ExecuteNonQuery();
                    // Associate the second update command with the transaction
                    cmd = new SqlCommand("UPDATE Accounts SET Balance = Balance + 500 WHERE AccountNumber = 'Account2'", connection, transaction);
                    //Execute the Second Update Command
                    cmd.ExecuteNonQuery();
                    // If everythinhg goes well then commit the transaction
                    transaction.Commit();
                    Console.WriteLine("Transaction Committed");
                }
                catch (Exception EX)
                {
                    // If anything goes wrong, then Rollback the transaction
                    transaction.Rollback();
                    Console.WriteLine("Transaction Rollback");
                }
            }
        }


        private static void GetAccountsData()
        {
            //Store the connection string in a variable
            string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; initial catalog=BankDB; integrated security=True";
            //Create the connection object
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Select * from Accounts", connection);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["AccountNumber"] + ",  " + sdr["CustomerName"] + ",  " + sdr["Balance"]);
                }
            }

        }
        //============= Verifying Data Consistency: ===============
        public void VerifyingDataConsistency()
        {
            try
            {
                Console.WriteLine("Before Transaction");
                GetAccountsData2();
                //Doing the Transaction
                MoneyTransfer();
                //Verifying the Data After Transaction
                Console.WriteLine("After Transaction");

                GetAccountsData2();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();
        }
        private static void MoneyTransfer2()
        {
            //Store the connection string in a variable
            string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; initial catalog=BankDB; integrated security=True";

            //Creating the connection object
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                //Open the connection
                //The connection needs to be open before we begin a transaction
                connection.Open();
                // Create the transaction object by calling the BeginTransaction method on connection object
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    // Associate the first update command with the transaction
                    SqlCommand cmd = new SqlCommand("UPDATE Accounts SET Balance = Balance - 500 WHERE AccountNumber = 'Account1'", connection, transaction);
                    //Execute the First Update Command
                    cmd.ExecuteNonQuery();
                    // Associate the second update command with the transaction
                    //MyAccounts table does not exists, so it will throw an exception
                    cmd = new SqlCommand("UPDATE MyAccounts SET Balance = Balance + 500 WHERE AccountNumber = 'Account2'", connection, transaction);
                    //Execute the Second Update Command
                    cmd.ExecuteNonQuery();
                    // If everythinhg goes well then commit the transaction
                    transaction.Commit();
                    Console.WriteLine("Transaction Committed");
                }
                catch (Exception ex)
                {
                    // If anything goes wrong, then Rollback the transaction
                    transaction.Rollback();
                    Console.WriteLine("Transaction Rollback");
                }
            }
        }
        private static void GetAccountsData2()
        {
            //Store the connection string in a variable
            string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; initial catalog=BankDB; integrated security=True";
            //Create the connection object
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("Select * from Accounts", connection);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Console.WriteLine(sdr["AccountNumber"] + ",  " + sdr["CustomerName"] + ",  " + sdr["Balance"]);
                }
            }
        }

        //====================  Example to Understand ADO.NET Distributed Transaction in C#: =================
        public void ADONETDistributedTransaction()
        {


            //Connection String Pointing to AXISBankDB
            string connStringAXIXBank = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=AXISBankDB; integrated security=TRUE";
            //Connection String Pointing to ICICIBankDB
            string connStringICICIBank = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=ICICIBankDB; integrated security=TRUE";
            //For Distributaed Transaction, we need to create an instance of TransactionScope
            //Here, we are using the using block which will dispose the transactionScope object automatically
            using (TransactionScope transactionScope = new TransactionScope())
            {
                //We need to Deduct Money from the accounts table of a user of AXIXBankDB
                //So, first connecttion object pointing to AXIXBankDB
                using (SqlConnection connectionAxisbank = new SqlConnection(connStringAXIXBank))
                {
                    //Create the command object
                    using (SqlCommand cmdAxisbank = new SqlCommand())
                    {
                        //Point the command object to execute the command in the AXIXBankDB
                        cmdAxisbank.Connection = connectionAxisbank;
                        connectionAxisbank.Open();
                        //First Update the Balance in AXIXBankDB 
                        cmdAxisbank.CommandText = "UPDATE Accounts SET Balance = Balance - 1000 WHERE AccountNumber = 1001";
                        int rowsAffectedA = cmdAxisbank.ExecuteNonQuery();
                        //Then make an entry into the TransactionDetails table in AXIXBankDB
                        cmdAxisbank.CommandText = "INSERT INTO TransactionDetails (AccountNumber, Amount, TransactionDetails, TransactionType) VALUES(1001, 1000, 'Transafer' , 'DR')";
                        int rowsAffectedB = cmdAxisbank.ExecuteNonQuery();
                        //If First two DML Operations are succeded, then only go inside and do the rest operations
                        if (rowsAffectedA > 0 && rowsAffectedB > 0)
                        {
                            Console.WriteLine("1000 deducted from Account Number: 1001 from Axis Bank");
                            //The second connection pointing to ICICIBankDB where we are going to perform the rest operations
                            using (SqlConnection connectionICICIBank = new SqlConnection(connStringICICIBank))
                            {
                                using (SqlCommand cmdICICIBank = new SqlCommand())
                                {
                                    //Point the command object to execute the command in the ICICIBankDB
                                    cmdICICIBank.Connection = connectionICICIBank;
                                    connectionICICIBank.Open();
                                    //First Update the Balance in ICICIBankDB
                                    cmdICICIBank.CommandText = "UPDATE Accounts SET Balance = Balance + 1000 WHERE AccountNumber = 50001";
                                    int rowsAffectedC = cmdICICIBank.ExecuteNonQuery();
                                    //Then make an entry into the TransactionDetails table of ICICIBankDB
                                    cmdICICIBank.CommandText = "INSERT INTO TransactionDetails (AccountNumber, Amount, TransactionDetails, TransactionType) VALUES(50001, 1000, 'Transafer', 'CR')";
                                    int rowsAffectedD = cmdICICIBank.ExecuteNonQuery();
                                    //If the above two DML operations are succeded, then call the Complete
                                    if (rowsAffectedC > 0 && rowsAffectedD > 0)
                                    {
                                        //The Complete() mark the transaction as completed successfully
                                        transactionScope.Complete();
                                        Console.WriteLine("1000 Deposited to Account Number: 50001 to ICICI Bank");
                                        Console.WriteLine("Transaction Completed");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Transaction Failed..");
                                    }
                                } // Dispose the cmdICICIBank command object.
                            } // Dispose the connectionICICIBank connection.
                        }
                        else
                        {
                            Console.WriteLine("Transaction Failed..");
                        }
                    } // Dispose the cmdAxisbank command object.
                } // Dispose connectionAxisbank connection.
            } // Dispose TransactionScope object, to commit or rollback transaction.
            Console.ReadKey();
        }


        //================ Connection Pooling Example in C# ADO.NET: ==============
        public void UnderstandConnectionPooling()
        {
            var stopwatch = new Stopwatch();
            string ConnectionString = "data source=LAPTOP-ICA2LCQL\\SQLEXPRESS; initial catalog=ADODB; integrated security=True; Pooling=true;";
            stopwatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                connection.Close();
            }
            stopwatch.Stop();
            Console.WriteLine($"Pooling=true, Time : {stopwatch.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }


        // ================== Example Without Connection Pooling in C# ADO.NET ==============
        public void WithoutConnectionPooling()
        {
            var stopwatch = new Stopwatch();
            string ConnectionString = "data source=LAPTOP-ICA2LCQL\\SQLEXPRESS; initial catalog=ADODB; integrated security=True; Pooling=false;";
            stopwatch.Start();
            for (int i = 0; i < 1000; i++)
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                connection.Close();
            }
            stopwatch.Stop();
            Console.WriteLine($"Pooling=false, Time : {stopwatch.ElapsedMilliseconds} ms");
            Console.ReadKey();
        }

        // ================== Example to understand how to Perform Bulk Insert and Update using C# ADO.NET: =================
        public void PerformBulkInserAndUpdate()
        {
            try
            {
                //Storing the connection string in a variable
                string ConnectionString = @"data source=LAPTOP-ICA2LCQL\SQLEXPRESS; database=EmployeeDB; integrated security=SSPI";
                //Creating Data Table
                DataTable EmployeeDataTable = new DataTable("Employees");
                //Add Columns to the Data Table as per the columns defined in the Table Type Parameter
                DataColumn Id = new DataColumn("Id");
                EmployeeDataTable.Columns.Add(Id);
                DataColumn Name = new DataColumn("Name");
                EmployeeDataTable.Columns.Add(Name);
                DataColumn Email = new DataColumn("Email");
                EmployeeDataTable.Columns.Add(Email);
                DataColumn Mobile = new DataColumn("Mobile");
                EmployeeDataTable.Columns.Add(Mobile);
                //Adding Multiple Rows into the DataTable
                //Follwoing Rows are going to be updated
                EmployeeDataTable.Rows.Add(101, "ABC", "ABC@dotnettutorials.net", "12345");
                EmployeeDataTable.Rows.Add(102, "PQR", "PQR@dotnettutorials.net", "11223");
                EmployeeDataTable.Rows.Add(103, "XYZ", "XYZ@dotnettutorials.net", "23432");
                //Following Rows are going to be Inserted
                EmployeeDataTable.Rows.Add(106, "A", "A@dotnettutorials.net", "12345");
                EmployeeDataTable.Rows.Add(107, "B", "B@dotnettutorials.net", "23456");
                EmployeeDataTable.Rows.Add(108, "C", "C@dotnettutorials.net", "34567");
                EmployeeDataTable.Rows.Add(109, "D", "D@dotnettutorials.net", "45678");
                EmployeeDataTable.Rows.Add(110, "E", "E@dotnettutorials.net", "56789");
                EmployeeDataTable.Rows.Add(111, "F", "F@dotnettutorials.net", "67890");
                //Creating the connection object
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //You can pass any stored procedure
                    //As I am using Higher version of SQL Server, so, I am using the Stored Procedure which uses MERGE Function
                    using (SqlCommand cmd = new SqlCommand("SP_Bulk_Insert_Update_Employees", connection))
                    {
                        //Set the command type as StoredProcedure
                        cmd.CommandType = CommandType.StoredProcedure;
                        //Add the input parameter required by the stored procedure
                        cmd.Parameters.AddWithValue("@Employees", EmployeeDataTable);
                        //Open the connection
                        connection.Open();
                        //Execute the command
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("BULK INSERT UPDATE Successful");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}


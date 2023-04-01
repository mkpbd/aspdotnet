using AdoDotnetCrud.CrudOparation;

namespace AdoDotnetCrud
{
    internal class Program
    {
        static void Main(string[] args)
        {

            AdoNetSelectStatement SelectData = new AdoNetSelectStatement();

            //SelectData.GetSelectDataFromStudent();
            //SelectData.DataSelectBySqlCommandObject();
            //SelectData.GetSelectDataRowByDataAdopter();
            //SelectData.GetDataFromSPByStoreProcedure();
            //SelectData.GetDataByDataTable();
            //SelectData.ResultByGivingDataTable();
            SelectData.GetDataByDataSet();


            AdoNetInsertData adoNetInsertData = new AdoNetInsertData();
            //adoNetInsertData.InsertRecord();
           // adoNetInsertData.AddDataInDatabaseUsingDataTable();
           // adoNetInsertData.AddDataInDatabaseUsingDataTable();


            AdoNetDeleteRecord  adoNetDeleteRecord = new AdoNetDeleteRecord();
            //adoNetDeleteRecord.DeleteData();
            //adoNetDeleteRecord.DataDeleteByDataTable();
            //adoNetDeleteRecord.DataRemoveByTableData();
            //adoNetDeleteRecord.DataRemoveByTableData();
        }
    }
}
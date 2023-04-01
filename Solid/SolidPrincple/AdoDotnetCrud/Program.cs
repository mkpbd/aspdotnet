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
            SelectData.GetSelectDataRowByDataAdopter();

            AdoNetInsertData adoNetInsertData = new AdoNetInsertData();
            //adoNetInsertData.InsertRecord();


            AdoNetDeleteRecord  adoNetDeleteRecord = new AdoNetDeleteRecord();
            //adoNetDeleteRecord.DeleteData();
        }
    }
}
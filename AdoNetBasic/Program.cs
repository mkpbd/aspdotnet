using AdoNetBasic.Basic;

namespace AdoNetBasic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BasicCrudeOperations basicCrudeOperations = new BasicCrudeOperations();

            basicCrudeOperations.DeleteDataFromTable();
        }
    }
}
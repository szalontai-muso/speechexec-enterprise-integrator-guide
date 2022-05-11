using System;
using System.Threading.Tasks;

namespace MasterDataAPITest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var masterDataConnector = new MasterDataConnector();

            Console.WriteLine("Inserting new MasterData record...");
            await masterDataConnector.InsertNewMasterDataRecordInTask();
            Console.WriteLine("Done.");

            Console.WriteLine("Querying MasterData record...");
            var result = await masterDataConnector.QueryMasterDataRecordInTask();
            Console.WriteLine("Done.");
        }
    }
}
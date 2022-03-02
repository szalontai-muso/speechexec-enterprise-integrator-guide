namespace SEEIntegratorWebApiTest;

internal class Program
{
    static void Main(string[] args)
    {
        var masterDataConnector = new MasterDataConnector();

        Console.WriteLine("Inserting new MasterData record...");
        masterDataConnector.InsertNewMasterDataRecordInTask().Wait();
        Console.WriteLine("Done.");

        Console.WriteLine("Querying MasterData record...");
        var queryTask = masterDataConnector.QueryMasterDataRecordInTask();
        queryTask.Wait();
        var result = queryTask.Result;
        Console.WriteLine("Done.");
    }
}

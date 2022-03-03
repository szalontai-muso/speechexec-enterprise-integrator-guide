namespace MobileAPITest;

internal class Program
{
    static async Task Main(string[] args)
    {
        var mobileServiceConnector = new MobileServiceConnector();

        Console.WriteLine("Uploading new dictation...");
        var statusCode = await mobileServiceConnector.UploadNewDictationInTask();
        Console.WriteLine($"Done. Status code: {(int)statusCode} ({statusCode})");

        Console.WriteLine("Querying a single dictation...");
        statusCode = await mobileServiceConnector.QuerySingleDictationInTask();
        Console.WriteLine($"Done. Status code: {(int)statusCode} ({statusCode})");

        Console.WriteLine("Querying a set of dictations...");
        statusCode = await mobileServiceConnector.QuerySetOfDictationsInTask();
        Console.WriteLine($"Done. Status code: {(int)statusCode} ({statusCode})");
    }
}

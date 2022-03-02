namespace MobileAPITest;

internal class Program
{
    static void Main(string[] args)
    {
        var mobileServiceConnector = new MobileServiceConnector();

        Console.WriteLine("Uploading new dictation...");
        var uploadDictationTask = mobileServiceConnector.UploadNewDictationInTask();
        uploadDictationTask.Wait();
        var statusCode = uploadDictationTask.Result;
        Console.WriteLine($"Done. Status code: {(int)statusCode} ({statusCode})");

        Console.WriteLine("Querying dictation...");
        var queryDictationTask = mobileServiceConnector.QueryDictationInTask();
        queryDictationTask.Wait();
        statusCode = queryDictationTask.Result;
        Console.WriteLine($"Done. Status code: {(int)statusCode} ({statusCode})");
    }
}

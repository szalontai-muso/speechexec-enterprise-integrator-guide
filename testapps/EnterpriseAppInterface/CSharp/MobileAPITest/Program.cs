using System.Net;

namespace MobileAPITest;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Enter username:");
        var userName = Console.ReadLine();
        Console.WriteLine("Enter password:");
        var password = Console.ReadLine();

        var mobileServiceConnector = new MobileServiceConnector(userName, password);
        var statusCode = HttpStatusCode.InternalServerError;

        Console.WriteLine("Uploading new dictation...");
        statusCode = await mobileServiceConnector.UploadNewDictationInTask();
        Console.WriteLine($"Done. Status code: {(int)statusCode} ({statusCode})");

        Console.WriteLine("Querying a single dictation...");
        statusCode = await mobileServiceConnector.QuerySingleDictationInTask();
        Console.WriteLine($"Done. Status code: {(int)statusCode} ({statusCode})");

        Console.WriteLine("Querying a set of dictations...");
        statusCode = await mobileServiceConnector.QuerySetOfDictationsInTask();
        Console.WriteLine($"Done. Status code: {(int)statusCode} ({statusCode})");

        Console.WriteLine("Downloading attachment of dictation...");
        statusCode = await mobileServiceConnector.DownloadAttachmentInTask();
        Console.WriteLine($"Done. Status code: {(int)statusCode} ({statusCode})");

        Console.WriteLine("Querying user settings...");
        statusCode = await mobileServiceConnector.QueryUserSettingsInTask();
        Console.WriteLine($"Done. Status code: {(int)statusCode} ({statusCode})");
    }
}

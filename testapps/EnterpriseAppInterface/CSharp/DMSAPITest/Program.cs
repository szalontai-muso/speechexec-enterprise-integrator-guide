using System;
using System.Net;
using System.Linq;
using System.Threading.Tasks;

namespace DMSAPITest
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var dmsConnector = new DMSConnector();
            var statusCode = HttpStatusCode.InternalServerError;

            Console.WriteLine("Querying user settings...");
            var queryUsersResult = await dmsConnector.QueryUsersInTask();
            statusCode = queryUsersResult.Item1;
            Console.WriteLine($"Done. Status code: {(int)statusCode} ({statusCode})");

            var user = queryUsersResult.Item2?.First().username;

            Console.WriteLine($"Querying all dictations for user '{user}'...");
            statusCode = await dmsConnector.QueryDictationsForUserInTask(user);
            Console.WriteLine($"Done. Status code: {(int)statusCode} ({statusCode})");

            Console.WriteLine($"Querying all dictations of all users...");
            statusCode = await dmsConnector.QueryDictationsForAllUsersInTask();
            Console.WriteLine($"Done. Status code: {(int)statusCode} ({statusCode})");

            Console.WriteLine($"Downloading attachment of dictation for user '{user}'...");
            statusCode = await dmsConnector.DownloadAttachmentInTask(user);
            Console.WriteLine($"Done. Status code: {(int)statusCode} ({statusCode})");
        }
    }
}
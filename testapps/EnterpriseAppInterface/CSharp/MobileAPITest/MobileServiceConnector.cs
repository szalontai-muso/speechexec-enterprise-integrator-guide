using MobileAPITest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MobileAPITest;

internal class MobileServiceConnector
{
    // Url of the SpeechExec Enterprise App Interface service
    private static string SEEAppInterfaceServiceUrl = "http://localhost/";

    private static string TestDictationFilePath = @"c:\Users\joco\Documents\speechexec\a_finish\adam0004.wav";
    private static string TestDictationID = Guid.NewGuid().ToString();

    private static HttpClient _AppInterfaceHttpClient;

    public MobileServiceConnector()
    {
        _AppInterfaceHttpClient = new HttpClient();

        Console.WriteLine("Requesting OAuth token...");
        var tokenQueryTask = QueryOAuthTokenInTask();
        tokenQueryTask.Wait();
        var oauthToken = tokenQueryTask.Result;
        Console.WriteLine("Done.");

        // Set the Bearer token in the Authorization header for OAUTH authentication
        _AppInterfaceHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", oauthToken);
    }

    public async Task<HttpStatusCode> UploadNewDictationInTask()
    {
        // Attach the POST /app/dictations REST endpoint to the root url
        var uploadDictationPostEndPointUri = new Uri(new Uri(SEEAppInterfaceServiceUrl), "/SEEAppInterface/app/dictations");

        // Read a test dictation file contents into memory
        await using var stream = File.OpenRead(TestDictationFilePath);
        var streamContent = new StreamContent(stream);
        streamContent.Headers.ContentType = new MediaTypeHeaderValue(MediaTypeNames.Application.Octet);
        // Create a multipart form with file content and metadata
        using var content = new MultipartFormDataContent
        {
            // file
            { streamContent, "see_dictation_audio_file", Path.GetFileName(TestDictationFilePath) },

            // payload
            { new StringContent(TestDictationID), "DictationId" },
            { new StringContent("2"), "Status" },
            { new StringContent("0"), "Priority" },
            { new StringContent("Memo"), "Worktype" },
            { new StringContent("2021-09-24T13:50:40.000"), "CreationDateTime" },
            { new StringContent("Test dictation"), "Title" },
            { new StringContent("test_cat"), "Category" },
            { new StringContent("test_comm"), "Comments" },
            { new StringContent("test_dep"), "Department" },
            { new StringContent("test_kw"), "Keyword" },
            { new StringContent("test_bc"), "DPMBarcode" },
            { new StringContent("test_cust1"), "Custom1" },
            { new StringContent("test_cust2"), "Custom2" },
            { new StringContent("test_cust3"), "Custom3" },
            { new StringContent("test_cust4"), "Custom4" },
            { new StringContent("test_cust5"), "Custom5" },
        };

        // Call the POST /app/dictations endpoint with the predefined json request
        var response = await _AppInterfaceHttpClient.PostAsync(uploadDictationPostEndPointUri, content);
        return response.StatusCode;
    }

    public async Task<HttpStatusCode> QueryDictationInTask()
    {
        // Attach the GET /app/dictations REST endpoint to the root url, including the dictation ID we're looking for
        var masterDataPostEndPointUri = new Uri(new Uri(SEEAppInterfaceServiceUrl), $"/SEEAppInterface/app/dictations/{TestDictationID}");

        // Call the GET /app/dictations endpoint
        var response = await _AppInterfaceHttpClient.GetAsync(masterDataPostEndPointUri);
        response.EnsureSuccessStatusCode();

        // Deserialize json response
        using (var responseStream = await response.Content.ReadAsStreamAsync())
        {
            using (StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8))
            {
                var result = await streamReader.ReadToEndAsync();
                var dict = JsonSerializer.Deserialize<GetDictationsResponse>(result);
            }
        }
   
        return response.StatusCode;
    }

    private async Task<string> QueryOAuthTokenInTask()
    {
        // Attach the POST /app/token REST endpoint to the root url
        var queryTokenPostEndPointUri = new Uri(new Uri(SEEAppInterfaceServiceUrl), "/SEEAppInterface/app/token");

        // Create an url-encoded form request object
        var contentParams = new Dictionary<string, string>();
        contentParams.Add("grant_type", "password");
        contentParams.Add("username", "seagile1");
        contentParams.Add("password", "JUzer12");
        var content = new FormUrlEncodedContent(contentParams);

        // Call the POST /app/token endpoint with the url-encoded form data
        var response = await _AppInterfaceHttpClient.PostAsync(queryTokenPostEndPointUri, content);
        response.EnsureSuccessStatusCode();

        // Deserialize json response to return the OATH token
        using (var responseStream = await response.Content.ReadAsStreamAsync())
        {
            using (StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8))
            {
                var result = await streamReader.ReadToEndAsync();
                var tokenResponse = JsonSerializer.Deserialize<OAuthTokenResponse>(result);
                return tokenResponse?.access_token;
            }
        }
    }
}

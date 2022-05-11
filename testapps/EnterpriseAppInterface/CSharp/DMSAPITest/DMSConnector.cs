using DMSAPITest.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DMSAPITest
{
    internal class DMSConnector
    {
        // Url of the SpeechExec Enterprise App Interface service
        private static string SEEAppInterfaceServiceUrl = "http://localhost/";

        private static Guid? _TestDictationID;

        private static HttpClient _AppInterfaceHttpClient = new HttpClient();

        public DMSConnector()
        {
            // Set the API key in the request header for authentication
            // Important: use your own API key as the 2nd parameter!
            _AppInterfaceHttpClient.DefaultRequestHeaders.Add("x-sps-api-key", "AdminApiKey_TestGroup_678e1f10-53b0-4b8d-af36-7067b52466ea");
        }

        public async Task<Tuple<HttpStatusCode, UserData[]?>> QueryUsersInTask()
        {
            // Concatenate the GET /dms/users REST endpoint to the root url
            var queryUsersGetEndPointUri = new Uri(new Uri(SEEAppInterfaceServiceUrl), $"/SEEAppInterface/dms/users");

            // Call the GET /dms/users endpoint
            var response = await _AppInterfaceHttpClient.GetAsync(queryUsersGetEndPointUri);

            UsersResponse? users = null;

            // Deserialize json response
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                using (StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    var result = await streamReader.ReadToEndAsync();
                    users = JsonSerializer.Deserialize<UsersResponse>(result);
                    // the requested users list is found in the users JSON object
                }
            }

            return new Tuple<HttpStatusCode, UserData[]?>(response.StatusCode, users?.users);
        }

        public async Task<HttpStatusCode> QueryDictationsForUserInTask(string? userName)
        {
            // Concatenate the GET /dms/dictations/{AuthorName} REST endpoint to the root url
            var queryDictationsGetEndPointUri = new Uri(new Uri(SEEAppInterfaceServiceUrl), $"/SEEAppInterface/dms/dictations/{userName}");

            // Call the GET /dms/dictations/{AuthorName} endpoint
            var response = await _AppInterfaceHttpClient.GetAsync(queryDictationsGetEndPointUri);

            // Deserialize json response
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                using (StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    var result = await streamReader.ReadToEndAsync();
                    var dict = JsonSerializer.Deserialize<GetDMSDictationsResponse>(result);
                    // the requested dictation metadatas are found in dict.data[0].files array
                }
            }

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> QueryDictationsForAllUsersInTask()
        {
            // Concatenate the GET /dms/dictations REST endpoint to the root url
            var queryDictationsGetEndPointUri = new Uri(new Uri(SEEAppInterfaceServiceUrl), "/SEEAppInterface/dms/dictations");

            // Call the GET /dms/dictations endpoint
            var response = await _AppInterfaceHttpClient.GetAsync(queryDictationsGetEndPointUri);

            // Deserialize json response
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                using (StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    var result = await streamReader.ReadToEndAsync();
                    var dict = JsonSerializer.Deserialize<GetDMSDictationsResponse>(result);
                    // the requested dictation metadatas are found in dict.data array

                    _TestDictationID = dict?.data?.FirstOrDefault()?.files?.FirstOrDefault(f => f.HasAttachment)?.DictationID;
                }
            }

            return response.StatusCode;
        }

        public async Task<HttpStatusCode> DownloadAttachmentInTask(string? userName)
        {
            // Concatenate the GET /dms/dictations/{AuthorName}/{DictationID}/attachment REST endpoint to the root url, including the dictation ID we're looking for
            var downloadDictationGetEndPointUri = new Uri(new Uri(SEEAppInterfaceServiceUrl), $"/SEEAppInterface/app/dictations/{userName}/{_TestDictationID}/attachment");

            // Call the GET /app/dictations endpoint
            var response = await _AppInterfaceHttpClient.GetAsync(downloadDictationGetEndPointUri);

            // Read result stream content
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                using (StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    var result = await streamReader.ReadToEndAsync();
                    // the result contains the attachment's file content
                }
            }

            return response.StatusCode;
        }
    }
}
using MasterDataAPITest.Data;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MasterDataAPITest
{
    internal class MasterDataConnector
    {
        // Url of the SpeechExec Enterprise App Interface service
        private static string SEEAppInterfaceServiceUrl = "http://localhost/";
        // Url of the SpeechExec Enterprise Configuration service
        private static string SEEConfigServiceUrl = "http://localhost/";

        private static string MasterDataRecordID = "SPS_test_ID";

        private static HttpClient _AppInterfaceHttpClient = new HttpClient();
        // Create an http client handler where we specify to use Windows Authentication
        private static HttpClient _ConfigServiceHttpClient = new HttpClient(new HttpClientHandler { UseDefaultCredentials = true });

        public MasterDataConnector()
        {
            // Set the API key in the request header for authentication
            // Important: use your own API key as the 2nd parameter!
            _AppInterfaceHttpClient.DefaultRequestHeaders.Add("x-sps-api-key", "AdminApiKey_TestGroup_678e1f10-53b0-4b8d-af36-7067b52466ea");
        }

        // Insert a new, hard-defined MasterData record to the SEEMASTERDATA SQL DB
        public async Task InsertNewMasterDataRecordInTask()
        {
            // Concatenate the POST /masterdata/dataitems REST endpoint to the root url
            var masterDataPostEndPointUri = new Uri(new Uri(SEEAppInterfaceServiceUrl), "/SEEAppInterface/masterdata/dataitems");
            // Create an 'InsertMasterDataRequest' json request object
            var request = CreateTestMasterDataRecord();

            // Call the POST /masterdata/dataitems endpoint with the predefined json request
            var response = await _AppInterfaceHttpClient.PostAsJsonAsync(masterDataPostEndPointUri, request);

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                // Deserialize json error response
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    using (StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        var result = await streamReader.ReadToEndAsync();
                        var errorResponse = JsonSerializer.Deserialize<GenericErrorResponse>(result);
                    }
                }
            }
        }

        // Query MasterData record by ID from the SEEMASTERDATA SQL DB
        public async Task<QueryMasterDataResponse?> QueryMasterDataRecordInTask()
        {
            // Concatenate the GET /masterdata/dataitems REST endpoint to the root url, including the MasterData record's ID we're looking for
            var masterDataPostEndPointUri = new Uri(new Uri(SEEConfigServiceUrl), $"/SEEConfigServiceForIIS/masterdata/dataitems/{MasterDataRecordID}");

            // Call the GET /masterdata/dataitems endpoint
            var response = await _ConfigServiceHttpClient.GetAsync(masterDataPostEndPointUri);
            response.EnsureSuccessStatusCode();

            // Deserialize json response
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                using (StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    var result = await streamReader.ReadToEndAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        Converters = { new JsonStringEnumConverter() },
                    };
                    return JsonSerializer.Deserialize<QueryMasterDataResponse>(result, options);
                }
            }
        }

        private static InsertMasterDataRequest CreateTestMasterDataRecord()
        {
            return new InsertMasterDataRequest
            {
                CRI = Guid.NewGuid(),
                dataitem = new MasterDataItem
                {
                    ID = MasterDataRecordID,
                    Label01 = "data01",
                    Label02 = "data02",
                    Label03 = "data03",
                    Label04 = "data04",
                    Label05 = "data05",
                    Label06 = "data06",
                    Label07 = "data07",
                    Label08 = "data08",
                    Label09 = "data09",
                    Int01 = 1,
                    Int02 = 2,
                    Int03 = 3,
                    Int04 = 4,
                    Int05 = 5,
                    Datetime01 = "2021-11-04 15:35:30",
                    Datetime02 = "2019-03-16 11:24:49",
                    Datetime03 = "2000-01-01 06:11:17",
                    Datetime04 = "1995-05-31 17:58:03",
                    Datetime05 = "1776-07-04 01:11:09"
                }
            };
        }
    }
}
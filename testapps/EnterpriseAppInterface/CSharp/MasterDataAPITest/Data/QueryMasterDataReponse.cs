using System.Text.Json.Serialization;

namespace MasterDataAPITest.Data;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MasterDataQueryStatus
{
    OK,
    ERROR_NoDataFoundForID,
    ERROR_MultipleDataFoundForID,
    ERROR_DatabaseNotAvailable,
    ERROR_DataNotReadable,
    ERROR_IDIsEmpty,
}

public class QueryMasterDataResponse
{
    public MasterDataQueryStatus Status { get; set; }
    public string AdditionalInformation { get; set; }
    public MasterDataRecord Data { get; set; }
    public string IncidentNumber { get; set; }

    public QueryMasterDataResponse()
    {
    }

    public QueryMasterDataResponse(MasterDataQueryStatus status, MasterDataRecord data = null, string additionalInfo = "")
    {
        Status = status;
        Data = data;
        AdditionalInformation = additionalInfo;
        IncidentNumber = "";
    }
}

public class MasterDataRecord
{
    public string ID { get; set; }
    public string Label01 { get; set; }
    public string Label02 { get; set; }
    public string Label03 { get; set; }
    public string Label04 { get; set; }
    public string Label05 { get; set; }
    public string Label06 { get; set; }
    public string Label07 { get; set; }
    public string Label08 { get; set; }
    public string Label09 { get; set; }
    public int? Int01 { get; set; }
    public int? Int02 { get; set; }
    public int? Int03 { get; set; }
    public int? Int04 { get; set; }
    public int? Int05 { get; set; }
    public DateTime? Datetime01 { get; set; }
    public DateTime? Datetime02 { get; set; }
    public DateTime? Datetime03 { get; set; }
    public DateTime? Datetime04 { get; set; }
    public DateTime? Datetime05 { get; set; }
}
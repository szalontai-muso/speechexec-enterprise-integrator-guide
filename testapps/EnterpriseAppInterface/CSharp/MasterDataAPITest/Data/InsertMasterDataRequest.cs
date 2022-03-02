namespace MasterDataAPITest.Data;

public class InsertMasterDataRequest
{
    public Guid CRI { get; set; }
    public MasterDataItem dataitem { get; set; }
}

public class MasterDataItem
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
    public string Datetime01 { get; set; }
    public string Datetime02 { get; set; }
    public string Datetime03 { get; set; }
    public string Datetime04 { get; set; }
    public string Datetime05 { get; set; }
}
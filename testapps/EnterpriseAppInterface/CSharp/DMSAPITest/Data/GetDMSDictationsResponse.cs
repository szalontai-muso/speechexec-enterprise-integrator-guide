using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSAPITest.Data;

internal class GetDMSDictationsResponse
{
	public Guid CRI { get; set; }
	public GetDMSDictationsData[]? data { get; set; }
}

public class GetDMSDictationsData : GetDictationsData
{
	public string user { get; set; } = "";
	public int role { get; set; }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAPITest.Data;

internal class GetDictationsResponse
{
	public Guid CRI { get; set; }
	public GetDictationsData[] data { get; set; }
}

internal class GetDictationsData
{
	public GetDictationsCacheItem[] files { get; set; }
}

internal class GetDictationsCacheItem
{
	public Guid DictationID { get; set; }
	public string AudioFileName { get; set; }
	public int DictationState { get; set; }
	public bool HasAttachment { get; set; }
	public bool IsArchive { get; set; }
	public string SubfolderHierarchy { get; set; }
	public DateTime LastChangedDateTimeUtc { get; set; }
}

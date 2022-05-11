using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data
{
	public class GetDictationsCacheItem
	{
		public Guid DictationID { get; set; }
		public string AudioFileName { get; set; } = "";
		public int DictationState { get; set; }
		public bool HasAttachment { get; set; }
		public bool IsArchive { get; set; }
		public string SubfolderHierarchy { get; set; } = "";
		public DateTime LastChangedDateTimeUtc { get; set; }
	}
}
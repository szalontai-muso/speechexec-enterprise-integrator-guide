using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAPITest.Data;

internal class GetDictationInfoListRequest
{
	public Guid CRI { get; set; }
	public string[]? dictationIds { get; set; }
}

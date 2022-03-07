using Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAPITest.Data;

internal class GetDictationsResponse
{
	public Guid CRI { get; set; }
	public GetDictationsData[]? data { get; set; }
}

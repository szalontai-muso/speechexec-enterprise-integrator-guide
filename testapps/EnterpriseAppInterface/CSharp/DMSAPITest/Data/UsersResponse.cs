using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSAPITest.Data;

internal class UsersResponse
{
	public Guid CRI { get; set; }
	public UserData[]? users { get; set; }
}

public class UserData
{
	public string username { get; set; } = "";
}

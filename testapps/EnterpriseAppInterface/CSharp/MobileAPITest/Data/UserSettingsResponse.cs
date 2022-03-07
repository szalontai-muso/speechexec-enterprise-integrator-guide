using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAPITest.Data;

internal class UserSettingsResponse
{
	public bool IsNdevSrEnabled { get; set; }
	public string PreferredNdevLanguageCodes { get; set; } = "";
	public string SupportedNdevLanguageCodes { get; set; } = "";
	public bool IsTranscriptionServiceEnabled { get; set; }
	public bool IsMultiSpeakerTranscriptionEnabled { get; set; }
}

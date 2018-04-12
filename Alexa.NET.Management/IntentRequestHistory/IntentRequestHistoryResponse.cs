using Newtonsoft.Json;

namespace Alexa.NET.Management.IntentRequestHistory
{
	public class IntentRequestHistoryResponse{
		[JsonProperty("body")]
		public IntentRequestHistoryResponseBody Body { get; set; }
	}
}

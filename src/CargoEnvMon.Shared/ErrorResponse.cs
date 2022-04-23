using Newtonsoft.Json;

namespace CargoEnvMon.Shared
{
    public class ErrorResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
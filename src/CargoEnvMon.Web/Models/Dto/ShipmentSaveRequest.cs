using Newtonsoft.Json;

namespace CargoEnvMon.Web.Models.Dto;

public class ShipmentSaveRequest
{
    [JsonProperty("title")]
    public string Title { get; init; }
    
    [JsonProperty("code")]
    public string Code { get; init; }
}
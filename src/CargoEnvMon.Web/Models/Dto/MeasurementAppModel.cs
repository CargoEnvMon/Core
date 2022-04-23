using Newtonsoft.Json;

namespace CargoEnvMon.Web.Models.Dto;

public class MeasurementAppModel
{
    [JsonProperty("date")]
    public string Date { get; init; }
    
    [JsonProperty("time")]
    public string Time { get; init; }
    
    [JsonProperty("temperature")]
    public float? Temperature { get; init; }
}
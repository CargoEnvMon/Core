using Newtonsoft.Json;

namespace CargoEnvMon.Web.Models.Dto;

public class MeasurementAppModel
{
    [JsonProperty("created")]
    public string Created { get; init; }
    
    [JsonProperty("temperature")]
    public float? Temperature { get; init; }
}
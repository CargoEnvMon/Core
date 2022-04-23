using Newtonsoft.Json;

namespace CargoEnvMon.Web.Models.Dto;

public class CargoAppModel
{
    [JsonProperty("measurements")]
    public IReadOnlyList<MeasurementAppModel> Measurements { get; init; }
}
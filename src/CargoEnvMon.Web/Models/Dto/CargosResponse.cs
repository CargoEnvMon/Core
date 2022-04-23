using Newtonsoft.Json;

namespace CargoEnvMon.Web.Models.Dto;

public class CargosResponse
{
    [JsonProperty("items")]
    public IReadOnlyList<CargoItemAppModel> Items { get; init; }
}
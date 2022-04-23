using Newtonsoft.Json;

namespace CargoEnvMon.Web.Models.Dto;

public class ShipmentsResponse
{
    [JsonProperty("items")]
    public IReadOnlyList<ShipmentAppModel> Items { get; init; }
}
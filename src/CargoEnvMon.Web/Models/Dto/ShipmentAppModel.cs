using Newtonsoft.Json;

namespace CargoEnvMon.Web.Models.Dto;

public class ShipmentAppModel
{
    [JsonProperty("shipmentId")]
    public int ShipmentId { get; init; }
    
    [JsonProperty("code")]
    public string Code { get; init; }
    
    [JsonProperty("title")]
    public string Title { get; init; }
}
using Newtonsoft.Json;

namespace CargoEnvMon.Web.Models.Dto;

public class CargoItemAppModel
{
    [JsonProperty("cargoId")]
    public int CargoId { get; init; }
    
    [JsonProperty("code")]
    public string Code { get; init; }
    
    [JsonProperty("title")]
    public string Title { get; init; }
}
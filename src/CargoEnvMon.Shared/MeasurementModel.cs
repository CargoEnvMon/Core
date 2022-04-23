using Newtonsoft.Json;

namespace CargoEnvMon.Shared
{
    public class MeasurementModel
    {
        [JsonProperty("temperature")]
        public float? Temperature { get; set; }
        
        [JsonProperty("humidity")]
        public float? Humidity { get; set; }
        
        [JsonProperty("timeShift")]
        public long? TimeShift { get; set; }
    }
}
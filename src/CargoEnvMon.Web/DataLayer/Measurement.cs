namespace CargoEnvMon.Web.DataLayer;

public class Measurement
{
    public int MeasurementId { get; init; }
    
    public DateTime Created { get; init; }
    
    public float? Temperature { get; init; }
    
    public int CargoId { get; init; }
    
    public Cargo Cargo { get; init; } = null!;
}
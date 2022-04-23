using System.ComponentModel.DataAnnotations;

namespace CargoEnvMon.Web.DataLayer;

public class Cargo
{
    public int CargoId { get; init; }
    
    [Required]
    public string Code { get; init; } = null!;

    [Required]
    public string Title { get; init; } = null!;

    public int ShipmentId { get; init; }
    
    public Shipment Shipment { get; init; } = null!;
    
    public ICollection<Measurement> Measurements { get; init; } = null!;
}
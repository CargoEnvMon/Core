using System.ComponentModel.DataAnnotations;

namespace CargoEnvMon.Web.DataLayer;

public class Shipment
{
    public int ShipmentId { get; init; }
    
    [Required]
    public string Code { get; init; } = null!;

    [Required]
    public string Title { get; init; } = null!;
    
    public ICollection<Cargo> Cargos { get; init; } = null!;
}
using CargoEnvMon.Web.DataLayer;
using CargoEnvMon.Web.Models.Dto;

namespace CargoEnvMon.Web.Models.Handlers;

public class SaveShipmentRequestHandler
{
    private readonly CargoEnvMonDbContext dbContext;

    public SaveShipmentRequestHandler(CargoEnvMonDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Handle(ShipmentSaveRequest request)
    {
        var shipment = new Shipment
        {
            Code = request.Code,
            Title = request.Title
        };
        dbContext.Shipments.Add(shipment);
        dbContext.SaveChanges();
    }
}
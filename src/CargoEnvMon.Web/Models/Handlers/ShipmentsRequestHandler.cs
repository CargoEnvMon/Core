using CargoEnvMon.Web.DataLayer;
using CargoEnvMon.Web.Models.Dto;

namespace CargoEnvMon.Web.Models.Handlers;

public class ShipmentsRequestHandler
{
    private readonly CargoEnvMonDbContext dbContext;

    public ShipmentsRequestHandler(CargoEnvMonDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public ShipmentsResponse Handle()
    {
        return new ShipmentsResponse
        {
            Items = dbContext.Shipments
                .Select(e => new ShipmentAppModel
                {
                    Code = e.Code,
                    Title = e.Title,
                    ShipmentId = e.ShipmentId
                })
                .ToArray() 
        };
    }
}
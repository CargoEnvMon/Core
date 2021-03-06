using CargoEnvMon.Web.DataLayer;
using CargoEnvMon.Web.Models.Dto;

namespace CargoEnvMon.Web.Models.Handlers;

public class CargosRequestHandler
{
    private readonly CargoEnvMonDbContext dbContext;

    public CargosRequestHandler(CargoEnvMonDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public CargosResponse Handle(int shipmentId)
    {
        return new CargosResponse
        {
            Items = dbContext.Cargos
                .Where(e => e.ShipmentId == shipmentId)
                .Select(e => new CargoItemAppModel
            {
                Code = e.Code,
                Title = e.Title,
                CargoId = e.CargoId
            }).ToArray() 
        };
    }
}
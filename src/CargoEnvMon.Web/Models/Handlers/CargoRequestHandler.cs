using CargoEnvMon.Web.DataLayer;
using CargoEnvMon.Web.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace CargoEnvMon.Web.Models.Handlers;

public class CargoRequestHandler
{
    private readonly CargoEnvMonDbContext dbContext;

    public CargoRequestHandler(CargoEnvMonDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public CargoAppModel Handle(int id)
    {
        var cargo = dbContext.Cargos
            .AsNoTracking()
            .Include(e => e.Measurements)
            .FirstOrDefault(e => e.CargoId == id);
        
        return new CargoAppModel
        {
            Measurements = cargo!.Measurements.Select(ToAppModel).ToArray()
        };
    }

    private static MeasurementAppModel ToAppModel(Measurement measurement)
    {
        return new MeasurementAppModel
        {
            Temperature = measurement.Temperature,
            Created = measurement.Created.ToString("g"),
        };
    }
}
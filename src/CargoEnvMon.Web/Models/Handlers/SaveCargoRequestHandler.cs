using CargoEnvMon.Shared;
using CargoEnvMon.Web.DataLayer;

namespace CargoEnvMon.Web.Models.Handlers;

public class SaveCargoRequestHandler
{
    private readonly CargoEnvMonDbContext dbContext;

    public SaveCargoRequestHandler(CargoEnvMonDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public ErrorResponse? Handle(SaveCargoRequest request)
    {
        var cargo = dbContext.Cargos
            .Where(e => e.Shipment.Code == request.ShipmentId)
            .FirstOrDefault(e => e.Code == request.CargoId);

        if (cargo == null)
        {
            return new ErrorResponse
            {
                Message = $"Cargo with #{request.CargoId} not found"
            };
        }

        var items = GetMeasurements(request).ToArray();
        foreach (var measurement in items)
        {
            cargo.Measurements.Add(measurement);
        }

        dbContext.SaveChanges();

        return null;
    }

    private static IEnumerable<Measurement> GetMeasurements(SaveCargoRequest request)
    {
        var start = DateTimeOffset.FromUnixTimeMilliseconds(int.Parse(request.StartTimestamp));
        Func<double, TimeSpan> shiftToTimespan = request.TimeShiftUnits switch
        {
            1 => TimeSpan.FromMilliseconds,
            2 => TimeSpan.FromSeconds,
            3 => TimeSpan.FromMinutes,
            4 => TimeSpan.FromHours,
            _ => TimeSpan.FromSeconds
        };
        foreach (var measurement in request.Items)
        {
            yield return new Measurement
            {
                Temperature = measurement.Temperature,
                Created = (start + shiftToTimespan(measurement.TimeShift!.Value)).UtcDateTime,
            };
        }
    }
}
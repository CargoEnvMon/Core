using CargoEnvMon.Web.Models.Dto;
using CargoEnvMon.Web.Models.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CargoEnvMon.Web.Controllers;

[ApiController]
[Route("api/mon")]
public class MonController : Controller
{
    private readonly ShipmentsRequestHandler shipmentsRequestHandler;
    private readonly CargosRequestHandler cargosRequestHandler;
    private readonly CargoRequestHandler cargoRequestHandler;

    public MonController(
        ShipmentsRequestHandler shipmentsRequestHandler,
        CargosRequestHandler cargosRequestHandler, CargoRequestHandler cargoRequestHandler)
    {
        this.shipmentsRequestHandler = shipmentsRequestHandler;
        this.cargosRequestHandler = cargosRequestHandler;
        this.cargoRequestHandler = cargoRequestHandler;
    }

    [HttpGet, Route("shipments")]
    public ShipmentsResponse GetShipments() => shipmentsRequestHandler.Handle();

    [HttpGet, Route("shipment/{id:int}/cargos")]
    public CargosResponse GetCargos(int id) => cargosRequestHandler.Handle(id);

    [HttpGet, Route("cargo/{id:int}")]
    public CargoAppModel GetCargo(int id) => cargoRequestHandler.Handle(id);
}
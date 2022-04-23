using CargoEnvMon.Web.Models.Dto;
using CargoEnvMon.Web.Models.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CargoEnvMon.Web.Controllers;

[ApiController]
[Route("/api/mon")]
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

    [Route("shipments")]
    public ShipmentsResponse GetShipments() => shipmentsRequestHandler.Handle();

    [Route("cargos")]
    public CargosResponse GetCargos() => cargosRequestHandler.Handle();

    [Route("cargo/{id:int}")]
    public CargoAppModel GetCargo(int id) => cargoRequestHandler.Handle(id);
}
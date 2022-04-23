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

    public MonController(
        ShipmentsRequestHandler shipmentsRequestHandler,
        CargosRequestHandler cargosRequestHandler
    )
    {
        this.shipmentsRequestHandler = shipmentsRequestHandler;
        this.cargosRequestHandler = cargosRequestHandler;
    }

    [Route("shipments")]
    public ShipmentsResponse GetShipments() => shipmentsRequestHandler.Handle();

    [Route("cargos")]
    public CargosResponse GetCargos() => cargosRequestHandler.Handle();
}
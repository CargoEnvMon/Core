using CargoEnvMon.Shared;
using CargoEnvMon.Web.Models.Dto;
using CargoEnvMon.Web.Models.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CargoEnvMon.Web.Controllers;

[ApiController]
[Route("/api/save")]
public class SaveController : Controller
{
    private readonly SaveCargoRequestHandler saveCargoRequestHandler;
    private readonly SaveShipmentRequestHandler saveShipmentRequestHandler;

    public SaveController(SaveCargoRequestHandler saveCargoRequestHandler, SaveShipmentRequestHandler saveShipmentRequestHandler)
    {
        this.saveCargoRequestHandler = saveCargoRequestHandler;
        this.saveShipmentRequestHandler = saveShipmentRequestHandler;
    }

    [Route("cargo")]
    public ActionResult SaveCargo([FromBody] SaveCargoRequest request)
    {
        var result = saveCargoRequestHandler.Handle(request);
        if (result != null)
        {
            return Json(result);
        }

        return Ok();
    }

    [Route("shipment")]
    public ActionResult SaveShipment([FromBody] ShipmentSaveRequest request)
    {
        saveShipmentRequestHandler.Handle(request);
        return Ok();
    }
}
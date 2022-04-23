using CargoEnvMon.Shared;
using CargoEnvMon.Web.Models.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace CargoEnvMon.Web.Controllers;

[ApiController]
[Route("/api/save")]
public class SaveController : Controller
{
    private readonly SaveCargoRequestHandler saveCargoRequestHandler;

    public SaveController(SaveCargoRequestHandler saveCargoRequestHandler)
    {
        this.saveCargoRequestHandler = saveCargoRequestHandler;
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
    
    
}
using System.Net;
using Microsoft.AspNetCore.Mvc;
using WarehouseWebApp.Models;
using WarehouseWebApp.Services;

namespace WarehouseWebApp.Controllers;

[Route("api/[controller]/fulfill")]
[ApiController]
public class WarehouseController: ControllerBase
{
    private IWarehouseService _service;

    public WarehouseController(IWarehouseService warehouseService)
    {
        _service = warehouseService;
    }

    /// <summary>
    /// Endpoint used to fulfill an order an animal.
    /// </summary>
    /// <param name="productWarehouse">ProductWarehouse data</param>
    /// <returns>201 Created</returns>
    [HttpPost]
    public IActionResult Fulfill(FulfilledOrder fulfilledOrder)
    {
        try
        {
            var id = _service.Fulfill(fulfilledOrder);
            return Created("", id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    /// <summary>
    /// Endpoint used to fulfill an order an animal with a transaction.
    /// </summary>
    /// <param name="productWarehouse">ProductWarehouse data</param>
    /// <returns>200 Ok</returns>
    [HttpPut]

    public IActionResult FulfillSQL(FulfilledOrder fulfilledOrder)
    {
        try
        {
            var id = _service.FulfillWithProcedure(fulfilledOrder);
            return Ok(id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
namespace ShizukaSushi.Controllers;

using Microsoft.AspNetCore.Mvc;
using ShizukaSushi.Contracts.Dishes;

[ApiController]
public class DishesController : ControllerBase
{
    [HttpPost("/dishes")]
    public IActionResult CreateDish(CreateDishRequest request)
    {
        return Ok(request);
    }

    [HttpGet("/dishes/{id:guid}")]
    public IActionResult GetDish(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("/dishes/{id:guid}")]
    public IActionResult UpdateDish(Guid id, UpdateDishRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("/dishes/{id:guid}")]
    public IActionResult DeleteDish(Guid id)
    {
        return Ok(id);
    }
}
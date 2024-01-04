namespace ShizukaSushi.Controllers;

using Microsoft.AspNetCore.Mvc;
using ShizukaSushi.Contracts.Dishes;
using ShizukaSushi.DatabaseContext;
using ShizukaSushi.Models;


[ApiController]
public class DishesController : ControllerBase
{
    private readonly ShizukaDbContext _context;



    public DishesController(ShizukaDbContext context)
    {
        _context = context;
    }



    [HttpPost("/dishes")]
    public IActionResult CreateDish(CreateDishRequest request)
    {
        Dish d = new Dish(Guid.NewGuid(), request.Name, request.Description, DateTime.UtcNow, request.Ingredients);
        _context.Dishes.Add(d);
        _context.SaveChanges();
        return Ok(request);
    }

    [HttpGet("/dishes/{id:guid}")]
    public IActionResult GetDish(Guid id)
    {
        Dish? d = _context.Dishes.Where(x => x.Id.Equals(id)).FirstOrDefault();
        return Ok(d);
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
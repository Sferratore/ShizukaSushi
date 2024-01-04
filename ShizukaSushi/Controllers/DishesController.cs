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
        try
        {
            Dish d = new Dish(Guid.NewGuid(), request.Name, request.Description, DateTime.UtcNow, request.Ingredients);
            _context.Dishes.Add(d);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return new ObjectResult(new { message = "An error occurred while processing your request." + ex.ToString() })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }

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
        try
        {
            Dish? d1 = _context.Dishes.Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (d1 != null)
            {
                _context.Dishes.Remove(d1);
            }

            Dish d2 = new Dish(id, request.Name, request.Description, DateTime.UtcNow, request.Ingredients);
            _context.Dishes.Add(d2);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return new ObjectResult(new { message = "An error occurred while processing your request." + ex.ToString() })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }

        return Ok(request);
    }

    [HttpDelete("/dishes/{id:guid}")]
    public IActionResult DeleteDish(Guid id)
    {
        Dish? d1 = _context.Dishes.Where(x => x.Id.Equals(id)).FirstOrDefault();
        if (d1 != null)
        {
            _context.Dishes.Remove(d1);
        }
        return Ok(id);
    }
}
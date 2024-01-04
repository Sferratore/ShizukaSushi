namespace ShizukaSushi.Controllers;

using Microsoft.AspNetCore.Mvc;
using ShizukaSushi.Contracts.Dishes;
using ShizukaSushi.DatabaseContext;
using ShizukaSushi.Models;


/* DishesController is the main API controller 
 * of the application */


[ApiController] //Attribute used to define DishesController class as API Controller.
public class DishesController : ControllerBase //Inheritance of ControllerBase defines the class as controller, which gets automatically managed by DI defined on Program.cs.
{
    private readonly ShizukaDbContext _context; //Contains the DbContext in use.


    //Constructor. Implements DI of ShizukaDbContext.
    public DishesController(ShizukaDbContext context)
    {
        _context = context;
    }



    [HttpPost("/dishes")] //Attribute that defines method call. In this case, you should call */dishes with a POST call.
    public IActionResult CreateDish(CreateDishRequest request) //Method that handles Dish creation.
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
    public IActionResult GetDish(Guid id) //Method that handles Dish data retrieval.
    {
        Dish? d = _context.Dishes.Where(x => x.Id.Equals(id)).FirstOrDefault();
        return Ok(d);
    }


    [HttpPut("/dishes/{id:guid}")]
    public IActionResult UpdateDish(Guid id, UpdateDishRequest request) //Method that handles Dish data update.
    {
        try
        {
            //Delete Dish
            Dish? d1 = _context.Dishes.Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (d1 != null)
            {
                _context.Dishes.Remove(d1);
            }

            //Create new one with request info and same id.
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
    public IActionResult DeleteDish(Guid id) //Method that handles Dish deletion.
    {
        Dish? d1 = _context.Dishes.Where(x => x.Id.Equals(id)).FirstOrDefault();
        if (d1 != null)
        {
            _context.Dishes.Remove(d1);
        }
        return Ok(id);
    }
}
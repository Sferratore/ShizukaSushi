namespace ShizukaSushi.Contracts.Dishes;

/* CreateDishRequest is a class which represents the fields
 * of the JSON that must belong to the request.
 * Represents interested fields of a Dish item.*/
public record UpdateDishRequest(
    string Name,
    string Description,
    List<string> Ingredients
);
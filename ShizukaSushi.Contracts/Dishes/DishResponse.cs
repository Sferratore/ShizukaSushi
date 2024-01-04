namespace ShizukaSushi.Contracts.Dishes;

/* DishResponse is a class which represents the fields
 * of the JSON that will be represented for the responses
 * of the requests that need a JSON response. It represents
 * a Dish item with all of its fields. */

public record DishResponse(
    Guid id,
    string Name,
    string Description,
    DateTime LastModifiedDateTime,
    List<string> Ingredients
);
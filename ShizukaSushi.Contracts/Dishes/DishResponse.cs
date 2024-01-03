namespace ShizukaSushi.Contracts.Dishes;

public record DishResponse(
    Guid id,
    string Name,
    string Description,
    DateTime LastModifiedDateTime,
    List<string> Ingredients
);
namespace ShizukaSushi.Contracts.Dishes;

public record UpdateDishRequest(
    string Name,
    string Description,
    List<string> Ingredients
);
namespace ShizukaSushi.Contracts.Dishes;

public record CreateDishRequest(
    string Name,
    string Description,
    List<string> Ingredients
);
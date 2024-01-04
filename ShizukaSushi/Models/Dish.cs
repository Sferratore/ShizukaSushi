namespace ShizukaSushi.Models;

// The Dish class represents a model in the application and an entity in EF.
public class Dish
{
    // Unique identifier for each Dish.
    public Guid Id { get; private set; }

    // Name of the dish.
    public string Name { get; private set; }

    // Description of the dish.
    public string Description { get; private set; }

    // DateTime indicating the last time the dish was modified.
    public DateTime LastModifiedDateTime { get; private set; }

    // List of ingredients in the dish.
    public List<string> Ingredients { get; private set; }

    // Private constructor, used by EF. (Need to check if it works without actually)
    private Dish(Guid Id, string Name, string Description, DateTime LastModifiedDateTime)
    {
        this.Id = Id;
        this.Name = Name;
        this.Description = Description;
        this.LastModifiedDateTime = LastModifiedDateTime;
        this.Ingredients = new List<string>();
    }

    // Public constructor that allows setting all properties. Used in the program.
    public Dish(Guid Id, string Name, string Description, DateTime LastModifiedDateTime, List<string> Ingredients)
    {
        this.Id = Id;
        this.Name = Name;
        this.Description = Description;
        this.LastModifiedDateTime = LastModifiedDateTime;
        this.Ingredients = Ingredients;
    }

}

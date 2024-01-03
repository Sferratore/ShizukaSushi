namespace ShizukaSushi.Models;

public class Dish
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime LastModifiedDateTime { get; private set; }
    public List<string> Ingredients { get; private set; }

    private Dish(Guid Id, string Name, string Description, DateTime LastModifiedDateTime)
    {
        this.Id = Id;
        this.Name = Name;
        this.Description = Description;
        this.LastModifiedDateTime = LastModifiedDateTime;
        this.Ingredients = new List<string>();
    }

}
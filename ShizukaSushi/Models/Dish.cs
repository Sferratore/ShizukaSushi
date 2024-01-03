namespace ShizukaSushi.Models;

public class Dish
{
    public Guid Id {get;}
    public string Name {get;}
    public string Description {get;}
    public DateTime LastModifiedDateTime {get;}
    public List<string> Ingredients {get;}

    public Dish(Guid id, string name, string description, DateTime lastmodifieddatetime, List<string> ingredients)
    {
        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.LastModifiedDateTime = lastmodifieddatetime;
        this.Ingredients = ingredients;
    }

}
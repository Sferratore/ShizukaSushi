using Microsoft.EntityFrameworkCore;
using ShizukaSushi.Models;

namespace ShizukaSushi.DatabaseContext;

/* ShizukaDbContext is the main 
 * Dbcontext of the application.*/

public class ShizukaDbContext : DbContext //Inheritance of DbContext defines ShizukaDbContext as a DbContext. DbContext are initialized with DI in Program.cs.
{
    public DbSet<Dish> Dishes { get; set; } //Dishes is the main entity of the application.
    public ShizukaDbContext(DbContextOptions<ShizukaDbContext> options) : base(options) //Constructor defines that the options of the DbContext are inherited by DI definition in Program.cs.
    {
    }

    /* OnModelCreating defines action to take when a Db operation (migration, saving new data...) is taking place. */
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Defines that "Ingredients" list of strings will be treated as a single value of them concatenated. Does not referentiate a different entity.
        modelBuilder.Entity<Dish>()
            .Property(e => e.Ingredients)
            .HasConversion(
                v => string.Join(";", v),
                v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList());
    }

}

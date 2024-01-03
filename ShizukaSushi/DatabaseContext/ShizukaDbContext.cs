using Microsoft.EntityFrameworkCore;
using ShizukaSushi.Models;

namespace ShizukaSushi.DatabaseContext
{
    public class ShizukaDbContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; }
        public ShizukaDbContext(DbContextOptions<ShizukaDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Defines that "Ingredients" list of strings will be converted in a single value of them concatenated. Does not referentiate entity.
            modelBuilder.Entity<Dish>()
                .Property(e => e.Ingredients)
                .HasConversion(
                    v => string.Join(";", v),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList());
        }

    }
}
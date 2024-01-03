using Microsoft.EntityFrameworkCore;
using ShizukaSushi.Models;

namespace ShizukaSushi.DatabaseContext
{
    public class ShizukaDbContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=shizukadb;Uid=root;Pwd=DB09Gennaio;", ServerVersion.AutoDetect("Server=localhost;Port=3306;Database=shizukadb;Uid=root;Pwd=DB09Gennaio;"));
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
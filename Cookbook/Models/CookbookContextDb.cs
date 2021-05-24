using Microsoft.EntityFrameworkCore;

namespace Cookbook.Models
{
    public class CookbookContextDb : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public CookbookContextDb(DbContextOptions<CookbookContextDb> options)
            : base(options)
        {
          
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().HasKey(u => u.Id);
            modelBuilder.Entity<RecipeHistory>().HasKey(u => u.Id);
        }

    }
}

using Cookbook.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace Cookbook.DAL.EF
{
    public class CookbookContext : DbContext
    {
        public CookbookContext(DbContextOptions<CookbookContext> options) : base(options)
        {

        }

        public DbSet<CookBookItem> CookBookItems { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Description>()
                .HasOne<Recipe>(a => a.Recipe)
                .WithOne(b => b.Description)
                .HasForeignKey<Recipe>(e => e.DescriptionID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CookBookItem>()
                .HasOne<Recipe>(s => s.Recipe)
                .WithMany(g => g.CookBookItems)
                .HasForeignKey(s => s.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CookBookItem>()
                .HasOne<Ingredient>(s => s.Ingredient)
                .WithMany(g => g.CookBookItems)
                .HasForeignKey(s => s.IngredientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
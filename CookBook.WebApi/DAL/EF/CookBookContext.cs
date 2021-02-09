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
            modelBuilder.Entity<CookBookItem>()
                .HasOne(r => r.Recipe);
            
            modelBuilder.Entity<CookBookItem>()
                .HasOne(r => r.Ingredient);

            modelBuilder.Entity<CookBookItem>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Ingredient>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Recipe>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Description>()
                .HasKey(i => i.Id);
        }
    }
}
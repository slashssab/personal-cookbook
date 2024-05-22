using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalCookBook.Domain.RecipeAggregate;

namespace PersonalCookBook.Database.EntityConfiguration
{
    internal class IngredientEntityConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.ToTable("Ingredients");
            builder.HasKey(i => i.Id);

            builder.HasOne<Recipe>().WithMany(r => r.Ingredients).HasForeignKey(i => i.RecipeId);
            builder.HasOne(i => i.Product).WithOne().HasForeignKey<Ingredient>(i => i.ProductId);
        }
    }
}

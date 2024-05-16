using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalCookBook.Domain.Constants;
using PersonalCookBook.Domain.RecipeAggregate;

namespace PersonalCookBook.Database.EntityConfiguration
{
    internal class RecipeEntityConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable("Recipes");
            builder.HasKey(x => x.Id);

            builder.Property(r => r.Name).IsRequired().HasMaxLength(MaxLengths.MAX_NAME_LENGTH);
            builder.Property(r => r.Description).IsRequired();

            builder.HasMany(r => r.Ingredients).WithOne().HasForeignKey(i => i.RecipeId);
            builder.HasMany(r => r.Steps).WithOne().HasForeignKey(i => i.RecipeId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalCookBook.Domain.RecipeAggregate;

namespace PersonalCookBook.Database.EntityConfiguration
{
    internal class StepEntityConfiguration : IEntityTypeConfiguration<Step>
    {
        public void Configure(EntityTypeBuilder<Step> builder)
        {
            builder.ToTable("Steps");
            builder.HasKey(i => i.Id);

            builder.Property(s => s.Order).IsRequired();
            builder.Property(s => s.Type).IsRequired();
            builder.Property(s => s.Content).IsRequired();

            builder.HasOne<Recipe>().WithMany(r => r.Steps).HasForeignKey(i => i.RecipeId);
        }
    }
}

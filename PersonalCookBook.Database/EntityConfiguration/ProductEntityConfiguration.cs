using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalCookBook.Domain.Constants;
using PersonalCookBook.Domain.ProductAggregate;

namespace PersonalCookBook.Database.EntityConfiguration
{
    internal class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(MaxLengths.MAX_NAME_LENGTH);
            builder.Property(p => p.Kcal).IsRequired();
            builder.Property(p => p.Protein).IsRequired();
            builder.Property(p => p.Carbs).IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexalith.Example.Domain.Entities;
using Nexalith.Example.Domain.ValueObjects;
using Nexalith.Persistence.EntityFrameworkCore.Converters;

namespace Nexalith.Example.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder
            .HasKey(category => category.Id);

        builder
            .Property(category => category.Id)
            .HasConversion<GuidIdConverter<CategoryId>>();

        builder
            .Property(category => category.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}
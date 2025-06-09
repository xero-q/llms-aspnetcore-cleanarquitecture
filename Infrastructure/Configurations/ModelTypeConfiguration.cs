using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ModelTypeConfiguration:IEntityTypeConfiguration<ModelType>
{
    public void Configure(EntityTypeBuilder<ModelType> builder)
    {
        builder.ToTable("model_types");
        
        builder.HasKey(m => m.Id);
        builder.Property(m=>m.Id).HasColumnName("id");
        
        builder.Property(m => m.Name).HasColumnName("name").IsRequired();
        builder.HasIndex(m => m.Name).IsUnique();
    }
}
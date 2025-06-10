using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Thread = Domain.Entities.Thread;

namespace Infrastructure.Database.Configurations;

public class ThreadConfiguration:IEntityTypeConfiguration<Thread>
{
    public void Configure(EntityTypeBuilder<Thread> builder)
    {
        builder.ToTable("threads");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnName("id");
        
        builder.Property(t => t.Title).HasColumnName("title").IsRequired().HasMaxLength(255);
        builder.HasIndex(t => t.Title).IsUnique();
        
        builder.Property(t => t.CreatedAt).HasColumnName("created_at").IsRequired();
        
        builder.Property(t => t.ModelId).HasColumnName("model_id").IsRequired();
        
        builder.Property(t => t.UserId).HasColumnName("user_id").IsRequired();
        
        builder.HasOne(t=>t.Model).WithMany(t => t.Threads).HasForeignKey(t=>t.ModelId).IsRequired();
        
        builder.HasOne(t=>t.User).WithMany(u => u.Threads).HasForeignKey(t=>t.UserId).IsRequired();
        
    }
}
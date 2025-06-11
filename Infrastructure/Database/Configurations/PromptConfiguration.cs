using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class PromptConfiguration:IEntityTypeConfiguration<Prompt>
{
    public void Configure(EntityTypeBuilder<Prompt> builder)
    {
        builder.ToTable("prompts");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasColumnName("id");
        
        builder.Property(p => p.PromptText).HasColumnName("prompt").IsRequired();
        
        builder.Property(p => p.Response).HasColumnName("response").IsRequired();
        
        builder.Property(p => p.CreatedAt).HasColumnName("created_at").IsRequired();
        
        builder.Property(p => p.ThreadId).HasColumnName("thread_id").IsRequired();

        
        builder.HasOne(p=>p.Thread).WithMany(t => t.Prompts).HasForeignKey(t=>t.ThreadId).IsRequired();
    }
}
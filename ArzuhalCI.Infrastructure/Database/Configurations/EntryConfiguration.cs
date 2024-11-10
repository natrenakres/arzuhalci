using ArzuhalCI.Domain.Entries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArzuhalCI.Infrastructure.Database.Configurations;

public class EntryConfiguration : IEntityTypeConfiguration<Entry>
{
    public void Configure(EntityTypeBuilder<Entry> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ComplexProperty(
            e => e.Prompt,
            propertyBuilder => propertyBuilder.Property(x => x.Content)
                .HasColumnName("prompt")
        );

        builder.ComplexProperty(
            e => e.Output,
            complexPropertyBuilder => complexPropertyBuilder.Property(x => x.Text)
                .HasColumnName("output")
                .IsRequired(false)
            );

        builder
            .HasOne(p => p.Analyse)
            .WithOne(a => a.Entry)
            .HasForeignKey<Analyse>();
    }
}
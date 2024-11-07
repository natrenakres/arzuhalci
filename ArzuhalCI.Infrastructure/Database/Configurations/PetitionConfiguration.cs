using ArzuhalCI.Domain.Petitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArzuhalCI.Infrastructure.Database.Configurations;

public class PetitionConfiguration : IEntityTypeConfiguration<Petition>
{
    public void Configure(EntityTypeBuilder<Petition> builder)
    {
        builder.HasKey(p => p.Id);

        builder.ComplexProperty(p => p.Content,
            propertyBuilder => propertyBuilder.Property(x => x.Text).HasColumnName("content"));
    }
}
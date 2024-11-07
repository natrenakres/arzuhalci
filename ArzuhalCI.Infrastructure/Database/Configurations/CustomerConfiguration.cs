using ArzuhalCI.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArzuhalCI.Infrastructure.Database.Configurations;

internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(c => c.Id);

        builder.ComplexProperty(
            c => c.Email,
            b => b.Property(e => e.Value).HasColumnName("email"));

        builder.ComplexProperty(
            c => c.Name,
            b => b.Property(e => e.Value).HasColumnName("name")
        );

    }
}
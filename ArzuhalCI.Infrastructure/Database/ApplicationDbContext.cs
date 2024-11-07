using System.Data;
using ArzuhalCI.Application.Abstractions.Data;
using ArzuhalCI.Domain.Customers;
using ArzuhalCI.Domain.Entries;
using ArzuhalCI.Domain.Petitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ArzuhalCI.Infrastructure.Database;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
    { }


    public DbSet<Customer> Customers { get; set; }
    public DbSet<Entry> Entries { get; set; }

    public DbSet<Analyse> Analyses { get; set; }

    public DbSet<Petition> Petitions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.HasDefaultSchema(Schemas.Default);
    }

    public async Task<IDbTransaction> BeginTransactionAsync()
    {
        return (await Database.BeginTransactionAsync()).GetDbTransaction();
    }
}
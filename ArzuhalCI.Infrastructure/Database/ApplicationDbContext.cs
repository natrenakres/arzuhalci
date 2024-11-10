using System.Data;
using ArzuhalCI.Application.Abstractions.Data;
using ArzuhalCI.Domain.Customers;
using ArzuhalCI.Domain.Entries;
using ArzuhalCI.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ArzuhalCI.Infrastructure.Database;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPublisher publisher)
    : base(options)
    {
        _publisher = publisher;
    }


    public DbSet<Customer> Customers { get; set; }
    public DbSet<Entry> Entries { get; set; }

    public DbSet<Analyse> Analyses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        modelBuilder.HasDefaultSchema(Schemas.Default);
    }

    public async Task<IDbTransaction> BeginTransactionAsync()
    {
        return (await Database.BeginTransactionAsync()).GetDbTransaction();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var numberOfItems = await base.SaveChangesAsync(cancellationToken);

        await PublishDomainEvents(cancellationToken);

        return numberOfItems;
    }

    private async Task PublishDomainEvents(CancellationToken cancellationToken)
    {
        var domainEvents = ChangeTracker
            .Entries<Entity>()
            .Select(e => e.Entity)
            .SelectMany(entity =>
            {
                var domainEvents = entity.DomainEvents;
                entity.ClearDomainEvents();
                return domainEvents;
            })
            .ToList();

        foreach (var domainEvent in domainEvents)
        {
            await _publisher.Publish(domainEvent, cancellationToken);
        }
    }
}
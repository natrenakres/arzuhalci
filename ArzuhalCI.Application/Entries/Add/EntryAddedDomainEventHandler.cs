using ArzuhalCI.Application.Abstractions.Ai;
using ArzuhalCI.Application.Abstractions.Data;
using ArzuhalCI.Domain.Entries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ArzuhalCI.Application.Entries.Add;

public class EntryAddedDomainEventHandler : INotificationHandler<EntryAddedDomainEvent>
{
    private readonly IEntryRepository _entryRepository;
    private readonly IAiService _aiService;
    private readonly ILogger<EntryAddedDomainEventHandler> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public EntryAddedDomainEventHandler(IEntryRepository entryRepository, IAiService aiService, ILogger<EntryAddedDomainEventHandler> logger, IUnitOfWork unitOfWork)
    {
        _entryRepository = entryRepository;
        _aiService = aiService;
        _logger = logger;
        _unitOfWork = unitOfWork;
    }


    public async Task Handle(EntryAddedDomainEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine("New Entry Added for analyse {0}", notification.EntryId);

        var entry = await _entryRepository.GetAsync(notification.EntryId, cancellationToken);
        
        if (entry is null)
        {
            _logger.LogWarning("Entry is null {EntryId}", notification.EntryId);
            return;
        }
        
        var output = await _aiService.Chat(entry?.Prompt.Content);
        
        entry?.AddOutput(output ?? "");
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
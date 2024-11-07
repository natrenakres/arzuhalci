using ArzuhalCI.Application.Abstractions.Authentication;
using ArzuhalCI.Application.Abstractions.Data;
using ArzuhalCI.Application.Abstractions.Messaging;
using ArzuhalCI.Domain.Entries;
using ArzuhalCI.SharedKernel;

namespace ArzuhalCI.Application.Entries.Add;

internal sealed class AddEntryHandler: ICommandHandler<AddEntry, Guid>
{
    
    private readonly IEntryRepository _entryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddEntryHandler(IEntryRepository entryRepository, IUnitOfWork unitOfWork)
    {
    
        _entryRepository = entryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(AddEntry request, CancellationToken cancellationToken)
    {
        // TODO: use UserContext!
        var entry = Entry.Create(request.Prompt, Guid.NewGuid());
        
        _entryRepository.Insert(entry);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return entry.Id;

    }
}
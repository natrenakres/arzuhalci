using ArzuhalCI.Application.Abstractions.Authentication;
using ArzuhalCI.Application.Abstractions.Messaging;
using ArzuhalCI.Domain.Entries;
using ArzuhalCI.SharedKernel;
using FluentValidation;

namespace ArzuhalCI.Application.Entries.Get;

internal class GetEntryHandler : IQueryHandler<GetEntry, EntryResponse>
{
    private readonly IEntryRepository _entryRepository;
    private readonly IUserContext _userContext;

    public GetEntryHandler(IEntryRepository entryRepository, IUserContext userContext)
    {
        _entryRepository = entryRepository;
        _userContext = userContext;
    }

    public async Task<Result<EntryResponse>> Handle(GetEntry request, CancellationToken cancellationToken)
    {
        var entry = await _entryRepository.GetCustomerEntry(request.EntryId, _userContext.IdentityId, cancellationToken);

        return entry is null 
            ? Result.Failure<EntryResponse>(EntryErrors.NotFound()) 
            : EntryResponse.Map(entry);
    }
}

public class GetEntryValidator : AbstractValidator<GetEntry>
{
    public GetEntryValidator()
    {
        RuleFor(x => x.EntryId).NotEmpty();
    }
}
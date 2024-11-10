using ArzuhalCI.Application.Abstractions.Authentication;
using ArzuhalCI.Application.Abstractions.Data;
using ArzuhalCI.Application.Abstractions.Messaging;
using ArzuhalCI.Domain.Entries;
using ArzuhalCI.SharedKernel;


namespace ArzuhalCI.Application.Entries.AddAnalyse;

public class AddAnalyseHandler : ICommandHandler<AddAnalyse>
{
    private readonly IEntryRepository _entryRepository;
    private readonly IUserContext _userContext;
    private readonly IUnitOfWork _unitOfWork;

    public AddAnalyseHandler(IEntryRepository entryRepository, IUserContext userContext, IUnitOfWork unitOfWork)
    {
        _entryRepository = entryRepository;
        _userContext = userContext;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(AddAnalyse request, CancellationToken cancellationToken)
    {
        var entry = await _entryRepository.GetAsync(request.EntryId, _userContext.IdentityId,  cancellationToken);

        if (entry is null)
        {
            return Result.Failure(EntryErrors.NotFound());
        }

        entry.AddAnalyse(request.Mood, request.Negative, request.SentimentScore, request.Subject, request.Petition, request.Summary)
            .SetAnalysed();

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
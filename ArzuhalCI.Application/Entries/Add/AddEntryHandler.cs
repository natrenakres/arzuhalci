using ArzuhalCI.Application.Abstractions.Authentication;
using ArzuhalCI.Application.Abstractions.Data;
using ArzuhalCI.Application.Abstractions.Messaging;
using ArzuhalCI.Application.Entries.Get;
using ArzuhalCI.Domain.Customers;
using ArzuhalCI.Domain.Entries;
using ArzuhalCI.SharedKernel;

namespace ArzuhalCI.Application.Entries.Add;

internal sealed class AddEntryHandler: ICommandHandler<AddEntry, EntryResponse>
{

    private readonly ICustomerRepository _customerRepository;
    private readonly IEntryRepository _entryRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserContext _userContext;

    public AddEntryHandler(IEntryRepository entryRepository, IUnitOfWork unitOfWork, IUserContext userContext, ICustomerRepository customerRepository)
    {
    
        _entryRepository = entryRepository;
        _unitOfWork = unitOfWork;
        _userContext = userContext;
        _customerRepository = customerRepository;
    }

    public async Task<Result<EntryResponse>> Handle(AddEntry request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdentityAsync(_userContext.IdentityId, cancellationToken);

        if (customer is null)
        {
            return Result.Failure<EntryResponse>(CustomerErrors.NotFoundByAll);
        }
        
        var entry = Entry.Create(request.Prompt, customer.Id);
         _entryRepository.Insert(entry);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return EntryResponse.Map(entry);

    }
}
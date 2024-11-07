using ArzuhalCI.Application.Abstractions.Data;
using ArzuhalCI.Application.Abstractions.Messaging;
using ArzuhalCI.Domain.Customers;
using ArzuhalCI.SharedKernel;

namespace ArzuhalCI.Application.Customers.Add;

internal sealed class AddCustomerHandler : ICommandHandler<AddCustomer, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICustomerRepository _customerRepository;

    public AddCustomerHandler(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
    {
        _unitOfWork = unitOfWork;
        _customerRepository = customerRepository;
    }

    public async Task<Result<Guid>> Handle(AddCustomer request, CancellationToken cancellationToken)
    {
        Result<Email> emailResult = Email.Create(request.Email);
        if (emailResult.IsFailure)
        {
            return Result.Failure<Guid>(emailResult.Error);
        }

        Email email = emailResult.Value;
        if (!await _customerRepository.IsEmailUniqueAsync(email))
        {
            return Result.Failure<Guid>(CustomerErrors.EmailNotUnique);
        }

        var name = new Name(request.Name);
        var customer = Customer.Create(email, name, request.IdentityId);
        
        _customerRepository.Insert(customer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return customer.Id;
    }
}
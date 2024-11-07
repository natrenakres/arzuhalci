using FluentValidation;

namespace ArzuhalCI.Application.Customers.Add;

public class AddCustomerValidator : AbstractValidator<AddCustomer>
{
    public AddCustomerValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .WithErrorCode(CustomerErrorCodes.CreateUser.MissingName);

        RuleFor(c => c.Email)
            .NotEmpty()
            .WithErrorCode(CustomerErrorCodes.CreateUser.MissingEmail)
            .EmailAddress()
            .WithErrorCode(CustomerErrorCodes.CreateUser.InvalidEmail);
    }
}
using FluentValidation;

namespace ArzuhalCI.Application.Entries.Add;

public class AddEntryValidator : AbstractValidator<AddEntry>
{

    public AddEntryValidator()
    {
        RuleFor(c => c.Prompt)
            .NotEmpty()
            .WithErrorCode("Prompt cannot be empty");
    }
}
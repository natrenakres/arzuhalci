using ArzuhalCI.SharedKernel;

namespace ArzuhalCI.Domain.Customers;

public static class CustomerErrors
{
    public static Error NotFoundByAll => Error.NotFound(
        "Users.NotFound",
        $"The users not found");
    
    public static Error NotFound(Guid userId) => Error.NotFound(
        "Users.NotFound",
        $"The user with the Id = '{userId}' was not found");
    
    public static Error NotFound(string identityId) => Error.NotFound(
        "Users.NotFound",
        $"The user with the Id = '{identityId}' was not found");

    public static readonly Error NotFoundByEmail = Error.NotFound(
        "Users.NotFoundByEmail",
        "The user with the specified email was not found");

    public static readonly Error EmailNotUnique = Error.Conflict(
        "Users.EmailNotUnique",
        "The provided email is not unique");
}
namespace ArzuhalCI.Application.Customers;

public class CustomerErrorCodes
{
    public static class CreateUser
    {
        public const string MissingName = nameof(MissingName);
        public const string MissingEmail = nameof(MissingEmail);
        public const string InvalidEmail = nameof(InvalidEmail);
    }
    
    
}
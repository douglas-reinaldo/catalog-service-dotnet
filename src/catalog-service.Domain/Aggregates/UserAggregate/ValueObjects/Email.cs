using System.Net.Mail;
using catalog_service.Domain.Aggregates.UserAggregate.Exceptions;

namespace catalog_service.Domain.Aggregates.UserAggregate.ValueObjects;

using System.Net.Mail;

public sealed class Email
{
    public string EmailAddress { get; private set; }

    private Email(string emailAddress)
    {
        EmailAddress = emailAddress;
    }

    public static Email Create(string emailAddress)
    {
        ValidateEmailNullOrWhitespace(emailAddress);
        ValidateEmailLenght(emailAddress);
        ValidateEmailFormat(emailAddress);
        return new Email(emailAddress.Trim().ToLower());
    }

    private static void ValidateEmailNullOrWhitespace(string emailAddress)
    {
        if  (string.IsNullOrWhiteSpace(emailAddress))
            throw new InvalidUserEmailException("Email address is required");
    }
    
    private static void ValidateEmailLenght(string emailAddress)
    {
        if (emailAddress.Length is < 5 or > 254)
            throw new InvalidUserEmailException("Email address must be between 5 and 254 characters");
    }

    private static void ValidateEmailFormat(string emailAddress)
    {
        try
        {
            var email = new MailAddress(emailAddress);
        }
        catch
        {
            throw new InvalidUserEmailException("Email address is not valid");
        }
    }
}
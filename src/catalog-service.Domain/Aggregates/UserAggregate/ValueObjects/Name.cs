using catalog_service.Domain.Aggregates.UserAggregate.Exceptions;

namespace catalog_service.Domain.Aggregates.UserAggregate.ValueObjects;

public class Name
{
    public String FirstName { get; private set; }
    public String LastName { get; private set; }


    private Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static Name Create(string firstName, string lastName)
    {
        ValidateNameNullOrWhitespace(firstName, lastName);
        ValidateNameLength(firstName, lastName);
        return new Name(firstName.Trim(), lastName.Trim());
    }

    private static void ValidateNameLength(string  firstName, string lastName)
    {
        if (firstName.Length is < 3 or > 50)
            throw new InvalidUserNameException("Fist Name must be between 3 and 50 characters long");

        if (lastName.Length is < 3 or > 50)
            throw new InvalidUserNameException("Last Name must be between 3 and 50 characters long");
        
    }

    private static void ValidateNameNullOrWhitespace(string firstName, string lastName)
    {
        if (String.IsNullOrWhiteSpace(firstName))
            throw new InvalidUserNameException("First Name is required");
        
        if (String.IsNullOrWhiteSpace(lastName))
            throw new InvalidUserNameException("Last Name is required");
    }
    
}
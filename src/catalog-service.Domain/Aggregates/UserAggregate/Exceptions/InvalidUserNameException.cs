using catalog_service.Domain.Exceptions;

namespace catalog_service.Domain.Aggregates.UserAggregate.Exceptions;

public class InvalidUserNameException : DomainException
{
    public InvalidUserNameException(string message) : base(message)
    {
    }
}
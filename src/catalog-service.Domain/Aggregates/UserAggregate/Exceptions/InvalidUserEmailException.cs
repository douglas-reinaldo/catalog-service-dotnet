using catalog_service.Domain.Exceptions;

namespace catalog_service.Domain.Aggregates.UserAggregate.Exceptions;

public class InvalidUserEmailException : DomainException
{
    public InvalidUserEmailException(string message) : base(message)
    {
    }
}
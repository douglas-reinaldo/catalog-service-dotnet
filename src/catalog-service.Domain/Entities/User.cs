namespace catalog_service.Domain.Entities;

using catalog_service.Domain.Exceptions;
using System;

public class User
{
    public int? Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string EmailAddress { get; private set; }
    public string HashPassword { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime  CreatedAt { get; private set; }

    public User(string firstName, string lastName, string emailAddress, string hashPassword)
	{
        ValidateDomain(firstName, lastName, emailAddress, hashPassword);

        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        HashPassword = hashPassword;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }

    public void ValidateDomain(string firstName, string lastName, string emailAddress, string hashPassword) 
    {
        DomainValidation.When(string.IsNullOrWhiteSpace(firstName), "First name is required.");
        DomainValidation.When(string.IsNullOrWhiteSpace(lastName), "Last name is required.");
        DomainValidation.When(string.IsNullOrWhiteSpace(emailAddress), "Email address is required.");
        DomainValidation.When(string.IsNullOrWhiteSpace(hashPassword), "Hashed password is required.");

    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }

}

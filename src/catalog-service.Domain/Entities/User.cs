namespace catalog_service.Domain.Entities;

using System;

public class User
{
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string EmailAddress { get; private set; }
    public string HashPassword { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public User(string firstName, string lastName, string emailAddress, string hashPassword)
	{
        if (string.IsNullOrWhiteSpace(firstName)) 
        {
            throw new ArgumentException("First name is required.", nameof(firstName));
        }
        if (string.IsNullOrWhiteSpace(lastName)) 
        {
            throw new ArgumentException("Last name is required.", nameof(lastName));
        }

        if (string.IsNullOrWhiteSpace(emailAddress)) 
        {
            throw new ArgumentException("Email address is required.", nameof(emailAddress));
        }

        if (string.IsNullOrWhiteSpace(hashPassword)) 
        {
            throw new ArgumentException("Hashed password is required.", nameof(hashPassword));
        }

        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        HashPassword = hashPassword;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;

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

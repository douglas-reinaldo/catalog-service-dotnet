using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using catalog_service.Domain.Entities;

namespace catalog_service.Test.Domain.Entities
{
    public class UserTest
    {
        [Fact]
        public void CreateUser_Should_Create_Valid_User()
        {
            // Arrange
            string firstName = "UserFirstname";
            string lastName = "UserLastname";
            string emailAddress = "UserEmailAddress";
            string hashPassword = "UserHashedPassword";

            // Act
            User user = new User(firstName, lastName, emailAddress, hashPassword);

            // Assert
            Assert.NotNull(user);
        }

        [Fact]
        public void CreateUser_Should_Throw_Exception_When_FirstName_Is_Invalid()
        {
            // Arrange
            string lastName = "UserLastname";
            string emailAddress = "UserEmailAddress";
            string hashPassword = "UserHashedPassword";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new User("", lastName, emailAddress, hashPassword));
        }

        [Fact]
        public void CreateUser_Should_Throw_Exception_When_LastName_is_Invalid()
        {
            // Arrange
            string firstName = "UserFirstname";
            string emailAddress = "UserEmailAddress";
            string hashPassword = "UserHashedPassword";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new User(firstName, "", emailAddress, hashPassword));
        }

        [Fact]
        public void CreateUser_Should_Throw_Exception_When_EmailAddress_Is_Invalid()
        {
            // Arrange
            string firstName = "UserFirstname";
            string lastName = "UserLastname";
            string hashPassword = "UserHashedPassword";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new User(firstName, lastName, "", hashPassword));
        }

        [Fact]
        public void CreateUser_Should_Throw_Exception_When_HashPassword_Is_Invalid()
        {
            // Arrange
            string firstName = "UserFirstname";
            string lastName = "UserLastname";
            string emailAddress = "UserEmailAddress";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new User(firstName, lastName, emailAddress, ""));
        }

        [Fact]
        public void CreateUser_Should_NotBe_DefaultDate()
        {
            // Arrange
            string firstName = "UserFirstname";
            string lastName = "UserLastname";
            string emailAddress = "UserEmailAddress";
            string hashPassword = "UserHashedPassword";

            // Act
            User user = new User(firstName, lastName, emailAddress, hashPassword);

            // Assert
            Assert.NotEqual(default(DateTime), user.CreatedAt);
        }

        [Fact]
        public void CreateUser_User_Should_Be_Active()
        {
            // Arrange
            string firstName = "UserFirstname";
            string lastName = "UserLastname";
            string emailAddress = "UserEmailAddress";
            string hashPassword = "UserHashedPassword";

            // Act
            User user = new User(firstName, lastName, emailAddress, hashPassword);

            // Assert
            Assert.True(user.IsActive);
        }

        [Fact]
        public void Activate_Should_Set_IsActive_To_True()
        {
            // Arrange
            string firstName = "UserFirstname";
            string lastName = "UserLastname";
            string emailAddress = "UserEmailAddress";
            string hashPassword = "UserHashedPassword";
            User user = new User(firstName, lastName, emailAddress, hashPassword);
            user.Deactivate();

            // Act
            user.Activate();

            // Assert
            Assert.True(user.IsActive);
        }

        [Fact]
        public void Activate_Should_Confirm_IsActive_Is_True()
        {
            // Arrange
            string firstName = "UserFirstname";
            string lastName = "UserLastname";
            string emailAddress = "UserEmailAddress";
            string hashPassword = "UserHashedPassword";
            User user = new User(firstName, lastName, emailAddress, hashPassword);

            // Act
            user.Activate();

            // Assert
            Assert.True(user.IsActive);
        }

        [Fact]
        public void Deactivate_Should_Set_IsActive_To_False()
        {
            // Arrange
            string firstName = "UserFirstname";
            string lastName = "UserLastname";
            string emailAddress = "UserEmailAddress";
            string hashPassword = "UserHashedPassword";
            User user = new User(firstName, lastName, emailAddress, hashPassword);

            // Act
            user.Deactivate();

            // Assert
            Assert.False(user.IsActive);
        }

        [Fact]
        public void Deactivate_Should_Confirm_IsActive_Is_False()
        {
            // Arrange
            string firstName = "UserFirstname";
            string lastName = "UserLastname";
            string emailAddress = "UserEmailAddress";
            string hashPassword = "UserHashedPassword";
            User user = new User(firstName, lastName, emailAddress, hashPassword);
            user.Deactivate();

            // Act
            user.Deactivate();

            // Assert
            Assert.False(user.IsActive);
        }
    }
}
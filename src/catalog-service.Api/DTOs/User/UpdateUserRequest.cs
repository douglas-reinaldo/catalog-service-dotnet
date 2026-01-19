using System.ComponentModel.DataAnnotations;

namespace catalog_service.Api.DTOs.User
{
    public record UpdateUserRequest
    (

        [Required]
        [StringLength(100, MinimumLength = 3)]
        string FirstName,

        [Required]
        [StringLength(100, MinimumLength = 3)]
        string LastName,

        [Required]
        [EmailAddress]
        [StringLength(100)]
        string EmailAddress
    );
}

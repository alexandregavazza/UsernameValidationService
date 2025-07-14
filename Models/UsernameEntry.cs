using System;
using System.ComponentModel.DataAnnotations;

namespace UsernameValidationService.Models
{
    public class UsernameEntry
    {
        [Key]
        public Guid AccountId { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6)]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Username must be alphanumeric.")]
        public string Username { get; set; } = string.Empty;
    }
}
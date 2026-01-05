using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProniaAdmin.ViewModels.UserViewModels
{
    public class RegisterVM
    {
        [Required, MaxLength(32), MinLength(2)]
        public string LastName { get; set; } = string.Empty;
        
        [Required, MaxLength(32), MinLength(2)]
        public string FirstName { get; set; } = string.Empty;
        
        [Required, EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;
        
        [Required, MaxLength(256), MinLength(6), DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        

        [Required, MaxLength(256), MinLength(6), DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}

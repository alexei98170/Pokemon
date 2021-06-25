using System.ComponentModel.DataAnnotations;

namespace Pokemon.Models
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}

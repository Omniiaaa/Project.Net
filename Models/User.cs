using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Net.Models
{
    public class User
    {
        public int UserId { get; set; }
        //[Required(ErrorMessage = "Name is Required.")]
        //[StringLength(12, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 12 Charcter.")]
        public string? FirstName { get; set; }
        //[Required(ErrorMessage = "Name is Required.")]
        //[StringLength(12, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 12 Charcter.")]
        public string? LastName { get; set; }
        //[Required(ErrorMessage = "Email is Required.")]
        //[EmailAddress]
        //[DisplayName("User Email")]
        public string? Email { get; set; }
        //[Required(ErrorMessage = "Password is Required.")]
        //[DisplayName("Password")]
        public string? Password { get; set; }
        //[Compare("Password")]
        //[DisplayName("Confirm Password")]
        //[NotMapped]
        //public string? ConfirmPassword { get; set; }

    }
}

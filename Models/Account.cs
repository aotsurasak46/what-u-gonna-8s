
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace what_u_gonna_eat.Models;

public class Account
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Username is required. ")]
    [UniqueUsername(ErrorMessage = "Username is already taken.")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Password is required. ")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Email is required. ")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }


}

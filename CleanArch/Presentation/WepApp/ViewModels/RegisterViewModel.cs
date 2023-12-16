using System.ComponentModel.DataAnnotations;

namespace WepApp.ViewModels;
public class RegisterViewModel
{   
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "As senhas não correspondem!")]
    public string ConfirmPassword { get; set; }
}

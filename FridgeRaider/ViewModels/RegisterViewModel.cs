using System.ComponentModel.DataAnnotations;

namespace FridgeRaider.ViewModels
{
  public class RegisterViewModel
  {
    [Required(ErrorMessage = "An email is required")]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email {get; set; }

    [Required(ErrorMessage = "A username is required")]
    [Display(Name = "User Name")]
    public string UserName {get; set; }

    [Required(ErrorMessage ="Must be between 5 and 20 characters.")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; }
  }
}
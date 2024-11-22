using System.ComponentModel.DataAnnotations;

namespace ServoWeatherService.Models;

public class User
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
    public string Password { get; set; }
    [Required]
    [Compare(nameof(Password))]
    public string Password2 { get; set; }

    public bool Read { get; set; }
    public bool Write { get; set; }
}

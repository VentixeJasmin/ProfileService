using System.ComponentModel.DataAnnotations;

namespace Presentation.Models;

public class ProfileEntity
{
    public string UserId { get; set; } = null!;

    [Key]
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? ProfileImage { get; set; }
}

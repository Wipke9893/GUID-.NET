using System.ComponentModel.DataAnnotations;

namespace StudentPortalWeb.Models;

public class StudentViewModel
{
    [Required, MaxLength(50), MinLength(2)]
    public string Name { get; set; }

    [MaxLength(50), DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [MaxLength(50), DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }

    public bool Subscribed { get; set; }
}

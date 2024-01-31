using System.ComponentModel.DataAnnotations;

namespace StudentPortalWeb.Models.Entities;

public class Student
{
    public Guid Id { get; set; }

    [Required, MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(50)]
    public string Email { get; set; }

    [MaxLength(50)]
    public string Phone { get; set; }

    public bool Subscribed { get; set; }

    public int? Age { get; set; }
}

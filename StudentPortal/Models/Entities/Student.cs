using System.ComponentModel.DataAnnotations; // Importing data annotations for model validation.

namespace StudentPortalWeb.Models.Entities; // Declaring the namespace for your model.

// Definition of the Student class.
public class Student
{
    // 'Id' property of type Guid. It's used as the primary key in the database.
    public Guid Id { get; set; }

    // 'Name' property of type string.
    // The 'Required' attribute specifies that this field must be provided. 
    // 'MaxLength' attribute restricts the length of the string to 50 characters.
    [Required, MaxLength(50)]
    public string Name { get; set; }

    // 'Email' property of type string.
    // 'MaxLength' attribute restricts the length of the string to 50 characters.
    // There's no 'Required' attribute, so this field is optional.
    [MaxLength(50)]
    public string Email { get; set; }

    // 'Phone' property of type string.
    // 'MaxLength' attribute restricts the length of the string to 50 characters.
    // This field is optional as there's no 'Required' attribute.
    [MaxLength(50)]
    public string Phone { get; set; }

    // 'Subscribed' property of type bool.
    // This is a boolean field to indicate whether the student is subscribed or not.
    public bool Subscribed { get; set; }

    // 'Age' property of type int? (nullable int).
    // This field is optional and can hold a null value.
    public int? Age { get; set; }
}

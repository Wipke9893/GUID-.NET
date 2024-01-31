using System.ComponentModel.DataAnnotations; // Importing data annotations for model validation.

namespace StudentPortalWeb.Models; // Declaring the namespace for your model.

// Definition of the StudentViewModel class.
public class StudentViewModel
{
    // 'Name' property of type string.
    // The 'Required' attribute specifies that this field must be provided.
    // 'MaxLength' attribute restricts the length of the string to 50 characters.
    // 'MinLength' attribute ensures that the string has at least 2 characters.
    [Required, MaxLength(50), MinLength(2)]
    public string Name { get; set; }

    // 'Email' property of type string.
    // 'MaxLength' attribute restricts the length of the string to 50 characters.
    // 'DataType' attribute specifies that the data should be formatted as an email address.
    // This attribute helps with HTML5 form validation but does not validate the format of the email on the server-side.
    [MaxLength(50), DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    // 'Phone' property of type string.
    // 'MaxLength' attribute restricts the length of the string to 50 characters.
    // 'DataType' attribute specifies that the data should be formatted as a phone number.
    // Similar to 'DataType.EmailAddress', this attribute aids in client-side formatting and validation.
    [MaxLength(50), DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }

    // 'Subscribed' property of type bool.
    // This boolean field indicates whether the student is subscribed or not.
    public bool Subscribed { get; set; }
}

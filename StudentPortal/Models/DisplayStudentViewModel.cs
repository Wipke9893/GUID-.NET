namespace StudentPortalWeb.Models; // Declaring the namespace for your model.

// Definition of the DisplayStudentViewModel class.
public class DisplayStudentViewModel : StudentViewModel
{
    // Inherits from StudentViewModel, which means it includes all properties and methods defined in StudentViewModel.

    // 'Id' property of type Guid.
    // This property represents the unique identifier for a student.
    // It's important for operations that require student identification, like displaying specific student details.
    public Guid Id { get; set; }
}

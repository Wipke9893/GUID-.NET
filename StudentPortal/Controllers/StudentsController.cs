using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortalWeb.Data;
using StudentPortalWeb.Models;
using StudentPortalWeb.Models.Entities;

namespace StudentPortalWeb.Controllers;

public class StudentsController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    // Constructor to inject the ApplicationDbContext into the controller.
    public StudentsController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext; // Assign the injected DbContext to a private field for later use.
    }

    // HTTP GET method to display the Add Student view.
    public IActionResult Add()
    {
        return View(); // Return the Add view.
    }

    // HTTP POST method to process the student creation form.
    [HttpPost]
    public async Task<IActionResult> Add(StudentViewModel viewModel)
    {
        if (ModelState.IsValid) // Check if the submitted data is valid.
        {
            var student = new Student // Create a new Student entity from the view model.
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = viewModel.Subscribed
            };

            await _dbContext.Students.AddAsync(student); // Add the student to the database context.
            await _dbContext.SaveChangesAsync(); // Save changes to the database.
        }

        return View(viewModel); // Return the same view along with the model, useful for showing validation errors.
    }

    // HTTP GET method to display a paginated list of students.
    public async Task<IActionResult> Index(int? page)
    {
        var skip = 0;
        var pageSize = 2; // Define how many records per page.

        if (page.HasValue && page > 0)
        {
            skip = (page.Value - 1) * pageSize; // Calculate number of records to skip based on the page number.
        }

        var students = await _dbContext.Students
            .Skip(skip) // Skip the calculated number of records.
            .Take(pageSize) // Take the next set of records based on the page size.
            .ToListAsync(); // Execute the query and retrieve the students.

        var viewModels = students
            .Select(student => new DisplayStudentViewModel() // Map the retrieved students to the view model.
            {
                Name = student.Name,
                Id = student.Id,
                Phone = student.Phone,
                Email = student.Email,
                Subscribed = student.Subscribed,
            }).ToList();

        return View(viewModels); // Return the Index view with the list of view models.
    }

    // HTTP GET method to display the edit form for a student.
    public async Task<IActionResult> Edit(Guid id)
    {
        var student = await _dbContext.Students.FindAsync(id); // Find the student by ID.

        if (student is null) // If no student is found,
        {
            return NotFound(); // return a NotFound result.
        }

        var model = new StudentViewModel() // Map the student data to the view model.
        {
            Name = student.Name,
            Email = student.Email,
            Phone = student.Phone,
            Subscribed = student.Subscribed,
        };

        return View(model); // Return the Edit view with the model.
    }

    // HTTP POST method to process the student edit form.
    [HttpPost]
    public async Task<IActionResult> Edit(Guid id, StudentViewModel viewModel)
    {
        var student = await _dbContext.Students.FindAsync(id); // Find the student by ID.

        if (student is null) // If no student is found,
        {
            return NotFound(); // return a NotFound result.
        }

        if (ModelState.IsValid) // Check if the submitted data is valid.
        {
            // Update the student entity with data from the view model.
            student.Name = viewModel.Name;
            student.Email = viewModel.Email;
            student.Phone = viewModel.Phone;
            student.Subscribed = viewModel.Subscribed;

            _dbContext.Students.Update(student); // Mark the entity as updated.
            await _dbContext.SaveChangesAsync(); // Save changes to the database.

            return RedirectToAction(nameof(Index)); // Redirect to the Index action.
        }

        return View(viewModel); // If the model is invalid, return the view with the model for showing validation errors.
    }

    // HTTP POST method to delete a student.
    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        var student = await _dbContext.Students.FindAsync(id); // Find the student by ID.

        if (student is null) // If no student is found,
        {
            return NotFound(); // return a NotFound result.
        }

        _dbContext.Students.Remove(student); // Remove the student from the context.
        await _dbContext.SaveChangesAsync(); // Save changes to the database.

        return RedirectToAction(nameof(Index)); // Redirect to the Index action.
    }

    // HTTP GET method to display a student's details.
    public async Task<IActionResult> Display(Guid id)
    {
        var student = await _dbContext.Students.FindAsync(id); // Find the student by ID.

        if (student is null) // If no student is found,
        {
            return NotFound(); // return a NotFound result.
        }

        var viewModel = new StudentViewModel // Map the student data to the view model.
        {
            Name = student.Name,
            Email = student.Email,
            Phone = student.Phone,
            Subscribed = student.Subscribed
        };

        return View(viewModel); // Return the Display view with the model.
    }
}


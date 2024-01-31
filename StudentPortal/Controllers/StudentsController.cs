using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortalWeb.Data;
using StudentPortalWeb.Models;
using StudentPortalWeb.Models.Entities;

namespace StudentPortalWeb.Controllers;

public class StudentsController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public StudentsController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(StudentViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = viewModel.Subscribed
            };

            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
        }

        return View(viewModel);
    }

    // /
    // /Strudents/List?page=2
    public async Task<IActionResult> Index(int? page)
    {
        var skip = 0;
        var pageSize = 2;

        if (page.HasValue && page > 0)
        {
            // (2 - 1) * 25
            // (3 - 1) * 25
            skip = (page.Value - 1) * pageSize;
        }

        var students = await _dbContext.Students
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();

        var viewModels = students
            .Select(student => new DisplayStudentViewModel()
            {
                Name = student.Name,
                Id = student.Id,
                Phone = student.Phone,
                Email = student.Email,
                Subscribed = student.Subscribed,
            }).ToList();

        return View(viewModels);
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var student = await _dbContext.Students.FindAsync(id);

        if (student is null)
        {
            return NotFound();
        }

        var model = new StudentViewModel()
        {
            Name = student.Name,
            Email = student.Email,
            Phone = student.Phone,
            Subscribed = student.Subscribed,
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Guid id, StudentViewModel viewModel)
    {
        var student = await _dbContext.Students.FindAsync(id);

        if (student is null)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            student.Name = viewModel.Name;
            student.Email = viewModel.Email;
            student.Phone = viewModel.Phone;
            student.Subscribed = viewModel.Subscribed;

            _dbContext.Students.Update(student);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        var student = await _dbContext.Students.FindAsync(id);

        if (student is null)
        {
            return NotFound();
        }

        _dbContext.Students.Remove(student);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Display(Guid id)
    {
        var student = await _dbContext.Students.FindAsync(id);

        if (student is null)
        {
            return NotFound();
        }

        var viewModel = new StudentViewModel
        {
            Name = student.Name,
            Email = student.Email,
            Phone = student.Phone,
            Subscribed = student.Subscribed
        };

        return View(viewModel);
    }
}


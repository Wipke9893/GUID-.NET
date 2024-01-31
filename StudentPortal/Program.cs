using Microsoft.EntityFrameworkCore; // Importing the Entity Framework Core namespace.
using StudentPortalWeb.Data; // Importing your application's data-related classes.

var builder = WebApplication.CreateBuilder(args); // Initializes a new builder for the web application with command-line arguments.

// Add services to the application's DI container.
builder.Services.AddControllersWithViews(); // Registers MVC services to enable the use of controllers and views.

// Add the application's DbContext as a service with SQL Server as the database provider.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StudentPortal"))); // Configures the DbContext to use SQL Server with the "StudentPortal" connection string from the configuration.

var app = builder.Build(); // Builds the web application based on the configurations set up in the builder.

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) // Checks if the environment is not set to development.
{
    app.UseExceptionHandler("/Home/Error"); // In non-development environments, use a custom error handler.
    app.UseHsts(); // Enforces HTTPS usage with HTTP Strict Transport Security (HSTS) in non-development environments.
}

app.UseHttpsRedirection(); // Redirects all HTTP requests to HTTPS.
app.UseStaticFiles(); // Enables serving static files like images, CSS, and JavaScript.

app.UseRouting(); // Adds routing capabilities to the application.

app.UseAuthorization(); // Adds authorization middleware to the pipeline.

// Define the default route pattern for MVC controllers.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Students}/{action=Index}/{id?}"); // Sets the default route as /Students/Index. The {id?} means the 'id' parameter is optional.

app.Run(); // Runs the application.


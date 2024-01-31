using Microsoft.EntityFrameworkCore; // Importing the Entity Framework Core namespace.
using StudentPortalWeb.Models.Entities; // Importing the namespace where your entity models are defined.

namespace StudentPortalWeb.Data // Declaring the namespace for your data context.
{
    // ApplicationDbContext class, derived from DbContext, is the main class that coordinates Entity Framework functionality for a given data model.
    public class ApplicationDbContext : DbContext
    {
        // Constructor for ApplicationDbContext. It receives DbContextOptions<ApplicationDbContext> which contains the configuration information.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // Calling the base constructor of DbContext with the options received. 
            // This sets up the context with all the necessary configurations (like connection string, database provider) to interact with the database.
        }

        // DbSet<Student> represents the collection of all Student entities in the context, or that can be queried from the database.
        // It's like a table in the database.
        public DbSet<Student> Students { get; set; }
    }
}

# How to connect to the DB (any SQL database)

### NuGet packages:

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.PostgreSQL (might be different)
- Microsoft.EntityFrameworkCore.SqlServer (might be different)

## 1 Connection string

    Add the connection string to appsettings.json; think of it like a .env with the database info (secrets are still better, but this works for local setups).

    Before the last "}" add:

    "AllowedHosts": "*",
    "DefaultConnection": "Host=; Database=; Username=; Password="
  
## 2 Models

    Same as Django models; only the syntax changes.

    Example:

    public class Book
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
    

## 3 Making the context
    
    After defining Book and User entities we need to associate them with tables; we have only declared the properties, not the keys or mappings, and that comes next:

    using Microsoft.EntityFrameworkCore;
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<User> User { get; set; }
    }


    This means the Book entity maps to the Books table and the User entity maps to the Users table.

    The "<name>" placeholder can change; I used ApplicationDbContext but it could be MyContext or DbModels. This will matter in the next step.


## 4 Program.cs

    It's like Django Settings.py but more barebones.

    We need to register a dependency-injected DbContext to manage the database; in the next command #1 and #2 are placeholders: 

    builder.Services.AddDbContext<#1>(options =>
    {
        options.#2(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

    So, #1 is the "<name>" we defined earlier and #2 depends on the database provider you use:

    PostgreSQL: UseNpgsql
    SQL Server: UseSqlServer
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Student.Models;

public class PersonContext : DbContext
{
    public PersonContext(DbContextOptions<PersonContext> options) : base(options)
    {

    }

    public DbSet<Person>? Persons { get; set; }
}
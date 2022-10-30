using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace EntityFrameworkTest.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Student>? Students { get; set; }
}
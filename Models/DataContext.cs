using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace EntityFrameworkTest.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
           => optionsBuilder.UseNpgsql(@"Host=tiny.db.elephantsql.com;Username=gjbbhgbn;Password=qKiC6mlhZ01QVV-Zc1C-2nFkgAELCcw9;Database=gjbbhgbn");

    public DbSet<Student>? Students { get; set; }
}
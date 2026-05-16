using Microsoft.EntityFrameworkCore;
using LabYonetimSistemi.Models;

namespace LabYonetimSistemi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Lab> Labs { get; set; }
    public DbSet<Computer> Computers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Software> Softwares { get; set; }
    public DbSet<Issue> Issues { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Computer>().ToTable("Computers");
    }
}
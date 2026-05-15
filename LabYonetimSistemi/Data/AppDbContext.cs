using Microsoft.EntityFrameworkCore;
using LabYonetimSistemi.Models;

namespace LabYonetimSistemi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Computer> Computers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Computer>().ToTable("Computers");
    }
}
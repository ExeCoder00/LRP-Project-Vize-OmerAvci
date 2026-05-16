using Microsoft.EntityFrameworkCore;
using LabYonetimSistemi.Data;
using LabYonetimSistemi.Models;

public static class StudentEndpoints
{
    public static void MapStudentEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/admin/students");

        // Listeleme
        group.MapGet("/", async (AppDbContext db) =>
            await db.Students.ToListAsync());

        // Öğrenci Atama + Otomatik Kullanıcı Oluşturma
        group.MapPost("/", async (AppDbContext db, Student student) =>
        {
            db.Students.Add(student);
            var yeniKullanici = new User
            {
                Username = student.Username,
                Password = "123456",
                Role = "Student"
            };
            db.Users.Add(yeniKullanici);
            await db.SaveChangesAsync();
            return Results.Created($"/api/admin/students/{student.Id}", student);
        });

        // Güncelleme
        group.MapPut("/{id}", async (AppDbContext db, int id, Student student) =>
        {
            var item = await db.Students.FindAsync(id);
            if (item == null) return Results.NotFound();
            item.FullName = student.FullName;
            item.Grade = student.Grade;
            item.ComputerId = student.ComputerId;
            item.ComputerIds = student.ComputerIds;
            item.Username = student.Username;
            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        // Silme
        group.MapDelete("/{id}", async (AppDbContext db, int id) =>
        {
            var item = await db.Students.FindAsync(id);
            if (item == null) return Results.NotFound();
            db.Students.Remove(item);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        // Öğrencinin tüm zimmetli bilgisayarlarını getir
        group.MapGet("/computers/{username}", async (AppDbContext db, string username) =>
        {
            var student = await db.Students.FirstOrDefaultAsync(s => s.Username == username);
            if (student == null) return Results.NotFound();

            var computerIds = new List<int>();
            if (!string.IsNullOrEmpty(student.ComputerIds))
            {
                computerIds = student.ComputerIds.Split(',')
                    .Where(x => int.TryParse(x.Trim(), out _))
                    .Select(x => int.Parse(x.Trim()))
                    .ToList();
            }
            if (student.ComputerId > 0 && !computerIds.Contains(student.ComputerId))
                computerIds.Add(student.ComputerId);

            var computers = await db.Computers
                .Where(c => computerIds.Contains(c.Id))
                .ToListAsync();

            return Results.Ok(computers);
        });

        // Eski endpoint (geriye dönük uyumluluk)
        group.MapGet("/computer/{username}", async (AppDbContext db, string username) =>
        {
            var student = await db.Students.FirstOrDefaultAsync(s => s.Username == username);
            if (student == null) return Results.NotFound();
            var computer = await db.Computers.FindAsync(student.ComputerId);
            return Results.Ok(computer);
        });
    }
}
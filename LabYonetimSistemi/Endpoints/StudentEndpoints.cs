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

            // Otomatik kullanıcı oluştur
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

        // Öğrencinin zimmetli bilgisayarını getir
        group.MapGet("/computer/{username}", async (AppDbContext db, string username) =>
        {
            var student = await db.Students.FirstOrDefaultAsync(s => s.Username == username);
            if (student == null) return Results.NotFound();
            var computer = await db.Computers.FindAsync(student.ComputerId);
            return Results.Ok(computer);
        });
    }
}
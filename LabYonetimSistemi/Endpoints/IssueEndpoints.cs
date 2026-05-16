using Microsoft.EntityFrameworkCore;
using LabYonetimSistemi.Data;
using LabYonetimSistemi.Models;

public static class IssueEndpoints
{
    public static void MapIssueEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/admin/issues");

        // Listeleme
        group.MapGet("/", async (AppDbContext db) =>
            await db.Issues.ToListAsync());

        // Ekleme
        group.MapPost("/", async (AppDbContext db, Issue issue) =>
        {
            db.Issues.Add(issue);
            await db.SaveChangesAsync();
            return Results.Created($"/api/admin/issues/{issue.Id}", issue);
        });

        // Çözüldü olarak işaretle
        group.MapPut("/{id}/resolve", async (AppDbContext db, int id) =>
        {
            var item = await db.Issues.FindAsync(id);
            if (item == null) return Results.NotFound();
            item.IsResolved = true;
            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        // Silme
        group.MapDelete("/{id}", async (AppDbContext db, int id) =>
        {
            var item = await db.Issues.FindAsync(id);
            if (item == null) return Results.NotFound();
            db.Issues.Remove(item);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
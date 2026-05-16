using Microsoft.EntityFrameworkCore;
using LabYonetimSistemi.Data;
using LabYonetimSistemi.Models;

public static class LabEndpoints
{
    public static void MapLabEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/admin/labs");

        group.MapGet("/", async (AppDbContext db) =>
            await db.Labs.Select(l => new { l.Id, l.Name, PcSayisi = l.Computers.Count }).ToListAsync());

        group.MapPost("/", async (AppDbContext db, Lab lab) =>
        {
            db.Labs.Add(lab);
            await db.SaveChangesAsync();
            return Results.Created($"/api/labs/{lab.Id}", lab);
        });

        group.MapPut("/{id}", async (AppDbContext db, int id, Lab lab) =>
        {
            var item = await db.Labs.FindAsync(id);
            if (item == null) return Results.NotFound();
            item.Name = lab.Name;
            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (AppDbContext db, int id) =>
        {
            var item = await db.Labs.FindAsync(id);
            if (item == null) return Results.NotFound();
            db.Labs.Remove(item);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
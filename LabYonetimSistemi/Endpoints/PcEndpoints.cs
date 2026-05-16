using Microsoft.EntityFrameworkCore;
using LabYonetimSistemi.Data;
using LabYonetimSistemi.Models;

public static class PcEndpoints
{
    public static void MapPcEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/admin/computers");

        // Listeleme
        group.MapGet("/", async (AppDbContext db) =>
            await db.Computers.ToListAsync());

        // Ekleme (AssetCode otomatik üretimi)
        group.MapPost("/", async (AppDbContext db, Computer pc) =>
        {
            var labPcCount = await db.Computers.CountAsync(c => c.LabId == pc.LabId);
            pc.AssetCode = $"LAB{pc.LabId}-PC-{(labPcCount + 1):D2}";
            db.Computers.Add(pc);
            await db.SaveChangesAsync();
            return Results.Created($"/api/admin/computers/{pc.Id}", pc);
        });

        // Güncelleme
        group.MapPut("/{id}", async (AppDbContext db, int id, Computer pc) =>
        {
            var item = await db.Computers.FindAsync(id);
            if (item == null) return Results.NotFound();
            item.Brand = pc.Brand;
            item.Processor = pc.Processor;
            item.Ram = pc.Ram;
            item.HasHdmi = pc.HasHdmi;
            item.HasInternet = pc.HasInternet;
            item.HasVeyon = pc.HasVeyon;
            item.LabId = pc.LabId;
            await db.SaveChangesAsync();
            return Results.NoContent();
        });

        // Silme
        group.MapDelete("/{id}", async (AppDbContext db, int id) =>
        {
            var item = await db.Computers.FindAsync(id);
            if (item == null) return Results.NotFound();
            db.Computers.Remove(item);
            await db.SaveChangesAsync();
            return Results.NoContent();
        });
    }
}
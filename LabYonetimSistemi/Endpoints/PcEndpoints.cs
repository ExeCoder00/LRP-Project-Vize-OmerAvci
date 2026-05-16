using Microsoft.EntityFrameworkCore;
using LabYonetimSistemi.Data;
using LabYonetimSistemi.Models;

public static class PcEndpoints
{
    public static void MapPcEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/admin/computers");

        group.MapGet("/", async (AppDbContext db) =>
            await db.Computers.ToListAsync());

        group.MapPost("/", async (AppDbContext db, Computer pc) =>
        {
            var lab = await db.Labs.FindAsync(pc.LabId);
            var labPcCount = await db.Computers.CountAsync(c => c.LabId == pc.LabId);
            var labKod = lab?.Name.Replace("-", "").Replace(" ", "").ToUpper() ?? $"LAB{pc.LabId}";
            pc.AssetCode = $"{labKod}-PC-{(labPcCount + 1):D2}";
            db.Computers.Add(pc);
            await db.SaveChangesAsync();
            return Results.Created($"/api/admin/computers/{pc.Id}", pc);
        });

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
            item.Type = pc.Type;
            item.LabId = pc.LabId;
            await db.SaveChangesAsync();
            return Results.NoContent();
        });

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
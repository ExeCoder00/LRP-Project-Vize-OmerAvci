using LabYonetimSistemi.Data;
using LabYonetimSistemi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "LabYonetimSistemi", Version = "v1" });
});

var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "LabYonetimSistemi v1");
});

app.MapGet("/api/bilgisayarlar", async (AppDbContext context) => {
    return await context.Computers.ToListAsync();
});

app.MapGet("/api/arizali-pcler", async (AppDbContext context) => {
    return await context.Computers.Where(x => !x.HasInternet).ToListAsync();
});

app.MapGet("/api/bilgisayar/{id}", async (AppDbContext context, int id) => {
    var bulunan = await context.Computers.FindAsync(id);
    return bulunan;
});

app.MapPost("/api/bilgisayar-ekle", async (AppDbContext context, Computer yeniPc) => {
    context.Computers.Add(yeniPc);
    await context.SaveChangesAsync();
    return Results.Ok(yeniPc);
});

app.MapGet("/api/lab-istatistik", async (AppDbContext context) => {
    var gucluPcler = await context.Computers.Where(p => p.Ram > 8).ToListAsync();
    var siraliPcler = await context.Computers.OrderBy(p => p.Brand).ToListAsync();
    var tekPc = await context.Computers.FirstOrDefaultAsync(p => p.Id == 1);
    var markalar = await context.Computers.Select(p => p.Brand).ToListAsync();
    var arizaSayisi = await context.Computers.CountAsync(p => !p.HasInternet);
    bool canavarVarMi = await context.Computers.AnyAsync(p => p.Ram == 32);
    return new
    {
        YuksekRamliCihazlar = gucluPcler,
        AlfabetikListe = siraliPcler,
        ArananBilgisayar = tekPc,
        SistemdekiMarkalar = markalar,
        ToplamAriza = arizaSayisi,
        LuksPcVarMi = canavarVarMi
    };
});

app.MapPost("/api/ariza-bildir", async (AppDbContext context, int pcId) => {
    var bulunanPc = await context.Computers.FindAsync(pcId);
    if (bulunanPc == null)
    {
        return Results.NotFound($"Hata: {pcId} numaralý bilgisayar sistemde kayýtlý deðil!");
    }
    bulunanPc.HasInternet = false;
    await context.SaveChangesAsync();
    string oncelikDurumu = bulunanPc.Ram >= 16
        ? "KRÝTÝK: Laboratuvarýn en güçlü cihazlarýndan biri arýzalandý!"
        : "NORMAL: Standart cihaz arýzasý.";
    return Results.Ok(new
    {
        Mesaj = "Arýza kaydý baþarýyla oluþturuldu.",
        Cihaz = bulunanPc.Brand,
        Oncelik = oncelikDurumu,
        KayitTarihi = DateTime.Now.ToShortDateString()
    });
});

app.MapGet("/api/labs", async (AppDbContext context) => {
    return await context.Labs.ToListAsync();
});

app.MapPost("/api/admin/labs", async (AppDbContext context, Lab yeniLab) => {
    context.Labs.Add(yeniLab);
    await context.SaveChangesAsync();
    return Results.Ok(yeniLab);
});

app.Run();
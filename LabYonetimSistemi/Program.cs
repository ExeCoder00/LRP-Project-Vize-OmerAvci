using LabYonetimSistemi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var pcListesi = new List<Computer>
{
    new Computer { Id = 1, Brand = "Monster", Ram = 16, HasIssue = false },
    new Computer { Id = 2, Brand = "Lenovo", Ram = 8, HasIssue = true }
};

app.MapGet("/api/bilgisayarlar", () => pcListesi);

app.MapGet("/api/arizali-pcler", () =>
    pcListesi.Where(x => x.HasIssue == true).ToList());

app.MapGet("/api/bilgisayar/{id}", (int id) => {
    var bulunan = pcListesi.Find(x => x.Id == id);
    return bulunan;
});

app.MapPost("/api/bilgisayar-ekle", (Computer yeniPc) => {
    pcListesi.Add(yeniPc);
    return $"Yeni bilgisayar ({yeniPc.Brand}) baþarýyla eklendi!";
});

app.Run();  
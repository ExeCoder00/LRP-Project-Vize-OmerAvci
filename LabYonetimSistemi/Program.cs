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
app.MapGet("/api/lab-istatistik", () => {
    var gucluPcler = pcListesi.Where(p => p.Ram > 8).ToList();
    var siraliPcler = pcListesi.OrderBy(p => p.Brand).ToList();
    var tekPc = pcListesi.FirstOrDefault(p => p.Id == 1);
    var markalar = pcListesi.Select(p => p.Brand).ToList();
    var arizaSayisi = pcListesi.Count(p => p.HasIssue == true);
    bool canavarVarMi = pcListesi.Any(p => p.Ram == 32);
    bool hpVe16RamVarMi = pcListesi.Any(p => p.Ram == 16 && p.Brand == "HP");
    var rameSirali = pcListesi.OrderByDescending(p => p.Ram).ToList();
    return new
    {
        YuksekRamliCihazlar = gucluPcler,
        AlfabetikListe = siraliPcler,
        ArananBilgisayar = tekPc,
        SistemdekiMarkalar = markalar,
        ToplamAriza = arizaSayisi,
        LuksPcVarMi = canavarVarMi,
        HpVe16RamVarMi = hpVe16RamVarMi,
        RameSiraliListe = rameSirali
    };
});
app.MapPost("/api/ariza-bildir", (int pcId) => {
    var bulunanPc = pcListesi.FirstOrDefault(x => x.Id == pcId);
    if (bulunanPc == null)
    {
        return Results.NotFound($"Hata: {pcId} numaralý bilgisayar sistemde kayýtlý deðil!");
    }
    bulunanPc.HasIssue = true;
    string oncelikDurumu = "";
    if (bulunanPc.Ram >= 16)
    {
        oncelikDurumu = "KRÝTÝK: Laboratuvarýn en güçlü cihazlarýndan biri arýzalandý!";
    }
    else
    {
        oncelikDurumu = "NORMAL: Standart cihaz arýzasý.";
    }
    return Results.Ok(new
    {
        Mesaj = "Arýza kaydý baþarýyla oluþturuldu.",
        Cihaz = bulunanPc.Brand,
        Oncelik = oncelikDurumu,
        KayitTarihi = DateTime.Now.ToShortDateString(),
        Indeks = pcListesi.IndexOf(bulunanPc)
    });
});
app.Run();
using LabYonetimSistemi.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var computers = new List<Computer>
{
    new Computer { Id = 1, Marka = "Dell", Ram = 16, BozukMu = false, Processor = "Intel" },
    new Computer { Id = 2, Marka = "HP", Ram = 8, BozukMu = true, Processor = "AMD" },
    new Computer { Id = 5, Marka = "Acer", Ram = 8, BozukMu = true, Processor = "Intel" },
    new Computer { Id = 3, Marka = "Lenovo", Ram = 32, BozukMu = false, Processor = "Intel" },
    new Computer { Id = 4, Marka = "Asus", Ram = 16, BozukMu = false, Processor = "AMD" }
};

app.MapGet("/api/pc", () => computers);

app.Run();
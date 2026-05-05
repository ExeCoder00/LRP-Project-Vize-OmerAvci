var builder = WebApplication.CreateBuilder(args);
var app = builder.Build(); 
app.MapGet("/hosgeldiniz", () => "Laboratuvar Takip Sistemine Hoþ Geldiniz!");

app.Run();
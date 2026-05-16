namespace LabYonetimSistemi.Models;

public class Computer
{
    public int Id { get; set; }
    public string? AssetCode { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Processor { get; set; } = string.Empty;
    public int Ram { get; set; }
    public bool HasHdmi { get; set; }
    public bool HasInternet { get; set; }
    public bool HasVeyon { get; set; }
    public int LabId { get; set; }
}
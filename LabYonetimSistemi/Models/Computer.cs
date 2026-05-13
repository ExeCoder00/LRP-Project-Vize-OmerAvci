namespace LabYonetimSistemi.Models;

public class Computer
{
    public int Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public int Ram { get; set; }
    public bool HasIssue { get; set; }
    public string Processor { get; set; } = string.Empty;
}
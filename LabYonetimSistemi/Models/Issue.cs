namespace LabYonetimSistemi.Models;

public class Issue
{
    public int Id { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsResolved { get; set; }
    public int ComputerId { get; set; }
}
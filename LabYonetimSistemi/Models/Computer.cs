namespace LabYonetimSistemi.Models;

public class Computer
{
    public int Id { get; set; }
    public string Marka { get; set; } = string.Empty;
    public int Ram { get; set; }
    public bool BozukMu { get; set; }

    public string Processor { get; set; } = string.Empty;
}
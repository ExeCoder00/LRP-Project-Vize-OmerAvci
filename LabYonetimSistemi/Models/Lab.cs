namespace LabYonetimSistemi.Models;

public class Lab
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Computer> Computers { get; set; } = new();
}
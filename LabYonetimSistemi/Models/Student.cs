namespace LabYonetimSistemi.Models;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public int Grade { get; set; }
    public int ComputerId { get; set; } // Ana bilgisayar
    public string ComputerIds { get; set; } = string.Empty; // Virgülle ayrılmış tüm PC ID'leri
    public string Username { get; set; } = string.Empty;
}
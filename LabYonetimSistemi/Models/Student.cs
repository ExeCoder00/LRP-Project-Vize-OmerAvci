namespace LabYonetimSistemi.Models;

public class Student
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public int Grade { get; set; }
    public int ComputerId { get; set; }
    public string Username { get; set; } = string.Empty;
}
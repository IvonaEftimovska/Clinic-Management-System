namespace ClinicManagementSystem.Domain.Models;

public class Department : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    // Navigation
    public ICollection<Doctor>? Doctors { get; set; } = new List<Doctor>();
}
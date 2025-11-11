using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Domain.Models;

public class Department : BaseEntity
{
    [Required]
    public required string Name { get; set; } = string.Empty;
    [Required]
    public required string? Description { get; set; }

    // Navigation
    public ICollection<Doctor>? Doctors { get; set; } = new List<Doctor>();
}
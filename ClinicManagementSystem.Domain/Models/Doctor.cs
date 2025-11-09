using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Domain.Models;

public class Doctor : BaseEntity
{
    [Required]
    public required string FullName { get; set; } = string.Empty;
    [Required]
    public required string Specialty { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    // Foreign key to Department
    public Guid DepartmentId { get; set; }

    // Navigation
    public ICollection<Appointment>? Appointments { get; set; } = new List<Appointment>();
}
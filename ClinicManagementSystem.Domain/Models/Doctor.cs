using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Domain.Models;

public class Doctor : BaseEntity
{
    [Required]
    public required string FullName { get; set; } = string.Empty;
    [Required]
    public required string Specialty { get; set; } = string.Empty;
    [Required]
    public required string Email { get; set; } = string.Empty;
    [Required]
    public required string Phone { get; set; } = string.Empty;

    // Foreign key to Department
    [Required]
    public required Guid DepartmentId { get; set; }
    public Department? Department { get; set; }

    // Navigation
    public ICollection<Appointment>? Appointments { get; set; } = new List<Appointment>();
    public ICollection<Patient>? Patients { get; set; } = new List<Patient>();
}
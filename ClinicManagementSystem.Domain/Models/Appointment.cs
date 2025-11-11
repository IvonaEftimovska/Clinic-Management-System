using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Domain.Models;

public class Appointment : BaseEntity
{
    [Required]
    public required Guid PatientId { get; set; }
    public Patient? Patient { get; set; }
    
    [Required]
    public required Guid DoctorId { get; set; }
    public Doctor? Doctor { get; set; }

    public DateTime Date { get; set; }
    public string Time { get; set; } = string.Empty;
    public string? Notes { get; set; }
    
    // 1:1 with Prescription
    public Guid PrescriptionId { get; set; }
    public Prescription? Prescription { get; set; }
}
namespace ClinicManagementSystem.Domain.Models;

public class Appointment : BaseEntity
{
    public Guid PatientId { get; set; }
    public Patient? Patient { get; set; }

    public Guid DoctorId { get; set; }
    public Doctor? Doctor { get; set; }

    public DateTime Date { get; set; }
    public string Time { get; set; } = string.Empty;
    public string? Notes { get; set; }

    // 1:1 with Prescription
    public Prescription? Prescription { get; set; }
}
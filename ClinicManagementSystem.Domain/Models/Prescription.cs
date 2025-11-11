using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Domain.Models;

public class Prescription : BaseEntity
{
    public Guid AppointmentId { get; set; }
    public Appointment? Appointment { get; set; }

    [Required]
    public required string MedicineName { get; set; } = string.Empty;
    [Required]
    public required string Dosage { get; set; } = string.Empty;
}
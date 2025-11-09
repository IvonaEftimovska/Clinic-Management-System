namespace ClinicManagementSystem.Domain.Models;

public class Prescription : BaseEntity
{
    public Guid AppointmentId { get; set; }
    public Appointment? Appointment { get; set; }

    public string MedicineName { get; set; } = string.Empty;
    public string Dosage { get; set; } = string.Empty;
}
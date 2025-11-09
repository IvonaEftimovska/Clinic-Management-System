using System.ComponentModel.DataAnnotations;

namespace ClinicManagementSystem.Domain.Models;

public class Patient : BaseEntity
{
    [Required]
    public required string FullName { get; set; } = "";
    [Required]
    public required DateTime BirthDate { get; set; }
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";

    public virtual ICollection<Appointment>? Appointments { get; set; } = new List<Appointment>();
}
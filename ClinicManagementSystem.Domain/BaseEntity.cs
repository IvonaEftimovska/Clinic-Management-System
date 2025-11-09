using System.ComponentModel.DataAnnotations;
namespace ClinicManagementSystem.Domain;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }
}